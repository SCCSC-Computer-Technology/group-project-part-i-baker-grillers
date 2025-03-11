using Baker_Grillers_Group_Project_Part_I.Navigation;
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

        Color buttonHighlightColor = Color.FromArgb(192, 255, 192);
        Color navButtonStandardBackColor = Color.FromArgb(245, 247, 245);
        Color buttonDefaultColor = Color.White;

        string selectedNav = "teams"; // players, statistics, teams, favorites
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
            NavigationItemSelected();

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
            contentPanel.Controls.Clear();
            if (selectedNav.Equals("teams"))
            {
                teamsNavButton.BackColor = buttonHighlightColor;
                teamsNavButton.IsSelected = true;

                // Change panel
                TeamsTabControl teamsTabControl = new TeamsTabControl(Program.credentialsConnection, selectedSport);
                contentPanel.Controls.Add(teamsTabControl);
            }
            else
            {
                teamsNavButton.BackColor = navButtonStandardBackColor;
                teamsNavButton.IsSelected = false;
            }
            if (selectedNav.Equals("players"))
            {
                playersNavButton.BackColor = buttonHighlightColor;
                playersNavButton.IsSelected = true;
                // Change panel
                PlayersTabControl playersTabControl = new PlayersTabControl(Program.credentialsConnection, selectedSport);
                contentPanel.Controls.Add(playersTabControl);
            } else
            {
                playersNavButton.BackColor = navButtonStandardBackColor;
                playersNavButton.IsSelected = false;
            }

            if (selectedNav.Equals("statistics"))
            {
                statisticsNavButton.BackColor = buttonHighlightColor;
                statisticsNavButton.IsSelected = true;
            }
            else
            {
                statisticsNavButton.BackColor = navButtonStandardBackColor;
                statisticsNavButton.IsSelected = false;
            }
            if (selectedNav.Equals("favorites"))
            {
                favoritesNavButton.BackColor = buttonHighlightColor;
                favoritesNavButton.IsSelected = true;
                // TODO: Change panel
            }
            else
            {
                favoritesNavButton.BackColor = navButtonStandardBackColor;
                favoritesNavButton.IsSelected = false;
            }
        }

        Color selectColor = Color.FromArgb(19, 94, 57);

        // Updates the background colors for the currently selected sidebar button
        public void SideBarItemSelected()
        {
            csgoSideBarButton.ApplyImageColor = true;
            nflSideBarButton.ApplyImageColor = true;
            nbaSideBarButton.ApplyImageColor = true;
            customSideBarButton.ApplyImageColor = true;
            if (selectedSport.Equals("csgo"))
            {
                csgoSideBarButton.IsSelected = true;
                csgoSideBarButton.ImageColor = Color.White;

            }
            else
            {
                csgoSideBarButton.IsSelected = false;
                csgoSideBarButton.ImageColor = selectColor;

            }
            if (selectedSport.Equals("nfl"))
            {
                nflSideBarButton.IsSelected = true;
                nflSideBarButton.ImageColor = Color.White;
            }
            else
            {
                nflSideBarButton.IsSelected = false;
                nflSideBarButton.ImageColor = selectColor;
            }
            if (selectedSport.Equals("nba"))
            {
                nbaSideBarButton.IsSelected = true;
                nbaSideBarButton.ImageColor = Color.White;
            }
            else
            {
                nbaSideBarButton.IsSelected = false;
                nbaSideBarButton.ImageColor = selectColor;
            }
            if (selectedSport.Equals("custom"))
            {
                customSideBarButton.IsSelected = true;
                customSideBarButton.ImageColor = Color.White;
            }
            else
            {
                customSideBarButton.IsSelected = false;
                customSideBarButton.ImageColor = selectColor;
            }
            selectedSportLabel.Text = GetSportsLabel();
        }

        // <<< Side Bar Button Click Listeners >>>

        private void csgoSideBarButton_Click(object sender, EventArgs e)
        {
            selectedSport = "csgo";
            SideBarItemSelected();
            NavigationItemSelected();
        }

        private void nflSideBarButton_Click(object sender, EventArgs e)
        {
            selectedSport = "nfl";
            SideBarItemSelected();
            NavigationItemSelected();
        }

        private void nbaSideBarButton_Click(object sender, EventArgs e)
        {
            selectedSport = "nba";
            SideBarItemSelected();
            NavigationItemSelected();
        }

        private void customSideBarButton_Click(object sender, EventArgs e)
        {
            selectedSport = "custom";
            SideBarItemSelected();
            NavigationItemSelected();
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

        private void favoritesNavButton_Click(object sender, EventArgs e)
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
            userContextMenu.Show(userEmailLabel, new Point(100, (int)(userEmailLabel.Height / 1.5)));
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

        private string GetSportsLabel()
        {
            if (selectedSport.Equals("nfl")) return "NFL";
            if (selectedSport.Equals("nba")) return "NBA";
            if (selectedSport.Equals("custom")) return "Custom";
            return "CS:GO"; // default
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
