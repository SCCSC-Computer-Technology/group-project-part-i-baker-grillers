/* Group Project Part 1
 * Team Name: Baker - Grillers
 * Members: Thomas Speich, Ashley Smith, Michael Lee
 * CPT-206-A01S-2025 Spring Smester: Adv Event-Driven Program
 * 
 * CSGO Form
 */

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
    public partial class CSGOForm: Form
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

        public CSGOForm()
        {
            InitializeComponent();
            playerSortComboBox.SelectedIndex = 0;
            teamSortComboBox.SelectedIndex = 0;
        }

        private void CSGOForm_Load(object sender, EventArgs e)
        {
            //set properties for the team tab
            UpdateTeamsDataSource();
            csgoPlayerBindingSource.DataSource = db.CsgoPlayers;
            csgoTeamListBox.ValueMember = "TeamID";
            csgoTeamListBox.DisplayMember = "TeamName";
            csgoTeamSelectComboBox.ValueMember = "TeamID";
            csgoTeamSelectComboBox.DisplayMember = "TeamName";
            csgoTeamPlayersListBox.ValueMember = "PlayerID";
            csgoTeamPlayersListBox.DisplayMember = "PlayerName";

            //set properties for the player tab
            UpdatePlayersDataSource();
            csgoPlayerTeamsBindingSource.DataSource = db.CsgoPlayerTeams;
            csgoPlayerListBox.ValueMember = "PlayerID";
            csgoPlayerListBox.DisplayMember = "PlayerName";
            csgoPlayerSelectComboBox.ValueMember = "PlayerID";
            csgoPlayerSelectComboBox.DisplayMember = "PlayerName";
            csgoPlayerTeamsListBox.ValueMember = "TeamID";
            csgoPlayerTeamsListBox.DisplayMember = "TeamName";

        }

        private void teamSelectComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //get the ID of the selected team
            int teamID = -1;
            try
            {
                if (csgoTeamSelectComboBox.SelectedValue != null)
                {
                    teamID = Convert.ToInt32(csgoTeamSelectComboBox.SelectedValue);
                }
            }
            catch
            {
                //Set the team's players data source to null
                csgoTeamPlayersBindingSource.DataSource = null;

                //make all team stats say "N/A"
                teamTotalMaps.Text = "N/A";
                teamKdDiff.Text = "N/A"; ;
                teamKd.Text = "N/A";
                teamRating.Text = "N/A";
                return;
            }

            //select all players on the selected team and add them to the team players data source
            var playerIDs = db.CsgoPlayerTeams.Where(x => x.TeamID == teamID).Select(x => x.PlayerID).ToList();
            csgoTeamPlayersBindingSource.DataSource = db.CsgoPlayers.Where(x => playerIDs.Contains(x.PlayerID));

            //select the stats of the selected team
            var stats = db.CsgoTeamStats.Where(x => x.TeamID == teamID).SingleOrDefault();
            
            //assign team stats to labels
            if (stats != null)
            {
                teamTotalMaps.Text = stats.TotalMaps.ToString();
                teamKdDiff.Text = stats.KdDiff.ToString();
                teamKd.Text = stats.Kd.ToString();
                teamRating.Text = stats.Rating.ToString();

            }
            else
            {
                teamTotalMaps.Text = "N/A";
                teamKdDiff.Text = "N/A"; ;
                teamKd.Text = "N/A";
                teamRating.Text = "N/A";
            }
            
        }

        private void viewPlayerButton_Click(object sender, EventArgs e)
        {
            //don't do anything if no player is selected
            if (csgoTeamPlayersListBox.SelectedIndex == -1) return;

            //get the player ID
            int playerID = -1;
            try
            {
                playerID = Convert.ToInt32(csgoTeamPlayersListBox.SelectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem retrieving player data");
                return;
            }

            tabControl.SelectedIndex = 1; //switch to the players tab
            csgoPlayerSelectComboBox.SelectedValue = playerID; //set the player selection to match the viewed player

        }


        private void viewTeamButton_Click(object sender, EventArgs e)
        {
            //don't do anything if no player is selected
            if (csgoPlayerTeamsListBox.SelectedIndex == -1) return;

            //get the team ID
            int teamID = -1;
            try
            {
                teamID = Convert.ToInt32(csgoPlayerTeamsListBox.SelectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.GetType()}\n{ex.Message}");
                return;
            }

            tabControl.SelectedIndex = 0; //switch to the teams tab
            csgoTeamSelectComboBox.SelectedValue = teamID; //set the team selection to match the viewed team
        }

        private void csgoPlayerSelectComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //get the player ID
            int playerID = -1;
            try
            {
                //check if a player is selected
                if (csgoPlayerSelectComboBox.SelectedValue != null)
                {
                    playerID = Convert.ToInt32(csgoPlayerSelectComboBox.SelectedValue);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                //if there is a problem retrieving the data or there is no selected player, set the player teams to null
                csgoPlayerTeamsBindingSource.DataSource = null;
                return;
            }

            //select the team IDs related to the selected player and assign them to the binding source
            var teamIDs = db.CsgoPlayerTeams.Where(x => x.PlayerID == playerID).Select(x => x.TeamID).ToList();
            csgoPlayerTeamsBindingSource.DataSource = db.CsgoTeams.Where(x => teamIDs.Contains(x.TeamID));

            //get the player's stats
            var stats = db.CsgoPlayerStats.Where(x => x.PlayerID == playerID).SingleOrDefault();

            //display the stats
            if (stats != null)
            {
                playerTotalMaps.Text = stats.TotalMaps.ToString();
                totalRounds.Text = stats.TotalRounds.ToString();
                playerKdDiff.Text = stats.KdDiff.ToString();
                playerKd.Text = stats.Kd.ToString();
                playerRating.Text = stats.Rating.ToString();

            }
            else
            {
                playerTotalMaps.Text = "N/A";
                totalRounds.Text = "N/A";
                playerKdDiff.Text = "N/A";
                playerKd.Text = "N/A";
                playerRating.Text = "N/A";
            }
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

            //find players that match the current filter
            IQueryable<int> matchedRecords;
            //decide the field to filter by
            switch (PlayerFilterField)
            {
                //filter by total maps
                case 0:

                    //decide which comparison to use
                    switch (PlayerFilterOperator)
                    {
                        //less than the entered value
                        case 0:
                            matchedRecords = db.CsgoPlayerStats.Where(y => y.TotalMaps < PlayerFilterValue).Select(y => y.PlayerID);
                            break;
                        //exactly the entered value
                        case 1:
                            matchedRecords = db.CsgoPlayerStats.Where(y => y.TotalMaps == PlayerFilterValue).Select(y => y.PlayerID);
                            break;
                        //more than the entered value
                        case 2:
                            matchedRecords = db.CsgoPlayerStats.Where(y => y.TotalMaps > PlayerFilterValue).Select(y => y.PlayerID);
                            break;
                        //select all players
                        default:
                            matchedRecords = db.CsgoPlayerStats.Select(x => x.PlayerID);
                            break;
                    }
                    break;
                //filter by total rounds
                case 1:

                    //decide which comparison to use
                    switch (PlayerFilterOperator)
                    {
                        //less than the entered value
                        case 0:
                            matchedRecords = db.CsgoPlayerStats.Where(y => y.TotalRounds < PlayerFilterValue).Select(y => y.PlayerID);
                            break;
                        //exactly the entered value
                        case 1:
                            matchedRecords = db.CsgoPlayerStats.Where(y => y.TotalRounds == PlayerFilterValue).Select(y => y.PlayerID);
                            break;
                        //more than the entered value
                        case 2:
                            matchedRecords = db.CsgoPlayerStats.Where(y => y.TotalRounds > PlayerFilterValue).Select(y => y.PlayerID);
                            break;
                        //select all players
                        default:
                            matchedRecords = db.CsgoPlayerStats.Select(x => x.PlayerID);
                            break;
                    }
                    break;
                //filter by KD diff
                case 2:

                    //decide which comparison to use
                    switch (PlayerFilterOperator)
                    {
                        //less than the entered value
                        case 0:
                            matchedRecords = db.CsgoPlayerStats.Where(y => y.KdDiff < PlayerFilterValue).Select(y => y.PlayerID);
                            break;
                        //exactly the entered value
                        case 1:
                            matchedRecords = db.CsgoPlayerStats.Where(y => y.KdDiff == PlayerFilterValue).Select(y => y.PlayerID);
                            break;
                        //more than the entered value
                        case 2:
                            matchedRecords = db.CsgoPlayerStats.Where(y => y.KdDiff > PlayerFilterValue).Select(y => y.PlayerID);
                            break;
                        //select all players
                        default:
                            matchedRecords = db.CsgoPlayerStats.Select(x => x.PlayerID);
                            break;
                    }
                    break;
                //filter by KD
                case 3:

                    //decide which comparison to use
                    switch (PlayerFilterOperator)
                    {
                        //less than the entered value
                        case 0:
                            matchedRecords = db.CsgoPlayerStats.Where(y => y.Kd < PlayerFilterValue).Select(y => y.PlayerID);
                            break;
                        //exactly the entered value
                        case 1:
                            matchedRecords = db.CsgoPlayerStats.Where(y => y.Kd == PlayerFilterValue).Select(y => y.PlayerID);
                            break;
                        //more than the entered value
                        case 2:
                            matchedRecords = db.CsgoPlayerStats.Where(y => y.Kd > PlayerFilterValue).Select(y => y.PlayerID);
                            break;
                        //select all players
                        default:
                            matchedRecords = db.CsgoPlayerStats.Select(x => x.PlayerID);
                            break;
                    }
                    break;
                //filter by rating
                case 4:

                    //decide which comparison to use
                    switch (PlayerFilterOperator)
                    {
                        //less than the entered value
                        case 0:
                            matchedRecords = db.CsgoPlayerStats.Where(y => y.Rating < PlayerFilterValue).Select(y => y.PlayerID);
                            break;
                        //exactly the entered value
                        case 1:
                            matchedRecords = db.CsgoPlayerStats.Where(y => y.Rating == PlayerFilterValue).Select(y => y.PlayerID);
                            break;
                        //more than the entered value
                        case 2:
                            matchedRecords = db.CsgoPlayerStats.Where(y => y.Rating > PlayerFilterValue).Select(y => y.PlayerID);
                            break;
                        //select all players
                        default:
                            matchedRecords = db.CsgoPlayerStats.Select(x => x.PlayerID);
                            break;
                    }
                    break;
                //select all players
                default:
                    matchedRecords = db.CsgoPlayerStats.Select(x => x.PlayerID);
                    break;

            }


            //decide whether the sort is ascending or descending
            if (PlayerSortOrder == 0)
            {
                csgoPlayerBindingSource.DataSource =
                    db.CsgoPlayers.Where(x => matchedRecords.Contains(x.PlayerID)) //filter by stats
                    .Where(x => x.PlayerName.Contains(PlayerSearchTerm)) //search for name
                    .OrderBy(x => x.PlayerName); // order by ascending
            }
            else
            {
                csgoPlayerBindingSource.DataSource =
                    db.CsgoPlayers.Where(x => matchedRecords.Contains(x.PlayerID)) //filter by stats
                    .Where(x => x.PlayerName.Contains(PlayerSearchTerm)) //search for name
                    .OrderByDescending(x => x.PlayerName); // order by ascending
            }
        }

        private void UpdateTeamsDataSource()
        {
            //find teams that match the current filter
            IQueryable<int> matchedRecords;
            //decide the field to filter by
            switch (TeamFilterField)
            {
                //filter by total maps
                case 0:

                    //decide which comparison to use
                    switch (TeamFilterOperator)
                    {
                        //less than the entered value
                        case 0:
                            matchedRecords = db.CsgoTeamStats.Where(y => y.TotalMaps < TeamFilterValue).Select(y => y.TeamID);
                            break;
                        //exactly the entered value
                        case 1:
                            matchedRecords = db.CsgoTeamStats.Where(y => y.TotalMaps == TeamFilterValue).Select(y => y.TeamID);
                            break;
                        //more than the entered value
                        case 2:
                            matchedRecords = db.CsgoTeamStats.Where(y => y.TotalMaps > TeamFilterValue).Select(y => y.TeamID);
                            break;
                        //select all teams
                        default:
                            matchedRecords = db.CsgoTeamStats.Select(x => x.TeamID);
                            break;
                    }
                    break;
                //filter by KD diff
                case 1:

                    //decide which comparison to use
                    switch (TeamFilterOperator)
                    {
                        //less than the entered value
                        case 0:
                            matchedRecords = db.CsgoTeamStats.Where(y => y.KdDiff < TeamFilterValue).Select(y => y.TeamID);
                            break;
                        //exactly the entered value
                        case 1:
                            matchedRecords = db.CsgoTeamStats.Where(y => y.KdDiff == TeamFilterValue).Select(y => y.TeamID);
                            break;
                        //more than the entered value
                        case 2:
                            matchedRecords = db.CsgoTeamStats.Where(y => y.KdDiff > TeamFilterValue).Select(y => y.TeamID);
                            break;
                        //select all teams
                        default:
                            matchedRecords = db.CsgoPlayerStats.Select(x => x.PlayerID);
                            break;
                    }
                    break;
                //filter by KD
                case 2:

                    //decide which comparison to use
                    switch (TeamFilterOperator)
                    {
                        //less than the entered value
                        case 0:
                            matchedRecords = db.CsgoTeamStats.Where(y => y.Kd < TeamFilterValue).Select(y => y.TeamID);
                            break;
                        //exactly the entered value
                        case 1:
                            matchedRecords = db.CsgoTeamStats.Where(y => y.Kd == TeamFilterValue).Select(y => y.TeamID);
                            break;
                        //more than the entered value
                        case 2:
                            matchedRecords = db.CsgoTeamStats.Where(y => y.Kd > TeamFilterValue).Select(y => y.TeamID);
                            break;
                        //select all teams
                        default:
                            matchedRecords = db.CsgoTeamStats.Select(x => x.TeamID);
                            break;
                    }
                    break;
                //filter by rating
                case 3:

                    //decide which comparison to use
                    switch (TeamFilterOperator)
                    {
                        //less than the entered value
                        case 0:
                            matchedRecords = db.CsgoTeamStats.Where(y => y.Rating < TeamFilterValue).Select(y => y.TeamID);
                            break;
                        //exactly the entered value
                        case 1:
                            matchedRecords = db.CsgoTeamStats.Where(y => y.Rating == TeamFilterValue).Select(y => y.TeamID);
                            break;
                        //more than the entered value
                        case 2:
                            matchedRecords = db.CsgoTeamStats.Where(y => y.Rating > TeamFilterValue).Select(y => y.TeamID);
                            break;
                        //select all teams
                        default:
                            matchedRecords = db.CsgoTeamStats.Select(x => x.TeamID);
                            break;
                    }
                    break;
                //select all teams
                default:
                    matchedRecords = db.CsgoTeamStats.Select(x => x.TeamID);
                    break;

            }

            //decide whether to sort by ascending or descending
            if (TeamSortOrder == 0)
            {
                csgoTeamBindingSource.DataSource =
                    db.CsgoTeams.Where(x => matchedRecords.Contains(x.TeamID)) //filter by stats
                    .Where(x => x.TeamName.Contains(TeamSearchTerm)) //search for name
                    .OrderBy(x => x.TeamName); // order by ascending
            }
            else
            {
                csgoTeamBindingSource.DataSource =
                    db.CsgoTeams.Where(x => matchedRecords.Contains(x.TeamID)) //filter by stats
                    .Where(x => x.TeamName.Contains(TeamSearchTerm)) //search for name
                    .OrderByDescending(x => x.TeamName); // order by ascending
            }


        }

        private void resetTeamFilterButton_Click(object sender, EventArgs e)
        {
            TeamFilterField = -1;
            TeamFilterOperator = -1;
            TeamFilterValue = -1;
            UpdateTeamsDataSource();
        }

        //Goes back to normal in the Players tab
        private void resetPlayerFilterButton_Click(object sender, EventArgs e)
        {
            PlayerFilterField = -1;
            PlayerFilterOperator = -1;
            PlayerFilterValue = -1;
            UpdatePlayersDataSource();
        }

        //Closes the CSGO Form
		private void exitButton_Click(object sender, EventArgs e)
		{
            this.Close();
		}
	}
}

