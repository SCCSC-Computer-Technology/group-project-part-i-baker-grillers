using Baker_Grillers_Group_Project_Part_I;
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
    public partial class NFLForm: Form
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

        public NFLForm()
        {
            InitializeComponent();
            playerSortComboBox.SelectedIndex = 0;
            teamSortComboBox.SelectedIndex = 0;
        }

        private void NFLForm_Load(object sender, EventArgs e)
        {
            //set properties for the team tab
            UpdateTeamsDataSource();
            nflPlayerBindingSource.DataSource = db.NflPlayers;
            nflTeamListBox.ValueMember = "TeamID";
            nflTeamListBox.DisplayMember = "TeamName";
            nflTeamSelectComboBox.ValueMember = "TeamID";
            nflTeamSelectComboBox.DisplayMember = "TeamName";
            nflTeamPlayersListBox.ValueMember = "PlayerID";
            nflTeamPlayersListBox.DisplayMember = "FirstName";

            //set properties for the player tab
            UpdatePlayersDataSource();
            nflPlayerTeamsBindingSource.DataSource = db.NflTeams;
            nflPlayerListBox.ValueMember = "PlayerID";
            nflPlayerListBox.DisplayMember = "FirstName";
            nflPlayerSelectComboBox.ValueMember = "PlayerID";
            nflPlayerSelectComboBox.DisplayMember = "FirstName";
            nflPlayerTeamsListBox.ValueMember = "TeamID";
            nflPlayerTeamsListBox.DisplayMember = "TeamName";

        }

        private void teamSelectComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            int teamID = -1;
            try
            {
                if (nflTeamSelectComboBox.SelectedValue != null)
                {
                    teamID = Convert.ToInt32(nflTeamSelectComboBox.SelectedValue);
                }
            }
            catch
            {
                nflTeamPlayersBindingSource.DataSource = null;

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
            nflTeamPlayersBindingSource.DataSource = db.NflPlayers.Where(x => x.TeamID == teamID).ToList();

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
                double winPercentage = totalGames > 0 ? (double)stats.Wins / totalGames : 0;
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
            if (nflTeamPlayersListBox.SelectedIndex == -1) return;

            //get the player ID
            int playerID = -1;
            try
            {
                playerID = Convert.ToInt32(nflTeamPlayersListBox.SelectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem retrieving player data");
                return;
            }

            tabControl.SelectedIndex = 1; //switch to the players tab
            nflPlayerSelectComboBox.SelectedValue = playerID; //set the player selection to match the viewed player

        }

        private void viewTeamButton_Click(object sender, EventArgs e)
        {
            //don't do anything if no player is selected
            if (nflPlayerTeamsListBox.SelectedIndex == -1) return;

            //get the team ID
            int teamID = -1;
            try
            {
                teamID = Convert.ToInt32(nflPlayerTeamsListBox.SelectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.GetType()}\n{ex.Message}");
                return;
            }

            tabControl.SelectedIndex = 0; //switch to the teams tab
            nflTeamSelectComboBox.SelectedValue = teamID; //set the team selection to match the viewed team
        }

        private void nflPlayerSelectComboBox_SelectedValueChanged(object sender, EventArgs e)
        {            
            int playerID = -1;
            try
            {
                // Ensure a player is actually selected
                if (nflPlayerSelectComboBox.SelectedValue != null)
                {
                    playerID = Convert.ToInt32(nflPlayerSelectComboBox.SelectedValue);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                nflPlayerTeamsBindingSource.DataSource = null;
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
                        nflPlayerTeamsBindingSource.DataSource = teamList;
                    }
                    else
                    {
                        nflPlayerTeamsBindingSource.DataSource = new List<NflTeam>();
                    }
                }
                else
                {
                    nflPlayerTeamsBindingSource.DataSource = new List<NflTeam>();
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
                case 0: // Passing Yards
                    switch (PlayerFilterOperator)
                    {
                        case 0: 
                            matchedRecords = db.NflPlayerCareerPassStats
                                .Where(y => y.PassingYards.HasValue && y.PassingYards < PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        case 1: // Equal to
                            matchedRecords = db.NflPlayerCareerPassStats
                                .Where(y => y.PassingYards.HasValue && y.PassingYards == PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        case 2: // Greater than
                            matchedRecords = db.NflPlayerCareerPassStats
                                .Where(y => y.PassingYards.HasValue && y.PassingYards > PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        default: // All, default
                            matchedRecords = db.NflPlayerCareerPassStats.Select(x => x.PlayerID);
                            break;
                    }
                    break;
                case 1: // Touchdown passes
                    switch (PlayerFilterOperator)
                    {
                        case 0: // Less than
                            matchedRecords = db.NflPlayerCareerPassStats
                                .Where(y => y.TdPasses < PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        case 1: // Equal to
                            matchedRecords = db.NflPlayerCareerPassStats
                                .Where(y => y.TdPasses == PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        case 2: // Greater than
                            matchedRecords = db.NflPlayerCareerPassStats
                                .Where(y => y.TdPasses > PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        default: // All, default
                            matchedRecords = db.NflPlayerCareerPassStats.Select(x => x.PlayerID);
                            break;
                    }
                    break;
                case 2: // Interceptions
                    switch (PlayerFilterOperator)
                    {
                        case 0: // Less than
                            matchedRecords = db.NflPlayerCareerPassStats
                                .Where(y => y.Interceptions < PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        case 1: // Equal to
                            matchedRecords = db.NflPlayerCareerPassStats
                                .Where(y => y.Interceptions == PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        case 2: // Greater than
                            matchedRecords = db.NflPlayerCareerPassStats
                                .Where(y => y.Interceptions > PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        default: // All, default
                            matchedRecords = db.NflPlayerCareerPassStats.Select(x => x.PlayerID);
                            break;
                    }
                    break;
                case 3: // Rushing yards
                    switch (PlayerFilterOperator)
                    {
                        // Less than the entered value
                        case 0:
                            matchedRecords = db.NflPlayerCareerRushStats
                                .Where(y => y.RushYards.HasValue && y.RushYards < PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        // Exactly the entered value
                        case 1:
                            matchedRecords = db.NflPlayerCareerRushStats
                                .Where(y => y.RushYards.HasValue && y.RushYards == PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        // More than the entered value
                        case 2:
                            matchedRecords = db.NflPlayerCareerRushStats
                                .Where(y => y.RushYards.HasValue && y.RushYards > PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        // Select all players
                        default:
                            matchedRecords = db.NflPlayerCareerRushStats.Select(x => x.PlayerID);
                            break;
                    }
                    break;
                case 4: // Rushing touchdowns
                    switch (PlayerFilterOperator)
                    {
                        case 0:
                            matchedRecords = db.NflPlayerCareerRushStats
                                .Where(y => y.RushTds < PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        case 1:
                            matchedRecords = db.NflPlayerCareerRushStats
                                .Where(y => y.RushTds == PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        case 2:
                            matchedRecords = db.NflPlayerCareerRushStats
                                .Where(y => y.RushTds > PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        default:
                            matchedRecords = db.NflPlayerCareerRushStats.Select(x => x.PlayerID);
                            break;
                    }
                    break;
                case 5: // Receiving yards
                    switch (PlayerFilterOperator)
                    {
                        case 0: // Less than
                            matchedRecords = db.NflPlayerCareerReceiveStats
                                .Where(y => y.ReceivingYards.HasValue && y.ReceivingYards < PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        case 1: // Equal to
                            matchedRecords = db.NflPlayerCareerReceiveStats
                                .Where(y => y.ReceivingYards.HasValue && y.ReceivingYards == PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        case 2: // Greater than
                            matchedRecords = db.NflPlayerCareerReceiveStats
                                .Where(y => y.ReceivingYards.HasValue && y.ReceivingYards > PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        default: // All, default
                            matchedRecords = db.NflPlayerCareerReceiveStats.Select(x => x.PlayerID);
                            break;
                    }
                    break;
                case 6: // Receiving touchdowns
                    switch (PlayerFilterOperator)
                    {
                        case 0: // Less than
                            matchedRecords = db.NflPlayerCareerReceiveStats
                                .Where(y => y.ReceivingTds.HasValue && y.ReceivingTds < PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        case 1: // Equal to
                            matchedRecords = db.NflPlayerCareerReceiveStats
                                .Where(y => y.ReceivingTds.HasValue && y.ReceivingTds == PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        case 2: // Greater than
                            matchedRecords = db.NflPlayerCareerReceiveStats
                                .Where(y => y.ReceivingTds.HasValue && y.ReceivingTds > PlayerFilterValue)
                                .Select(y => y.PlayerID);
                            break;
                        default: // All, default
                            matchedRecords = db.NflPlayerCareerReceiveStats.Select(x => x.PlayerID);
                            break;
                    }
                    break;
                default: // No filter
                    // Combine tables
                    var passStatsPlayers = db.NflPlayerCareerPassStats.Select(x => x.PlayerID);
                    var rushStatsPlayers = db.NflPlayerCareerRushStats.Select(x => x.PlayerID);
                    var receiveStatsPlayers = db.NflPlayerCareerReceiveStats.Select(x => x.PlayerID);

                    // Union to combine all players together
                    matchedRecords = passStatsPlayers
                        .Union(rushStatsPlayers)
                        .Union(receiveStatsPlayers);
                    break;
            }

            // Ascending/descending sort
            if (PlayerSortOrder == 0)
            {
                nflPlayerBindingSource.DataSource =
                    db.NflPlayers
                        .Where(x => matchedRecords.Contains(x.PlayerID)) // Filter by stats
                        .Where(x => (x.FirstName + " " + x.LastName).Contains(PlayerSearchTerm)) // Search for name
                        .OrderBy(x => x.LastName)
                        .ThenBy(x => x.FirstName); // Order by last name, then first name
            }
            else
            {
                nflPlayerBindingSource.DataSource =
                    db.NflPlayers
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
                case 0: // Year
                    switch (TeamFilterOperator)
                    {
                        case 0: // Less than
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason && y.Wins < TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        case 1: // Equal to
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason && y.Wins == TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        case 2: // Greater than
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason && y.Wins > TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        default: // Default, all
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason)
                                .Select(x => x.TeamID);
                            break;
                    }
                    break;
                case 1: // Win percentage
                    switch (TeamFilterOperator)
                    {
                        case 0: // Less than
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason &&
                                       (y.Wins + y.Losses + y.Ties) > 0 &&
                                       (double)y.Wins / (y.Wins + y.Losses + y.Ties) < filterValueDouble)
                                .Select(y => y.TeamID);
                            break;
                        case 1: // Equal to
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason &&
                                       (y.Wins + y.Losses + y.Ties) > 0 &&
                                       (double)y.Wins / (y.Wins + y.Losses + y.Ties) == filterValueDouble)
                                .Select(y => y.TeamID);
                            break;
                        case 2: // Greater than
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason &&
                                       (y.Wins + y.Losses + y.Ties) > 0 &&
                                       (double)y.Wins / (y.Wins + y.Losses + y.Ties) > filterValueDouble)
                                .Select(y => y.TeamID);
                            break;
                        default: // All, default
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason)
                                .Select(x => x.TeamID);
                            break;
                    }
                    break;
                case 2: // Total touchdowns
                    switch (TeamFilterOperator)
                    {
                        case 0: // Less than
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason && y.TotalTD < TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        case 1: // Equal to
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason && y.TotalTD == TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        case 2: // Greater than
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason && y.TotalTD > TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        default: // Default , all
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason)
                                .Select(x => x.TeamID);
                            break;
                    }
                    break;
                case 3: // Rushing touchdowns
                    switch (TeamFilterOperator)
                    {
                        case 0: // Less than
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason && y.RushingTD < TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        case 1: // Equal to
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason && y.RushingTD == TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        case 2: // Greater than
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason && y.RushingTD > TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        default: // All, default
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason)
                                .Select(x => x.TeamID);
                            break;
                    }
                    break;
                case 4: // Receiving touchdowns
                    switch (TeamFilterOperator)
                    {
                        case 0: // Less than
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason && y.ReceivingTD < TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        case 1: // Equal to
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason && y.ReceivingTD == TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        case 2: // Greater than
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason && y.ReceivingTD > TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        default: // Default, all
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason)
                                .Select(x => x.TeamID);
                            break;
                    }
                    break;
                case 5: // Passing yards
                    switch (TeamFilterOperator)
                    {
                        case 0: // Less than
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason &&
                                       y.PassingYards.HasValue && y.PassingYards < TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        case 1: // Equal to
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason &&
                                       y.PassingYards.HasValue && y.PassingYards == TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        case 2: // Greater than
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason &&
                                       y.PassingYards.HasValue && y.PassingYards > TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        default: // All, default
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason)
                                .Select(x => x.TeamID);
                            break;
                    }
                    break;
                case 6: // Rushing yards
                    switch (TeamFilterOperator)
                    {
                        case 0: // Less than
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason &&
                                       y.RushYards.HasValue && y.RushYards < TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        case 1: // Equal to
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason &&
                                       y.RushYards.HasValue && y.RushYards == TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        case 2: // Greater than
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason &&
                                       y.RushYards.HasValue && y.RushYards > TeamFilterValue)
                                .Select(y => y.TeamID);
                            break;
                        default: // All, default
                            matchedRecords = db.NflTeamSeasonStats
                                .Where(y => y.SeasonYear == currentSeason)
                                .Select(x => x.TeamID);
                            break;
                    }
                    break;
                default: // No filter
                    matchedRecords = db.NflTeamSeasonStats
                        .Where(y => y.SeasonYear == currentSeason)
                        .Select(x => x.TeamID);
                    break;
            }

            // Ascending/descending
            if (TeamSortOrder == 0)
            {
                nflTeamBindingSource.DataSource =
                    db.NflTeams.Where(x => matchedRecords.Contains(x.TeamID))
                    .Where(x => x.TeamName.Contains(TeamSearchTerm))
                    .OrderBy(x => x.TeamName);
            }
            else
            {
                nflTeamBindingSource.DataSource =
                    db.NflTeams.Where(x => matchedRecords.Contains(x.TeamID))
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

