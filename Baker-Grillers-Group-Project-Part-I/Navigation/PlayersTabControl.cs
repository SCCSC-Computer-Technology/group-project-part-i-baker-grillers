using DataManager;
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

namespace Baker_Grillers_Group_Project_Part_I.Navigation
{
    public partial class PlayersTabControl : UserControl
    {
        private string connectionString;
        private string currentSport = "csgo"; // Default
        private DataRepository dataRepository;

        public PlayersTabControl(string connectionString, string sport)
        {
            InitializeComponent();

            // Initialize data repository
            dataRepository = new DataRepository(Program.credentialsConnection);

            this.connectionString = connectionString;
            this.currentSport = sport;

            LoadPlayerData();
        }

        public void UpdateSport(string sport)
        {
            currentSport = sport;
            LoadPlayerData();
        }

        private void LoadPlayerData()
        {
            switch (currentSport)
            {
                case "csgo":
                    LoadPlayersCSGO();
                    break;
                case "nfl":
                    LoadPlayersNFL();
                    break;
                case "nba":
                    LoadPlayersNBA();
                    break;
            }
        }

        private void LoadPlayersCSGO()
        {
            try
            {
                playersGridView.DataSource = dataRepository.GetPlayersDataCSGO();
                FormatDataCSGO();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading CSGO players - {ex.Message}");
            }
        }

        private void FormatDataCSGO()
        {
            if (playersGridView.Columns.Count > 0)
            {
                playersGridView.Columns["PlayerID"].Visible = false;
                playersGridView.Columns["PlayerName"].HeaderText = "Player";
                playersGridView.Columns["TeamName"].HeaderText = "Team";
                playersGridView.Columns["KdDiff"].HeaderText = "K/D Diff";
                playersGridView.Columns["Kd"].HeaderText = "K/D Ratio";
                playersGridView.Columns["Rating"].HeaderText = "Rating";
                playersGridView.Columns["TotalMaps"].HeaderText = "Maps Played";
                playersGridView.Columns["TotalRounds"].HeaderText = "Rounds Played";


                playersGridView.Columns["Kd"].DefaultCellStyle.Format = "F2";
                playersGridView.Columns["Rating"].DefaultCellStyle.Format = "F2";
            }
        }

        private void LoadPlayersNFL()
        {
            try
            {
                playersGridView.DataSource = dataRepository.GetPlayersDataNFL();
                FormatDataGridViewNFL();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading NFL players: {ex.Message}");
            }
        }

        private void FormatDataGridViewNFL()
        {
            playersGridView.Columns["PlayerID"].Visible = false;
            playersGridView.Columns["PlayerName"].HeaderText = "Player";
            playersGridView.Columns["TeamName"].HeaderText = "Team";
        }

        private void LoadPlayersNBA()
        {
            try
            {
                playersGridView.DataSource = dataRepository.GetPlayersDataNBA();
                FormatDataGridViewNBA();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading NBA players: {ex.Message}");
            }
        }

        private void FormatDataGridViewNBA()
        {
            playersGridView.Columns["PlayerID"].Visible = false;
            playersGridView.Columns["PlayerName"].HeaderText = "Player";
            playersGridView.Columns["TeamName"].HeaderText = "Team";
        }

        private void playersGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
