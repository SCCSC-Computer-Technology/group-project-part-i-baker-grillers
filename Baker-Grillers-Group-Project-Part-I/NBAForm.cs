using Baker_Grillers_Group_Project_Part_I;
using Baker_Grillers_Group_Project_Part_I.Settings;
using DataManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserAuthentication
{
    public partial class NBAForm: Form
    {
        BGSportsStatsDBDataContext db = new BGSportsStatsDBDataContext();

        //fields for sorting, filtering, and searching teams
        private int TeamSortOrder = 0;
        private string TeamSearchTerm = "";
        private int TeamFilterField = -1;
        private int TeamFilterOperator = -1;
        private decimal TeamFilterValue = -1;

        //fields for sorting, filtering, and searching players
        private int PlayerSortOrder = 0;
        private string PlayerSearchTerm = "";
        private int PlayerFilterField = -1;
        private int PlayerFilterOperator = -1;
        private decimal PlayerFilterValue = -1;

        // Fields for initial team/player IDs
        private int? initialTeamId = null;
        private int? initialPlayerId = null;

        public NBAForm(int? initialTeamId = null, int? initialPlayerId = null)
        {
            InitializeComponent();
            playerSortComboBox.SelectedIndex = 0;
            teamSortComboBox.SelectedIndex = 0;

            // Set initial ids
            this.initialTeamId = initialTeamId;
            this.initialPlayerId = initialPlayerId;


            DataRepository dataRepository = new DataRepository(Program.connectionString);
            SettingsUtil.SetFormTheme(this, dataRepository, Program.CurrentSettingsUserEmail);
            
        }

        private void NBAForm_Load(object sender, EventArgs e)
        {
            //set properties for the team tab
            UpdateTeamsDataSource();
            nbaPlayerBindingSource.DataSource = db.NbaPlayers;
            nbaTeamListBox.ValueMember = "TeamID";
            nbaTeamListBox.DisplayMember = "TeamName";
            nbaTeamSelectComboBox.ValueMember = "TeamID";
            nbaTeamSelectComboBox.DisplayMember = "TeamName";
            nbaTeamPlayersListBox.ValueMember = "PlayerID";
            nbaTeamPlayersListBox.DisplayMember = "FullName";

            //set properties for the player tab
            UpdatePlayersDataSource();
            nbaPlayerTeamsBindingSource.DataSource = db.NbaTeams;
            nbaPlayerListBox.ValueMember = "PlayerID";
            nbaPlayerListBox.DisplayMember = "FullName";
            nbaPlayerSelectComboBox.ValueMember = "PlayerID";
            nbaPlayerSelectComboBox.DisplayMember = "FullName";
            nbaPlayerTeamsListBox.ValueMember = "TeamID";
            nbaPlayerTeamsListBox.DisplayMember = "TeamName";

            if (initialTeamId.HasValue)
            {
                tabControl.SelectedIndex = 0; // Select teams tab
                nbaTeamSelectComboBox.SelectedValue = initialTeamId.Value;
            }
            else if (initialPlayerId.HasValue)
            {
                tabControl.SelectedIndex = 1; // Select players tab
                nbaPlayerSelectComboBox.SelectedValue = initialPlayerId.Value;
            }

        }

        private void teamSelectComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            int teamID = -1;
            try
            {
                if (nbaTeamSelectComboBox.SelectedValue != null)
                {
                    teamID = Convert.ToInt32(nbaTeamSelectComboBox.SelectedValue);
                }
            }
            catch
            {
                nbaTeamPlayersBindingSource.DataSource = null;

                teamWins.Text = "N/A";
                teamLosses.Text = "N/A";
                teamTies.Text = "N/A";
                teamTouchdowns.Text = "N/A";
                teamRushingTouchdowns.Text = "N/A";
                teamPassingYards.Text = "N/A";
                teamRushingYards.Text = "N/A";
                return;
            }

            // Get current season
            int currentSeason = DateTime.Now.Year - 1;

            // Select all players
            nbaTeamPlayersBindingSource.DataSource = db.NflPlayers.Where(x => x.TeamID == teamID).ToList();

            // Select the stats of the selected team for the most recent season
            var stats = db.NflTeamSeasonStats
                .Where(x => x.TeamID == teamID && x.SeasonYear == currentSeason)
                .SingleOrDefault();

            if (stats != null)
            {
                teamWins.Text = stats.Wins.ToString();
                teamLosses.Text = stats.Losses.ToString();
                teamTies.Text = stats.Ties.ToString();

                // Calculate win percentage
                double totalGames = stats.Wins + stats.Losses + stats.Ties;
                double winPercentage = totalGames > 0 ? (double) stats.Wins / totalGames : 0;
                teamWinPercentage.Text = winPercentage.ToString("P2"); // Format as percentage

                teamTouchdowns.Text = stats.TotalTD.ToString();
                teamRushingTouchdowns.Text = stats.RushingTD.ToString();
                teamReceivingTouchdowns.Text = stats.ReceivingTD.ToString();
                teamPassingYards.Text = stats.PassingYards?.ToString() ?? "N/A";
                teamRushingYards.Text = stats.RushYards?.ToString() ?? "N/A";

            }
            else
            {
                // No stats found!
                teamWins.Text = "N/A";
                teamLosses.Text = "N/A";
                teamTies.Text = "N/A";
                teamWinPercentage.Text = "N/A";
                teamTouchdowns.Text = "N/A";
                teamRushingTouchdowns.Text = "N/A";
                teamReceivingTouchdowns.Text = "N/A";
                teamPassingYards.Text = "N/A";
                teamRushingYards.Text = "N/A";
            }
        }

        private void viewPlayerButton_Click(object sender, EventArgs e)
        {
            //don't do anything if no player is selected
            if (nbaTeamPlayersListBox.SelectedIndex == -1) return;

            //get the player ID
            int playerID = -1;
            try
            {
                playerID = Convert.ToInt32(nbaTeamPlayersListBox.SelectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem retrieving player data");
                return;
            }

            tabControl.SelectedIndex = 1; //switch to the players tab
            nbaPlayerSelectComboBox.SelectedValue = playerID; //set the player selection to match the viewed player

        }

        private void viewTeamButton_Click(object sender, EventArgs e)
        {
            //don't do anything if no player is selected
            if (nbaPlayerTeamsListBox.SelectedIndex == -1) return;

            //get the team ID
            int teamID = -1;
            try
            {
                teamID = Convert.ToInt32(nbaPlayerTeamsListBox.SelectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.GetType()}\n{ex.Message}");
                return;
            }

            tabControl.SelectedIndex = 0; //switch to the teams tab
            nbaTeamSelectComboBox.SelectedValue = teamID; //set the team selection to match the viewed team
        }

        private void nbaPlayerSelectComboBox_SelectedValueChanged(object sender, EventArgs e)
        {            
            int playerID = -1;
            try
            {
                // Ensure a player is actually selected
                if (nbaPlayerSelectComboBox.SelectedValue != null)
                {
                    playerID = Convert.ToInt32(nbaPlayerSelectComboBox.SelectedValue);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                nbaPlayerTeamsBindingSource.DataSource = null;
                ClearPlayerStats();
                return;
            }

            try
            {
                // Get the player's team
                var player = db.NflPlayers.FirstOrDefault(p => p.PlayerID == playerID);

                if (player != null && player.TeamID.HasValue)
                {
                    // Setup data source
                    var team = db.NflTeams.FirstOrDefault(t => t.TeamID == player.TeamID.Value);
                    if (team != null)
                    {
                        var teamList = new List<NflTeam> { team };
                        nbaPlayerTeamsBindingSource.DataSource = teamList;
                    }
                    else
                    {
                        nbaPlayerTeamsBindingSource.DataSource = new List<NflTeam>();
                    }
                }
                else
                {
                    nbaPlayerTeamsBindingSource.DataSource = new List<NflTeam>();
                }

                var passStats = db.NflPlayerCareerPassStats.FirstOrDefault(x => x.PlayerID == playerID);
                var rushStats = db.NflPlayerCareerRushStats.FirstOrDefault(x => x.PlayerID == playerID);
                var receiveStats = db.NflPlayerCareerReceiveStats.FirstOrDefault(x => x.PlayerID == playerID);

                bool hasStats = false;

                // Passing stats
                if (passStats != null)
                {
                    hasStats = true;
                    playerPassingYards.Text = passStats.PassingYards?.ToString() ?? "0";
                    playerTouchdownPasses.Text = passStats.TdPasses.ToString();
                    playerInterceptions.Text = passStats.Interceptions.ToString();

                    playerPassAttempts.Text = passStats.PassAttempts.ToString();
                    playerCompletions.Text = passStats.CompletePasses.ToString();
                    playerLongestPass.Text = passStats.LongestPass?.ToString() ?? "0";
                }

                // Rushing stats
                if (rushStats != null)
                {
                    hasStats = true;
                    playerRushYards.Text = rushStats.RushYards?.ToString() ?? "0";
                    playerRushTouchdowns.Text = rushStats.RushTds.ToString();
                    playerRushAttempts.Text = rushStats.RushAttempts.ToString();
                    playerRushFirstDowns.Text = rushStats.RushFirstdowns?.ToString() ?? "0";
                }

                // Receiving stats
                if (receiveStats != null)
                {
                    hasStats = true;
                    playerReceivingYards.Text = receiveStats.ReceivingYards?.ToString() ?? "0";
                    playerReceivingTouchdowns.Text = receiveStats.ReceivingTds?.ToString() ?? "0";
                    playerReceptions.Text = receiveStats.Receptions?.ToString() ?? "0";
                }

                // Clear fields if no data...
                if (!hasStats)
                {
                    ClearPlayerStats();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading player stats: {ex.Message}");
                ClearPlayerStats();
            }
        }

        private void ClearPlayerStats()
        {
            // Passing stats
            playerPassingYards.Text = "N/A";
            playerTouchdownPasses.Text = "N/A";
            playerInterceptions.Text = "N/A";
            playerPassAttempts.Text = "N/A";
            playerCompletions.Text = "N/A";
            playerLongestPass.Text = "N/A";

            // Rushing stats
            playerRushYards.Text = "N/A";
            playerRushTouchdowns.Text = "N/A";
            playerRushAttempts.Text = "N/A";
            playerRushFirstDowns.Text = "N/A";

            // Receiving stats
            playerReceivingYards.Text = "N/A";
            playerReceivingTouchdowns.Text = "N/A";
            playerReceptions.Text = "N/A";
        }

        private void teamSortButton_Click(object sender, EventArgs e)
        {
            //check for a valid sort selection
            if (teamSortComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an order to sort by");
                return;
            }

            //sort the team dataset
            TeamSortOrder = teamSortComboBox.SelectedIndex;
            UpdateTeamsDataSource();
        }

        private void teamSearchButton_Click(object sender, EventArgs e)
        {
            //check for a valid search term
            if(string.IsNullOrEmpty(teamSearchTextBox.Text))
            {
                MessageBox.Show("Please enter a term to search for");
            }

            //search for team names that contain the entered term
            TeamSearchTerm = teamSearchTextBox.Text;
            UpdateTeamsDataSource();
        }

        private void playerSortButton_Click(object sender, EventArgs e)
        {
            //check for a valid sort selection
            if(playerSortComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an order to sort by");
                return;
            }

            //sort the player dataset
            PlayerSortOrder = playerSortComboBox.SelectedIndex;
            UpdatePlayersDataSource();

        }

        private void playerSearchButton_Click(object sender, EventArgs e)
        {
            //check if a valid term has been entered
            if (string.IsNullOrEmpty(playerSearchTextBox.Text))
            {
                MessageBox.Show("Please enter a term to search for");
                return;
            }

            //search for player names that contain the entered term
            PlayerSearchTerm = playerSearchTextBox.Text;
            UpdatePlayersDataSource();
        }

        private void playerFilterButton_Click(object sender, EventArgs e)
        {
            //check if the selections for the filter are valid
            if(playerFilterFieldComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a player stat to filter by");
                return;
            }
            if(playerFilterOperatorComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an operator to filter player stats by");
                return;
            }

            //filter the player dataset
            PlayerFilterField = playerFilterFieldComboBox.SelectedIndex;
            PlayerFilterOperator = playerFilterOperatorComboBox.SelectedIndex;
            PlayerFilterValue = playerFilterNumUpDown.Value;
            UpdatePlayersDataSource();
        }


        private void teamFilterButton_Click(object sender, EventArgs e)
        {
            //check if the selections for the filter are valid
            if (teamFilterStatComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a team stat to filter by");
                return;
            }
            if (teamFilterOperatorComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an operator to filter team stats by");
                return;
            }

            //filter the team dataset
            TeamFilterField = teamFilterStatComboBox.SelectedIndex;
            TeamFilterOperator = teamFilterOperatorComboBox.SelectedIndex;
            TeamFilterValue = teamFilterNumUpDown.Value;
            UpdateTeamsDataSource();
        }
        private void teamSearchResetButton_Click(object sender, EventArgs e)
        {
            //reset the team search
            TeamSearchTerm = "";
            UpdateTeamsDataSource();
        }

        private void resetPlayerSearchButton_Click(object sender, EventArgs e)
        {
            //reset the player search
            PlayerSearchTerm = "";
            UpdatePlayersDataSource();
        }


        private void UpdatePlayersDataSource()
        {
            IQueryable<int> matchedRecords;

            // In case we need more precision
            double filterValueDouble = Convert.ToDouble(PlayerFilterValue);

            // Filter by...
            switch (PlayerFilterField)
            {
                case 0: // Total Points
                    switch (PlayerFilterOperator)
                    {
                        case 0:
                            matchedRecords = db.NbaPlayerCareerStats
                                .Where(y => y.TotalPoints.HasValue && y.TotalPoints < PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        case 1: // Equal to
                            matchedRecords = db.NbaPlayerCareerStats
                                .Where(y => y.TotalPoints.HasValue && y.TotalPoints == PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        case 2: // Greater than
                            matchedRecords = db.NbaPlayerCareerStats
                                .Where(y => y.TotalPoints.HasValue && y.TotalPoints > PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        default: // All, default
                            matchedRecords = db.NbaPlayerCareerStats.Select(x => x.PlayerID);
                            break;
                    }
                    break;
                case 1: // Field Goal %
                    switch (PlayerFilterOperator)
                    {
                        case 0: // Less than
                            matchedRecords = db.NbaPlayerCareerStats
                                .Where(y => y.FieldGoalAttempts > 0 &&
                                       (double)y.FieldGoals / y.FieldGoalAttempts < filterValueDouble)
                                .Select(y => y.PlayerID);
                            break;
                        case 1: // Equal to
                            matchedRecords = db.NbaPlayerCareerStats
                                .Where(y => y.FieldGoalAttempts > 0 &&
                                       (double)y.FieldGoals / y.FieldGoalAttempts == filterValueDouble)
                                .Select(y => y.PlayerID);
                            break;
                        case 2: // Greater than
                            matchedRecords = db.NbaPlayerCareerStats
                                .Where(y => y.FieldGoalAttempts > 0 &&
                                       (double)y.FieldGoals / y.FieldGoalAttempts > filterValueDouble)
                                .Select(y => y.PlayerID);
                            break;
                        default: // All, default
                            matchedRecords = db.NbaPlayerCareerStats.Select(x => x.PlayerID);
                            break;
                    }
                    break;
                case 2: // Three-Point %
                    switch (PlayerFilterOperator)
                    {
                        case 0: // Less than
                            matchedRecords = db.NbaPlayerCareerStats
                                .Where(y => y.ThreePointAttempts > 0 &&
                                       (double)y.ThreePoints / y.ThreePointAttempts < filterValueDouble)
                                .Select(y => y.PlayerID);
                            break;
                        case 1: // Equal to
                            matchedRecords = db.NbaPlayerCareerStats
                                .Where(y => y.ThreePointAttempts > 0 &&
                                       (double)y.ThreePoints / y.ThreePointAttempts == filterValueDouble)
                                .Select(y => y.PlayerID);
                            break;
                        case 2: // Greater than
                            matchedRecords = db.NbaPlayerCareerStats
                                .Where(y => y.ThreePointAttempts > 0 &&
                                       (double)y.ThreePoints / y.ThreePointAttempts > filterValueDouble)
                                .Select(y => y.PlayerID);
                            break;
                        default: // All, default
                            matchedRecords = db.NbaPlayerCareerStats.Select(x => x.PlayerID);
                            break;
                    }
                    break;
                case 3: // Assists
                    switch (PlayerFilterOperator)
                    {
                        case 0:
                            matchedRecords = db.NbaPlayerCareerStats
                                .Where(y => y.Assists.HasValue && y.Assists < PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        case 1:
                            matchedRecords = db.NbaPlayerCareerStats
                                .Where(y => y.Assists.HasValue && y.Assists == PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        case 2:
                            matchedRecords = db.NbaPlayerCareerStats
                                .Where(y => y.Assists.HasValue && y.Assists > PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        default:
                            matchedRecords = db.NbaPlayerCareerStats.Select(x => x.PlayerID);
                            break;
                    }
                    break;
                case 4: // Rebounds
                    switch (PlayerFilterOperator)
                    {
                        case 0: // Less than
                            matchedRecords = db.NbaPlayerCareerStats
                                .Where(y => (y.OffensiveRebounds + y.DefensiveRebounds) < PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        case 1: // Equal to
                            matchedRecords = db.NbaPlayerCareerStats
                                .Where(y => (y.OffensiveRebounds + y.DefensiveRebounds) == PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        case 2: // Greater than
                            matchedRecords = db.NbaPlayerCareerStats
                                .Where(y => (y.OffensiveRebounds + y.DefensiveRebounds) > PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        default: // All, default
                            matchedRecords = db.NbaPlayerCareerStats.Select(x => x.PlayerID);
                            break;
                    }
                    break;
                case 5: // Steals
                    switch (PlayerFilterOperator)
                    {
                        case 0: // Less than
                            matchedRecords = db.NbaPlayerCareerStats
                                .Where(y => y.Steals.HasValue && y.Steals < PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        case 1: // Equal to
                            matchedRecords = db.NbaPlayerCareerStats
                                .Where(y => y.Steals.HasValue && y.Steals == PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        case 2: // Greater than
                            matchedRecords = db.NbaPlayerCareerStats
                                .Where(y => y.Steals.HasValue && y.Steals > PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        default: // All, default
                            matchedRecords = db.NbaPlayerCareerStats.Select(x => x.PlayerID);
                            break;
                    }
                    break;
                case 6: // Blocks
                    switch (PlayerFilterOperator)
                    {
                        case 0: // Less than
                            matchedRecords = db.NbaPlayerCareerStats
                                .Where(y => y.Blocks.HasValue && y.Blocks < PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        case 1: // Equal to
                            matchedRecords = db.NbaPlayerCareerStats
                                .Where(y => y.Blocks.HasValue && y.Blocks == PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        case 2: // Greater than
                            matchedRecords = db.NbaPlayerCareerStats
                                .Where(y => y.Blocks.HasValue && y.Blocks > PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        default: // All, default
                            matchedRecords = db.NbaPlayerCareerStats.Select(x => x.PlayerID);
                            break;
                    }
                    break;
                default: // No filter
                    matchedRecords = db.NbaPlayerCareerStats.Select(x => x.PlayerID);
                    break;
            }

            // Ascending/descending sort
            if (PlayerSortOrder == 0)
            {
                nbaPlayerBindingSource.DataSource =
                    db.NbaPlayers
                        .Where(x => matchedRecords.Contains(x.PlayerID)) // Filter by stats
                        .Where(x => (x.FirstName + " " + x.LastName).Contains(PlayerSearchTerm)) // Search for name
                        .OrderBy(x => x.LastName)
                        .ThenBy(x => x.FirstName); // Order by last name, then first name
            }
            else
            {
                nbaPlayerBindingSource.DataSource =
                    db.NbaPlayers
                        .Where(x => matchedRecords.Contains(x.PlayerID)) // Filter by stats
                        .Where(x => (x.FirstName + " " + x.LastName).Contains(PlayerSearchTerm)) // Search for name
                        .OrderByDescending(x => x.LastName)
                        .ThenByDescending(x => x.FirstName); // Order by last name, then first name
            }
        }

        private void UpdateTeamsDataSource()
        {
            IQueryable<int> matchedRecords;

            int currentSeason = DateTime.Now.Year - 1;

            // In case we need more precision
            double filterValueDouble = Convert.ToDouble(TeamFilterValue);

            // Filter by...
            switch (TeamFilterField)
            {
                case 0: // Total Points
                    switch (TeamFilterOperator)
                    {
                        case 0: // Less than
                            matchedRecords = db.NbaTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason &&
                                       y.TotalPoints.HasValue && y.TotalPoints < TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        case 1: // Equal to
                            matchedRecords = db.NbaTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason &&
                                       y.TotalPoints.HasValue && y.TotalPoints == TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        case 2: // Greater than
                            matchedRecords = db.NbaTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason &&
                                       y.TotalPoints.HasValue && y.TotalPoints > TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        default: // All, default
                            matchedRecords = db.NbaTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason)
                                .Select(x => x.TeamID);
                            break;
                    }
                    break;
                case 1: // Field Goal %
                    switch (TeamFilterOperator)
                    {
                        case 0: // Less than
                            matchedRecords = db.NbaTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason &&
                                       y.FieldGoalAttempts > 0 &&
                                       (double)y.FieldGoals / y.FieldGoalAttempts < filterValueDouble)
                                .Select(y => y.TeamID);
                            break;
                        case 1: // Equal to
                            matchedRecords = db.NbaTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason &&
                                       y.FieldGoalAttempts > 0 &&
                                       (double)y.FieldGoals / y.FieldGoalAttempts == filterValueDouble)
                                .Select(y => y.TeamID);
                            break;
                        case 2: // Greater than
                            matchedRecords = db.NbaTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason &&
                                       y.FieldGoalAttempts > 0 &&
                                       (double)y.FieldGoals / y.FieldGoalAttempts > filterValueDouble)
                                .Select(y => y.TeamID);
                            break;
                        default: // All, default
                            matchedRecords = db.NbaTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason)
                                .Select(x => x.TeamID);
                            break;
                    }
                    break;
                case 2: // Three Point %
                    switch (TeamFilterOperator)
                    {
                        case 0: // Less than
                            matchedRecords = db.NbaTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason &&
                                       y.ThreePointAttempts > 0 &&
                                       (double)y.ThreePoints / y.ThreePointAttempts < filterValueDouble)
                                .Select(y => y.TeamID);
                            break;
                        case 1: // Equal to
                            matchedRecords = db.NbaTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason &&
                                       y.ThreePointAttempts > 0 &&
                                       (double)y.ThreePoints / y.ThreePointAttempts == filterValueDouble)
                                .Select(y => y.TeamID);
                            break;
                        case 2: // Greater than
                            matchedRecords = db.NbaTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason &&
                                       y.ThreePointAttempts > 0 &&
                                       (double)y.ThreePoints / y.ThreePointAttempts > filterValueDouble)
                                .Select(y => y.TeamID);
                            break;
                        default: // All, default
                            matchedRecords = db.NbaTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason)
                                .Select(x => x.TeamID);
                            break;
                    }
                    break;
                case 3: // Rebounds
                    switch (TeamFilterOperator)
                    {
                        case 0: // Less than
                            matchedRecords = db.NbaTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason &&
                                       (y.OffensiveRebounds + y.DefensiveRebounds) < TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        case 1: // Equal to
                            matchedRecords = db.NbaTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason &&
                                       (y.OffensiveRebounds + y.DefensiveRebounds) == TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        case 2: // Greater than
                            matchedRecords = db.NbaTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason &&
                                       (y.OffensiveRebounds + y.DefensiveRebounds) > TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        default: // All, default
                            matchedRecords = db.NbaTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason)
                                .Select(x => x.TeamID);
                            break;
                    }
                    break;
                case 4: // Assists
                    switch (TeamFilterOperator)
                    {
                        case 0: // Less than
                            matchedRecords = db.NbaTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason &&
                                       y.Assists.HasValue && y.Assists < TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        case 1: // Equal to
                            matchedRecords = db.NbaTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason &&
                                       y.Assists.HasValue && y.Assists == TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        case 2: // Greater than
                            matchedRecords = db.NbaTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason &&
                                       y.Assists.HasValue && y.Assists > TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        default: // All, default
                            matchedRecords = db.NbaTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason)
                                .Select(x => x.TeamID);
                            break;
                    }
                    break;
                default: // No filter
                    matchedRecords = db.NbaTeamSeasonStats
                        .Where(y => y.SeasonYear == currentSeason)
                        .Select(x => x.TeamID);
                    break;
            }

            // Ascending/descending
            if (TeamSortOrder == 0)
            {
                nbaTeamBindingSource.DataSource =
                    db.NbaTeams.Where(x => matchedRecords.Contains(x.TeamID))
                    .Where(x => x.TeamName.Contains(TeamSearchTerm))
                    .OrderBy(x => x.TeamName);
            }
            else
            {
                nbaTeamBindingSource.DataSource =
                    db.NbaTeams.Where(x => matchedRecords.Contains(x.TeamID))
                    .Where(x => x.TeamName.Contains(TeamSearchTerm))
                    .OrderByDescending(x => x.TeamName);
            }
        }

        private void resetTeamFilterButton_Click(object sender, EventArgs e)
        {
            TeamFilterField = -1;
            TeamFilterOperator = -1;
            TeamFilterValue = -1;
            UpdateTeamsDataSource();
        }

        private void resetPlayerFilterButton_Click(object sender, EventArgs e)
        {
            PlayerFilterField = -1;
            PlayerFilterOperator = -1;
            PlayerFilterValue = -1;
            UpdatePlayersDataSource();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

