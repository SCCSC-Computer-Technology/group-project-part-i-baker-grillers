using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SportsStatsAPIClient;

namespace Baker_Grillers_Group_Project_Part_I
{
    public partial class MainForm : Form
    {

        SportsAPIService apiService;
        int teamIdTemp = -1; // Just for testing

        public MainForm()
        {
            InitializeComponent();
            apiService = new SportsAPIService();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //load the login form
            LoginForm loginForm = new LoginForm();

            //this decides if the user will have access to everything or not
            if(loginForm.ShowDialog() == DialogResult.OK)
            {
                //placeholder for unlocking features
                loginButton.Visible = false;
            }
            else
            {
                loginButton.Visible = true;
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                //placeholder for unlocking restrictions
                loginButton.Visible = false;
            }
        }

        private async void teamsSearchButton_Click(object sender, EventArgs e)
        {

            playersListBox.Items.Clear();

            // Search for teams
            var team = await apiService.SearchTeam(teamNameTxtBx.Text);

            if (team != null)
            {
                teamNameResultLabel.Text = team.StrTeam;
                stadiumNameResultLabel.Text = team.StrStadium;
                teamIdTemp = int.Parse(team.IdTeam);
                MessageBox.Show($"Loaded team with id: {teamIdTemp}");
            }

            // Load players
            Player[] players = await apiService.GetTeamPlayers(teamIdTemp);

            if (players != null)
            {
                playersListBox.Items.Clear();
                foreach (Player player in players)
                {
                    playersListBox.Items.Add(player.StrPlayer);
                }
            }

        }

    }
}
