using System.Data;
using System.Data.SqlClient;

namespace DataManager
{
    public class DataRepository
    {

        string connectionString = string.Empty;
        public DataRepository(string connectionString)
        {
            // Initialize
            this.connectionString = connectionString;
        }

        public GlobalSettings GetGlobalSettings(string email)
        {

            // Defaults
            string font = "Microsoft Sans Serif";
            int themeIndex = 2; // Use system theme
            string enabledSports = "CSGO,Football,Basketball";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Open connection
                conn.Open();

                // Initialize query
                string query = "SELECT Font, Theme, EnabledSports FROM UserPreference WHERE Email = @Email";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (email != null)
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Load from database
                            font = reader.IsDBNull(0) ? font : reader.GetString(0);
                            themeIndex = reader.IsDBNull(1) ? themeIndex : reader.GetInt32(1);
                            enabledSports = reader.IsDBNull(2) ? enabledSports : reader.GetString(2);
                        }
                    }
                }

            }

            return new GlobalSettings(font, themeIndex, enabledSports);

        }

        public void SaveGlobalSettings(GlobalSettings globalSettings, string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // How this query works:
                // Checks if the user already has preferences.gi
                // If they do, then we overwrite them with the new preferences
                // If not, create a new record.
                string query = @"
            MERGE INTO UserPreference AS target
            USING (VALUES (@Email, @Font, @Theme, @EnabledSports)) 
            AS source (Email, Font, Theme, EnabledSports)
            ON target.Email = source.Email
            WHEN MATCHED THEN 
                UPDATE SET Font = source.Font, Theme = source.Theme, EnabledSports = source.EnabledSports
            WHEN NOT MATCHED THEN 
                INSERT (Email, Font, Theme, EnabledSports) 
                VALUES (source.Email, source.Font, source.Theme, source.EnabledSports);";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Font", globalSettings.Font);
                    cmd.Parameters.AddWithValue("@Theme", globalSettings.ThemeIndex);
                    cmd.Parameters.AddWithValue("@EnabledSports", globalSettings.EnabledSports);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public DataTable GetTeamsDataCSGO()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                SELECT t.TeamID, t.TeamName, 
                       ts.TotalMaps, ts.KdDiff, ts.Kd, ts.Rating
                FROM CsgoTeam t
                LEFT JOIN CsgoTeamStat ts ON t.TeamID = ts.TeamID
                ORDER BY t.TeamName";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    DataTable teamsDataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(teamsDataTable);
                    return teamsDataTable;
                }

            }

        }

        public DataTable GetTeamsDataNFL()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
        WITH LatestSeason AS (
            SELECT TeamID, MAX(SeasonYear) AS MaxYear 
            FROM NflTeamSeasonStat
            GROUP BY TeamID
        )
        SELECT t.TeamID, t.TeamName,
               ts.Wins, ts.Losses, ts.Ties,
               CAST(ts.Wins AS FLOAT) / NULLIF((ts.Wins + ts.Losses + ts.Ties), 0) AS WinPercentage,
               ts.TotalTD
        FROM NflTeam t
        LEFT JOIN LatestSeason ls ON t.TeamID = ls.TeamID
        LEFT JOIN NflTeamSeasonStat ts 
            ON t.TeamID = ts.TeamID AND ts.SeasonYear = ls.MaxYear
        ORDER BY t.TeamName;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    DataTable teamsDataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(teamsDataTable);
                    return teamsDataTable;
                }
            }
        }


        public DataTable GetTeamsDataNBA()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
        WITH LatestSeason AS (
            SELECT TeamID, MAX(SeasonYear) AS MaxYear 
            FROM NbaTeamSeasonStat
            GROUP BY TeamID
        )
        SELECT t.TeamID, t.TeamName, t.TeamAbreviation AS TeamAbbr,
               ts.TotalPoints,
               CAST(ts.FieldGoals AS FLOAT) / NULLIF(ts.FieldGoalAttempts, 0) * 100 AS FGPercentage,
               CAST(ts.ThreePoints AS FLOAT) / NULLIF(ts.ThreePointAttempts, 0) * 100 AS ThreePtPercentage,
               ts.Assists,
               ts.OffensiveRebounds + ts.DefensiveRebounds AS TotalRebounds
        FROM NbaTeam t
        LEFT JOIN LatestSeason ls ON t.TeamID = ls.TeamID
        LEFT JOIN NbaTeamSeasonStat ts 
            ON t.TeamID = ts.TeamID AND ts.SeasonYear = ls.MaxYear
        ORDER BY t.TeamName;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    DataTable teamsDataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(teamsDataTable);
                    return teamsDataTable;
                }
            }
        }


        public DataTable GetPlayersDataCSGO()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
        WITH PlayerTeams AS (
            SELECT pt.PlayerID, pt.TeamID,
                   ROW_NUMBER() OVER (PARTITION BY pt.PlayerID ORDER BY pt.TeamID) AS rn
            FROM CsgoPlayerTeam pt
        )
        SELECT p.PlayerID, p.PlayerName, 
               t.TeamName, 
               ps.KdDiff, ps.Kd, ps.Rating, ps.TotalMaps, ps.TotalRounds
        FROM CsgoPlayer p
        LEFT JOIN PlayerTeams pt ON p.PlayerID = pt.PlayerID AND pt.rn = 1
        LEFT JOIN CsgoTeam t ON pt.TeamID = t.TeamID
        LEFT JOIN CsgoPlayerStat ps ON p.PlayerID = ps.PlayerID
        ORDER BY ps.Rating DESC;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    DataTable playersDataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(playersDataTable);
                    return playersDataTable;
                }
            }
        }



        public DataTable GetPlayersDataNFL()
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                SELECT p.PlayerID, p.FirstName + ' ' + p.LastName AS PlayerName, 
                       t.TeamName, 
                       CASE 
                           WHEN pass.PassingYards IS NOT NULL THEN 'QB' 
                           WHEN rush.RushYards IS NOT NULL AND rec.ReceivingYards IS NULL THEN 'RB'
                           WHEN rec.ReceivingYards IS NOT NULL THEN 'WR/TE'
                           WHEN sack.Sacks IS NOT NULL THEN 'Defense'
                           WHEN kick.FieldGoals IS NOT NULL THEN 'Kicker'
                           ELSE 'Unknown'
                       END AS Position,
                       pass.PassingYards, pass.TdPasses, pass.Interceptions,
                       rush.RushYards, rush.RushTds,
                       rec.ReceivingYards, rec.ReceivingTds
                FROM NflPlayer p
                LEFT JOIN NflTeam t ON p.TeamID = t.TeamID
                LEFT JOIN NflPlayerCareerPassStat pass ON p.PlayerID = pass.PlayerID
                LEFT JOIN NflPlayerCareerRushStat rush ON p.PlayerID = rush.PlayerID
                LEFT JOIN NflPlayerCareerReceiveStat rec ON p.PlayerID = rec.PlayerID
                LEFT JOIN NflPlayerCareerSackStat sack ON p.PlayerID = sack.PlayerID
                LEFT JOIN NflPlayerCareerKickStat kick ON p.PlayerID = kick.PlayerID
                WHERE p.IsActive = 1
                ORDER BY PlayerName";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    DataTable playersDataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(playersDataTable);

                    return playersDataTable;
                }

            }

        }

        public DataTable GetPlayersDataNBA()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                SELECT p.PlayerID, p.FirstName + ' ' + p.LastName AS PlayerName,
                       t.TeamName,
                       stats.TotalPoints, stats.Assists, stats.OffensiveRebounds + stats.DefensiveRebounds AS TotalRebounds,
                       CASE 
                           WHEN stats.FieldGoalAttempts > 0 THEN 
                               CAST(stats.FieldGoals AS FLOAT) / stats.FieldGoalAttempts * 100 
                           ELSE 0 
                       END AS FieldGoalPercentage,
                       CASE 
                           WHEN stats.ThreePointAttempts > 0 THEN 
                               CAST(stats.ThreePoints AS FLOAT) / stats.ThreePointAttempts * 100 
                           ELSE 0 
                       END AS ThreePointPercentage
                FROM NbaPlayer p
                LEFT JOIN NbaTeam t ON p.TeamID = t.TeamID
                LEFT JOIN NbaPlayerCareerStat stats ON p.PlayerID = stats.PlayerID
                WHERE p.IsActive = 1
                ORDER BY stats.TotalPoints DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    DataTable playersDataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(playersDataTable);
                    return playersDataTable;
                }
            }
        }

    }
}
