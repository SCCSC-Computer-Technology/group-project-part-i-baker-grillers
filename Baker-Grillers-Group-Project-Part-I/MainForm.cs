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
    public partial class MainForm : Form
    {

        private ContextMenuStrip userContextMenu;
        private ToolStripMenuItem logoutMenuItem;

        Color buttonHighlightColor = Color.FromArgb(191, 228, 254);
        Color buttonDefaultColor = Color.White;

        string selectedNav = "players"; // players, statistics, teams, favorites
        string selectedSport = "csgo"; // csgo, nfl, nba, custom

        public MainForm()
        {
            InitializeComponent();
            InitializeDropDown();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Login();

            UpdateUserEmailLabel();

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login()
        {
            //load the login form
            LoginForm loginForm = new LoginForm();

            //this decides if the user will have access to everything or not
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                //placeholder for unlocking features
                loginButton.Visible = false;
            }
            else
            {
                loginButton.Visible = true;
            }
            UpdateUserEmailLabel();
        }

        // Perform logout
        public void Logout()
        {
            Program.CurrentSettingsUserEmail = "guest@local.app";
            loginButton.Visible = true;
            UpdateUserEmailLabel();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                //placeholder for unlocking restrictions
                loginButton.Visible = false;
                UpdateUserEmailLabel();
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();

            settingsForm.ShowDialog();

        }

        // Updates the user email label
        public void UpdateUserEmailLabel()
        {
            // Get stored current user email
            string currentUserEmail = Program.CurrentSettingsUserEmail;

            // Check if user is a guest
            if (currentUserEmail.Equals("guest@local.app"))
                currentUserEmail = "Guest";

            userEmailLabel.Text = currentUserEmail;
        }

        // Updates the background colors for the currently selected nav button
        public void NavigationItemSelected()
        {
            if (selectedNav.Equals("players"))
            {
                playersNavButton.BackColor = buttonHighlightColor;
                // TODO: Change panel
            } else
            {
                playersNavButton.BackColor = Color.White;
            }
            if (selectedNav.Equals("teams"))
            {
                teamsNavButton.BackColor = buttonHighlightColor;
                // TODO: Change panel
            }
            else
            {
                teamsNavButton.BackColor = Color.White;
                // TODO: Change panel
            }
            if (selectedNav.Equals("statistics"))
            {
                statisticsNavButton.BackColor = buttonHighlightColor;
            }
            else
            {
                statisticsNavButton.BackColor = Color.White;
            }
            if (selectedNav.Equals("favorites"))
            {
                favoritesNavButton.BackColor = buttonHighlightColor;
                // TODO: Change panel
            }
            else
            {
                favoritesNavButton.BackColor = Color.White;
            }
        }

        // Updates the background colors for the currently selected sidebar button
        public void SideBarItemSelected()
        {
            if (selectedSport.Equals("csgo"))
            {
                csgoSideBarButton.BackColor = buttonHighlightColor;
                // TODO: Change panel
            }
            else
            {
                csgoSideBarButton.BackColor = buttonDefaultColor;
            }
            if (selectedSport.Equals("nfl"))
            {
                nflSideBarButton.BackColor = buttonHighlightColor;
            }
            else
            {
                nflSideBarButton.BackColor = buttonDefaultColor;
            }
            if (selectedSport.Equals("nba"))
            {
                nbaSideBarButton.BackColor = buttonHighlightColor;
                // TODO: Change panel
            }
            else
            {
                nbaSideBarButton.BackColor = buttonDefaultColor;
            }
            if (selectedSport.Equals("custom"))
            {
                customSideBarButton.BackColor = buttonHighlightColor;
                // TODO: Change panel
            }
            else
            {
                customSideBarButton.BackColor = buttonDefaultColor;
            }
        }

        // <<< Side Bar Button Click Listeners >>>

        private void csgoSideBarButton_Click(object sender, EventArgs e)
        {
            selectedSport = "csgo";
            SideBarItemSelected();
        }

        private void nflSideBarButton_Click(object sender, EventArgs e)
        {
            selectedSport = "nfl";
            SideBarItemSelected();
        }

        private void nbaSideBarButton_Click(object sender, EventArgs e)
        {
            selectedSport = "nba";
            SideBarItemSelected();
        }

        private void customSideBarButton_Click(object sender, EventArgs e)
        {
            selectedSport = "custom";
            SideBarItemSelected();
        }

        // <<< Nav/Top Bar Button Click Listeners >>>

        private void teamsNavButton_Click(object sender, EventArgs e)
        {
            selectedNav = "teams";
            NavigationItemSelected();
        }

        private void playersNavButton_Click(object sender, EventArgs e)
        {
            selectedNav = "players";
            NavigationItemSelected();
        }

        private void statisticsNavButton_Click(object sender, EventArgs e)
        {
            selectedNav = "statistics";
            NavigationItemSelected();
        }

        private void favoritesTabButton_Click(object sender, EventArgs e)
        {
            selectedNav = "favorites";
            NavigationItemSelected();
        }

        private void InitializeDropDown()
        {
            // Create a context menu instead of a dropdown button
            userContextMenu = new ContextMenuStrip();

            int menuWidth = 200;

            // Add menu items to the context menu
            logoutMenuItem = new ToolStripMenuItem("Logout");
            logoutMenuItem.Width = menuWidth;

            logoutMenuItem.Click += LoginLogoutMenuItem;

            // Add items to context menu
            userContextMenu.Items.Add(logoutMenuItem);

            // Change width of menu
            userContextMenu.AutoSize = false;
            userContextMenu.Width = menuWidth;
            userContextMenu.Height = 25;

            // Make email label look clickable
            userEmailLabel.Cursor = Cursors.Hand;
            dropdownLabel.Cursor = Cursors.Hand;
        }

        private void LoginLogoutMenuItem(object sender, EventArgs e)
        {

            if (Program.CurrentSettingsUserEmail.Equals("guest@local.app")) // User is a guest
            {
                Login();
            }
            else
            {
                Logout();
                MessageBox.Show("You have been logged out.");
                // Restart the application entirely
                Application.Restart();
            }

        }

        public void ShowUserContextMenu()
        {
            if (Program.CurrentSettingsUserEmail.Equals("guest@local.app"))
            {
                logoutMenuItem.Text = "Login";
            }
            else
            {
                logoutMenuItem.Text = "Logout";
            }
            userContextMenu.Show(userEmailLabel, new Point(0, (int)(userEmailLabel.Height / 1.5)));
        }

        private void userEmailLabel_Click(object sender, EventArgs e)
        {
            ShowUserContextMenu();
        }

        private void dropdownLabel_Click(object sender, EventArgs e)
        {
            ShowUserContextMenu();
        }

        private void sportsSettingsButton_Click(object sender, EventArgs e)
        {
            SportPreferencesForm sportPreferencesForm = new SportPreferencesForm(selectedSport);
            sportPreferencesForm.ShowDialog();
        }

    }
}
