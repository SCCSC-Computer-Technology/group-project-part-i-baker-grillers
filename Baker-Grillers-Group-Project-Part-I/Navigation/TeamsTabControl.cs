using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataManager;

namespace Baker_Grillers_Group_Project_Part_I.Navigation
{
    public partial class TeamsTabControl : UserControl
    {
        private string connectionString;
        private string currentSport = "csgo"; // Default
        private DataRepository dataRepository;
        public TeamsTabControl(string connectionString, string sport)
        {
            InitializeComponent();

            // Initialize data repository
            dataRepository = new DataRepository(Program.credentialsConnection);

            this.connectionString = connectionString;
            this.currentSport = sport;

            LoadTeamData();
        }

        private void LoadTeamData()
        {
            switch (currentSport)
            {
                case "csgo":
                    LoadTeamsCSGO();
                    break;
                case "nfl":
                    LoadTeamsNFL();
                    break;
                case "nba":
                    LoadNbaTeams();
                    break;
            }
        }

        private void LoadTeamsCSGO()
        {
            try
            {
                teamsGridView.DataSource = dataRepository.GetTeamDataCSGO();
                FormatDataCSGO();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading CSGO teams: {ex.Message}");
            }
        }

        private void FormatDataCSGO()
        {
            if (teamsGridView.Columns.Count > 0)
            {
                teamsGridView.Columns["TeamID"].Visible = false;
                teamsGridView.Columns["TeamName"].HeaderText = "Team";
                teamsGridView.Columns["TotalMaps"].HeaderText = "Maps Played";
                teamsGridView.Columns["KdDiff"].HeaderText = "K/D Diff";
                teamsGridView.Columns["Kd"].HeaderText = "K/D Ratio";
                teamsGridView.Columns["Rating"].HeaderText = "Rating";

                teamsGridView.Columns["Kd"].DefaultCellStyle.Format = "F2";
                teamsGridView.Columns["Rating"].DefaultCellStyle.Format = "F2";
            }
        }

        private void LoadTeamsNFL()
        {
            try
            {
                teamsGridView.DataSource = dataRepository.GetTeamsDataNFL();
                FormatDataNFL();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading NFL teams: {ex.Message}");
            }
        }

        private void FormatDataNFL()
        {
            if (teamsGridView.Columns.Count > 0)
            {
                teamsGridView.Columns["TeamID"].Visible = false;
                teamsGridView.Columns["TeamName"].HeaderText = "Team";
                teamsGridView.Columns["WinPercentage"].HeaderText = "Win %";
                teamsGridView.Columns["TotalTD"].HeaderText = "Total TDs";

                teamsGridView.Columns["WinPercentage"].DefaultCellStyle.Format = "P2";
            }
        }

        private void LoadNbaTeams()
        {
            try
            {
                teamsGridView.DataSource = dataRepository.GetTeamsDataNBA();
                FormatDataNBA();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading NBA teams: {ex.Message}");
            }
        }

        private void FormatDataNBA()
        {
            if (teamsGridView.Columns.Count > 0)
            {
                teamsGridView.Columns["TeamID"].Visible = false;
                teamsGridView.Columns["TeamName"].HeaderText = "Team";
                teamsGridView.Columns["TeamAbbr"].HeaderText = "Abbr.";
                teamsGridView.Columns["TotalPoints"].HeaderText = "Points";
                teamsGridView.Columns["FGPercentage"].HeaderText = "Field Goal %";
                teamsGridView.Columns["ThreePtPercentage"].HeaderText = "3 Point %";
                teamsGridView.Columns["TotalRebounds"].HeaderText = "Rebounds";

                teamsGridView.Columns["FGPercentage"].DefaultCellStyle.Format = "P1";
                teamsGridView.Columns["ThreePtPercentage"].DefaultCellStyle.Format = "P1";
            }
        }

    }
}
