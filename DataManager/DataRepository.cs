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
            string enabledSports = "Football,Basketball,Baseball,Soccer";

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

    }
}
