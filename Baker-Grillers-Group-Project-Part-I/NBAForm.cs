/* Group Project Part 1
 * Team Name: Baker - Grillers
 * Members: Thomas Speich, Ashley Smith, Michael Lee
 * CPT-206-A01S-2025 Spring Smester: Adv Event-Driven Program
 * 
 * NBA Form
 */

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

namespace Baker_Grillers_Group_Project_Part_I
{
	public partial class NBAForm : Form
	{
		BGSportsStatsDBDataContext db = new BGSportsStatsDBDataContext();

		//sorting, filtering, and searching fields on teams
		private int TeamSortOrder = 0;
		private string TeamSearchTerm = "";
		private int TeamFilterField = -1;
		private int TeamFilterOperator = -1;
		private decimal TeamFilterValue = -1;

		//sorting, filtering, and searching fields on players
		private int PlayerSortOrder = 0;
		private string PlayerSearchTerm = "";
		private int PlayerFilterField = -1;
		private int PlayerFilterOperator = -1;
		private decimal PlayerFilterValue = -1;

        // Fields for initial team/player IDs
        private int? initialTeamId = null;
        private int? initialPlayerId = null;

        // Setup season
        private int currentSeason = 2025;

        public NBAForm(int? initialTeamId = null, int? initialPlayerId = null)
        {
			InitializeComponent();

            // Set initial ids
            this.initialTeamId = initialTeamId;
            this.initialPlayerId = initialPlayerId;

			// Theming
            DataRepository dataRepository = new DataRepository(Program.connectionString);
            SettingsUtil.SetFormTheme(this, dataRepository, Program.CurrentSettingsUserEmail);
        }

		private void NBAForm_Load(object sender, EventArgs e)
		{
			//properties for the team tab
			UpdateTeamsDataSource();
			nbaPlayerBindingSource.DataSource = db.NbaPlayers;
			nbaTeamListBox.ValueMember = "TeamID";
			nbaTeamListBox.DisplayMember = "TeamName";
			nbaTeamSelectComboBox.ValueMember = "TeamID";
			nbaTeamSelectComboBox.DisplayMember = "TeamName";
			nbaTeamPlayersListBox.ValueMember = "PlayerID";
			nbaTeamPlayersListBox.DisplayMember = "FullName";
			nbaTeamSelectComboBox.SelectedIndex = 0;

			//properties for the players tab
			UpdatePlayersDataSource();
			nbaTeamPlayersBindingSource.DataSource = db.NbaPlayers;
			nbaPlayerListBox.ValueMember = "PlayerID";
			nbaPlayerListBox.DisplayMember = "FullName";
			nbaPlayerSelectComboBox.ValueMember = "PlayerID";
			nbaPlayerSelectComboBox.DisplayMember = "FullName";
			nbaPlayerSelectComboBox.SelectedIndex = 0;

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

		private void nbaTeamListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			//Recieve ID for the selected player
			int playerID = -1;
			try
			{
				//check if player is selected
				if (nbaPlayerSelectComboBox.SelectedValue != null)
				{
					playerID = Convert.ToInt32
					(nbaPlayerSelectComboBox.SelectedValue);
				}
				else
				{
					throw new Exception();
				}
			}
			catch
			{
				/*if there is a problem recieving the data or there is no
				 selected player, set the player teams to null*/
				nbaPlayerTeamsBindingSource.DataSource = db.NbaPlayers;
				return;
			}

			//getting teams ID
			var teamsID = db.NbaPlayers.Where(x => x.PlayerID == 
			playerID).Select(x => x.PlayerID).ToList();
			nbaPlayerTeamsBindingSource.DataSource = db.NbaTeams.Where(x =>
			teamsID.Contains(x.TeamID));

			
			
		}

		//Teams tab sort button
		private void teamSortButton_Click(object sender, EventArgs e)
		{
			//Check for vaild sort selection
			if (teamSortComboBox.SelectedIndex == -1)
			{
				MessageBox.Show("Please select an order to sort by");
				return;
			}

			//sort the team dataset
			TeamSortOrder = teamSortComboBox.SelectedIndex;
			UpdateTeamsDataSource();
		}

		//Teams tab search button
		private void teamSearchButton_Click(object sender, EventArgs e)
		{
			//check for a vaild search term
			if (string.IsNullOrEmpty(teamSearchTextBox.Text))
			{
				MessageBox.Show("Please enter a term to search for");
			}

			//search for teams names that contain entered term
			TeamSearchTerm = teamSearchTextBox.Text;
			UpdateTeamsDataSource();
		}

		//Teams tab filter button
		private void teamFilterButton_Click(object sender, EventArgs e)
		{
			//check if the selections for the filter are valid
			if (teamFilterStatComboBox.SelectedIndex == -1)
			{
				MessageBox.Show("Please select a team stat to filter by");
				return;
			}
			if (teamFilterStatComboBox.SelectedIndex == -1)
			{
				MessageBox.Show("Please select an operator to filter team stats by");
				return;
			}

			//Filtering team dataset
			TeamFilterField = teamFilterStatComboBox.SelectedIndex;
			TeamFilterOperator = teamFilterStatComboBox.SelectedIndex;
			TeamFilterValue = teamFilterNumUpDown.Value;
			UpdateTeamsDataSource();
		}

		//Team tab reset button
		private void teamSearchResetButton_Click(object sender, EventArgs e)
		{
			//reset the team search (going back to before)
			TeamSearchTerm = "";
			UpdateTeamsDataSource();
		}

		//Team tab reset filter button  (goes back to normal)
		private void resetTeamFilterButton_Click(object sender, EventArgs e)
		{
			TeamFilterField = -1;
			TeamFilterOperator= -1;
			TeamFilterValue = -1;
			UpdateTeamsDataSource();
		}

		//Players tab sort button
		private void playerSortButton_Click(object sender, EventArgs e)
		{
			//check for vaild sort selection
			if (playerSortComboBox.SelectedIndex == -1)
			{
				MessageBox.Show("Please select an order to sort by");
				return;
			}

			//sorting the player dataset
			PlayerSortOrder = playerSortComboBox.SelectedIndex;
			UpdatePlayersDataSource();
		}

		//Player's tab search button
		private void playerSearchButton_Click(object sender, EventArgs e)
		{
			//check if a valid term has been entered
			if (string.IsNullOrEmpty(playerSearchTextBox.Text))
			{
				MessageBox.Show("Please enter a term to search for");
				return;
			}

			//Search for players names that contain the entered term
			PlayerSearchTerm = playerSearchTextBox.Text;
			UpdatePlayersDataSource();
		}

		//Players filter button
		private void playerFilterButton_Click(object sender, EventArgs e)
		{
			//check if the selections for the filter are vaild
			if (playerFilterFieldComboBox.SelectedIndex == -1)
			{
				MessageBox.Show("Please select a player stat to filter by");
				return;
			}
			if (playerFilterOperatorComboBox.SelectedIndex == -1)
			{
				MessageBox.Show("Please select an operator to filter player stats by");
				return;
			}

			//Filtering player dataset
			PlayerFilterField = playerFilterFieldComboBox.SelectedIndex;
			PlayerFilterOperator = playerFilterOperatorComboBox.SelectedIndex;
			PlayerFilterValue = playerFilterNumUpDown.Value;
			UpdatePlayersDataSource();

		}

		//Players tab reset search (goes back to normal)
		private void resetPlayerSearchButton_Click(object sender, EventArgs e)
		{
			//reset the player's search (going back to before)
			PlayerSearchTerm = "";
			UpdatePlayersDataSource();
		}

		//Player's tab reset filter button (goes back to normal)
		private void resetPlayerFilterButton_Click(object sender, EventArgs e)
		{
			PlayerFilterField = -1;
			PlayerFilterOperator = -1;
			PlayerFilterValue = -1;
			UpdatePlayersDataSource();
		}

		//Update method of the Players [tab] datasource
		private void UpdatePlayersDataSource()
		{
			//find players that match the current filter
			IQueryable<int> matchedRecords;
			//decide the field to filter by
			switch (PlayerFilterField)
			{
				//filter by Assists
				case 0:
					//decide which comparison to use
					switch (PlayerFilterOperator)
					{
						//less than entered value
						case 0:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.Assists < PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//entered exact value
						case 1:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.Assists == PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//more than entered value
						case 2:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.Assists > PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//select all players
						default:
							matchedRecords = db.NbaPlayerCareerStats.Select(x =>
							x.PlayerID);
							break;
					}
					break;

				//filter by Steals
				case 1:
					//decide which comparison to use
					switch (PlayerFilterOperator)
					{
						//less than the entered value
						case 0:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.Steals < PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//entered exact value
						case 1:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.Steals == PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//more than entered value
						case 2:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.Steals > PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//select all players
						default:
							matchedRecords = db.NbaPlayerCareerStats.Select(x =>
							x.PlayerID);
							break;
					}
					break;

				//filter by Blocks
				case 2:
					//decide which comparison to use
					switch (PlayerFilterOperator)
					{
						//less than entered value
						case 0:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.Blocks < PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//entered exact value
						case 1:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.Blocks == PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//more than entered value
						case 2:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.Blocks < PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//select all players
						default:
							matchedRecords = db.NbaPlayerCareerStats.Select(x =>
							x.PlayerID);
							break;
					}
					break;

				//filter by Turnovers
				case 3:
					//decide which comparison to use
					switch (PlayerFilterOperator)
					{
						//less than the entered value
						case 0:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.Turnovers < PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//entered exact value
						case 1:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.Turnovers == PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//more than entered value
						case 2:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.Turnovers > PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//select all players
						default:
							matchedRecords = db.NbaPlayerCareerStats.Select(x => x.PlayerID);
							break;
					}
					break;

				//filter by Total Points
				case 4:
					//decide which comparison to use
					switch (PlayerFilterOperator)
					{
						//less than the entered value
						case 0:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.TotalPoints < PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//Entered exact value
						case 1:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.TotalPoints == PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//more than entered value
						case 2:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.TotalPoints > PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//select all players
						default:
							matchedRecords = db.NbaPlayerCareerStats.Select(x =>
							x.PlayerID);
							break;

					}

					break;
				//Filter by Offensive Rebounds
				case 5:
					//decide which comparison to use
					switch (PlayerFilterOperator)
					{
						//less than the entered value
						case 0:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.OffensiveRebounds < PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//Entered exact value
						case 1:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.OffensiveRebounds == PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//more than entered value
						case 2:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.OffensiveRebounds > PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//select all players
						default:
							matchedRecords = db.NbaPlayerCareerStats.Select(x =>
							x.PlayerID);
							break;

					}

					break;

				//Filter by Defensive Rebounds
				case 6:
					//decide which comparison to use
					switch (PlayerFilterOperator)
					{
						//less than the entered value
						case 0:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.DefensiveRebounds < PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//Entered exact value
						case 1:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.DefensiveRebounds == PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//more than entered value
						case 2:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.DefensiveRebounds > PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//select all players
						default:
							matchedRecords = db.NbaPlayerCareerStats.Select(x =>
							x.PlayerID);
							break;

					}

					break;

				//Filter by Personal Fouls
				case 7:
					//decide which comparison to use
					switch (PlayerFilterOperator)
					{
						//less than the entered value
						case 0:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.PersonalFouls < PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//Entered exact value
						case 1:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.PersonalFouls == PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//more than entered value
						case 2:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.PersonalFouls > PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//select all players
						default:
							matchedRecords = db.NbaPlayerCareerStats.Select(x =>
							x.PlayerID);
							break;

					}

					break;

				//Filter by Three Points
				case 8:
					//decide which comparison to use
					switch (PlayerFilterOperator)
					{
						//less than the entered value
						case 0:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.ThreePoints < PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//Entered exact value
						case 1:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.ThreePoints == PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//more than entered value
						case 2:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.ThreePoints > PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//select all players
						default:
							matchedRecords = db.NbaPlayerCareerStats.Select(x =>
							x.PlayerID);
							break;

					}

					break;

				//Filter by Two Points
				case 9:
					//decide which comparison to use
					switch (PlayerFilterOperator)
					{
						//less than the entered value
						case 0:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.TwoPoints < PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//Entered exact value
						case 1:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.TwoPoints == PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//more than entered value
						case 2:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.TwoPoints > PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//select all players
						default:
							matchedRecords = db.NbaPlayerCareerStats.Select(x =>
							x.PlayerID);
							break;

					}

					break;

				//Filter by Free Throws
				case 10:
					//decide which comparison to use
					switch (PlayerFilterOperator)
					{
						//less than the entered value
						case 0:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.FreeThrows < PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//Entered exact value
						case 1:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.FreeThrows == PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//more than entered value
						case 2:
							matchedRecords = db.NbaPlayerCareerStats.Where(y =>
							y.FreeThrows > PlayerFilterValue).Select(y => y.PlayerID);
							break;
						//select all players
						default:
							matchedRecords = db.NbaPlayerCareerStats.Select(x =>
							x.PlayerID);
							break;

					}

					break;
				default:
					matchedRecords = db.NbaPlayerCareerStats.Select(x =>
					x.PlayerID);
					break;
			}

			//decide whether the sort is ascending or descending
			if (PlayerSortOrder == 0)
			{
				//ascending
				nbaPlayerBindingSource.DataSource = db.NbaPlayers.Where(x =>
				matchedRecords.Contains(x.PlayerID)).ToList() //filter by stats
					.Where(x => x.FirstName.Contains(PlayerSearchTerm)) //search for first and last name
					.OrderBy(x => x.IsActive); //order by ascending active
			}
			else
			{
				//descending
				nbaPlayerBindingSource.DataSource = db.NbaPlayers.Where(x =>
				matchedRecords.Contains(x.PlayerID)).ToList() //filter by stats
					.Where(x => x.FirstName.Contains(PlayerSearchTerm)) //search for first and last name
					.OrderByDescending(x => x.IsActive); //order by descending active
			}
		}

		//Update method of the Team [tab] datasource
		private void UpdateTeamsDataSource()
		{
			//find teams that match the current filter
			IQueryable<int> matchedRecords;
			//decide the field to filter by
			switch (TeamFilterField)
			{
				//Filter by Field Goals
				case 0:
					//decide which comparison to use
					switch (TeamFilterOperator)
					{
						//less than the entered value
						case 0:
							matchedRecords = db.NbaTeamSeasonStats.Where(y =>
							y.FieldGoals < TeamFilterValue).Select(y => y.TeamID);
							break;
						//Entered exact value
						case 1:
							matchedRecords = db.NbaTeamSeasonStats.Where(y =>
							y.FieldGoals == TeamFilterValue).Select(y => y.TeamID);
							break;
						//more than entered value
						case 2:
							matchedRecords = db.NbaTeamSeasonStats.Where(y =>
							y.FieldGoals > TeamFilterValue).Select(y => y.TeamID);
							break;
						//select all teams
						default:
							matchedRecords = db.NbaTeamSeasonStats.Select(x => x.TeamID);
							break;
					}
					break;

				//Filter by Free Throws
				case 1:
					//decide which comparison to use
					switch (TeamFilterOperator)
					{
						//less than the entered value
						case 0:
							matchedRecords = db.NbaTeamSeasonStats.Where(y =>
							y.FreeThrows < TeamFilterValue).Select(y => y.TeamID);
							break;
						//exact entered value
						case 1:
							matchedRecords = db.NbaTeamSeasonStats.Where(y =>
							y.FreeThrows == TeamFilterValue).Select(y => y.TeamID);
							break;
						//more than entered value
						case 2:
							matchedRecords = db.NbaTeamSeasonStats.Where(y =>
							y.FreeThrows > TeamFilterValue).Select(y => y.TeamID);
							break;
						//select all teams
						default:
							matchedRecords = db.NbaTeamSeasonStats.Select(x => x.TeamID);
							break;
					}
					break;

				//Filter by Personal Fouls
				case 2:
					//decide which comparison to use
					switch (TeamFilterOperator)
					{
						//less than the entered value
						case 0:
							matchedRecords = db.NbaTeamSeasonStats.Where(y =>
							y.PersonalFouls < TeamFilterValue).Select(y => y.TeamID);
							break;
						//entered exact value
						case 1:
							matchedRecords = db.NbaTeamSeasonStats.Where(y =>
							y.PersonalFouls == TeamFilterValue).Select(y => y.TeamID);
							break;
						//more than entered value
						case 2:
							matchedRecords = db.NbaTeamSeasonStats.Where(y =>
							y.PersonalFouls > TeamFilterValue).Select(y => y.TeamID);
							break;
						//select all teams
						default:
							matchedRecords = db.NbaTeamSeasonStats.Select(x =>
							x.TeamID);
							break;
					}
					break;

				//Filter by Total Points
				case 3:
					//decide which comparison to use
					switch (TeamFilterOperator)
					{
						//less than the entered value
						case 0:
							matchedRecords = db.NbaTeamSeasonStats.Where(y =>
							y.TotalPoints < TeamFilterValue).Select(y => y.TeamID);
							break;
						//Entered exact value
						case 1:
							matchedRecords = db.NbaTeamSeasonStats.Where(y =>
							y.TotalPoints == TeamFilterValue).Select(y => y.TeamID);
							break;
						//more than the entered value
						case 2:
							matchedRecords = db.NbaTeamSeasonStats.Where(y =>
							y.TotalPoints > TeamFilterValue).Select(y => y.TeamID);
							break;
						//select all teams
						default:
							matchedRecords = db.NbaTeamSeasonStats.Select(x => x.TeamID);
							break;
					}

					//decide whether to sort by acending or descending
					break;
				//select all teams
				default:
					matchedRecords = db.NbaTeamSeasonStats.Select(x => x.TeamID);
					break;
			}
					if (TeamSortOrder == 0)
					{
						nbaTeamBindingSource.DataSource = db.NbaTeams.Where(x =>
						matchedRecords.Contains(x.TeamID)) //filter by stats
							.Where(x => x.TeamName.Contains(TeamSearchTerm))//search for name
							.OrderBy(x => x.TeamName); //order by ascending
					}
					else
					{
						nbaTeamBindingSource.DataSource = db.NbaTeams.Where(x =>
						matchedRecords.Contains(x.TeamID)) //filter by stats
							.Where(x => x.TeamName.Contains(TeamSearchTerm)) //search for name
							.OrderByDescending(x => x.TeamName); //order by descending
					}
					
			}
		

		//Closes the NBA Form
		private void exitButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		
		//Team tab select box
		private void nbaTeamSelectComboBox_SelectedValueChanged(object sender, EventArgs e)
		{
			//get the ID of the selected team
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
				//Set the team's players data source to null
				nbaTeamPlayersBindingSource.DataSource = null;

				//make all team stats say "N/A"
				teamFieldGoals.Text = "N/A";
				teamFreeThrows.Text = "N/A"; ;
				teamPersonalFouls.Text = "N/A";
				teamTotalPoints.Text = "N/A";
				return;
			}


			//select all players on the selected team and add them to the team players data source
			var playerIDs = db.CsgoPlayerTeams.Where(x => x.TeamID == teamID).Select(x => x.PlayerID).ToList();
			nbaTeamPlayersBindingSource.DataSource = db.NbaPlayers.Where(x => playerIDs.Contains(x.PlayerID));

			//select the stats of the selected team
			var stats = db.NbaTeamSeasonStats.Where(x => x.TeamID == teamID)
                .Where(x => x.TeamID == teamID && x.SeasonYear == currentSeason)
                .SingleOrDefault();

			//assign team stats to labels
			if (stats != null)
			{
				teamFieldGoals.Text = stats.FieldGoals.ToString();
				teamFreeThrows.Text = stats.FreeThrows.ToString();
				teamPersonalFouls.Text = stats.PersonalFouls.ToString();
				teamTotalPoints.Text = stats.TotalPoints.ToString();

			}
			else
			{
				teamFieldGoals.Text = "N/A";
				teamFreeThrows.Text = "N/A"; ;
				teamPersonalFouls.Text = "N/A";
				teamTotalPoints.Text = "N/A";
			}

		}

		//Players tab
		private void nbaPlayerSelectComboBox_SelectedValueChanged(object sender, EventArgs e)
		{
			
			//get the ID of the selected team
			int playerID = -1;
			try
			{
				if (nbaPlayerSelectComboBox.SelectedValue != null)
				{
					playerID = Convert.ToInt32(nbaPlayerSelectComboBox.SelectedValue);
				}
			}
			catch
			{ 

				//make all team stats say "N/A"
				playerAssists.Text = "N/A";
				playerSteal.Text = "N/A";
				playerBlocks.Text = "N/A"; ;
				playerTurnOver.Text = "N/A";
				playerTotalPoints.Text = "N/A";
				return;
			}


			
			//select the stats of the selected Players in the player tab
			var stats = db.NbaPlayerCareerStats.Where(x => x.PlayerID == playerID).SingleOrDefault();

			//assign team stats to labels
			if (stats != null)
			{ 
				playerAssists.Text = stats.Assists.ToString();
				playerSteal.Text = stats.Steals.ToString();
				playerBlocks.Text = stats.Blocks.ToString();
				playerTurnOver.Text = stats.Turnovers.ToString();
				playerTotalPoints.Text = stats.TotalPoints.ToString();
				playerFieldGoals.Text = stats.FieldGoals.ToString();
				playerFreeThrow.Text = stats.FreeThrows.ToString();
				playerTwoPoints.Text = stats.TwoPoints.ToString();
				playerThreePoints.Text = stats.ThreePoints.ToString();
				playerOffensiveRebounds.Text = stats.OffensiveRebounds.ToString();
				playerDefensiveRebounds.Text = stats.DefensiveRebounds.ToString() ;
				playerPersonalFouls.Text = stats.PersonalFouls.ToString();

			}
			else
			{
				playerAssists.Text = "N/A";
				playerSteal.Text = "N/A";
				playerBlocks.Text = "N/A"; ;
				playerTurnOver.Text = "N/A";
				playerTotalPoints.Text = "N/A";
				playerFieldGoals.Text = "N/A";
				playerFreeThrow.Text = "N/A";
				playerTwoPoints.Text = "N/A";
				playerThreePoints.Text = "N/A";
				playerOffensiveRebounds.Text = "N/A";
				playerDefensiveRebounds.Text = "N/A";
				playerPersonalFouls.Text = "N/A";
			}
		}
	}
}
