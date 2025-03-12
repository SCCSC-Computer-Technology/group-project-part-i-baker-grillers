using Baker_Grillers_Group_Project_Part_I.Controls;
using Baker_Grillers_Group_Project_Part_I.Settings;
using DataManager;
using GroupProjectTesting;
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
using UserAuthentication;

namespace Baker_Grillers_Group_Project_Part_I
{
    public partial class MainForm : Form
    {

        public static SqlConnection conn { get; set; }

        private ContextMenuStrip userContextMenu;
        private ToolStripMenuItem logoutMenuItem;
        private CustomListControl enhancedListView;

        Color buttonHighlightColor = Color.FromArgb(192, 255, 192);
        Color navButtonStandardBackColor = Color.FromArgb(245, 247, 245);
        Color selectColor = Color.FromArgb(19, 94, 57);

        string selectedNav = "teams"; // players, statistics, teams, favorites
        string selectedSport = "csgo"; // csgo, nfl, nba, custom

        bool triggerLogin;
        DataRepository dataRepository;

        public MainForm(bool triggerLogin)
        {
            InitializeComponent();
            InitializeDropDown();
            this.selectedSport = selectedSport;
            this.triggerLogin = triggerLogin;
            dataRepository = new DataRepository(Program.connectionString);

            SettingsUtil.SetFormTheme(this, dataRepository, Program.CurrentSettingsUserEmail);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Begin connection
            conn = new SqlConnection(Program.connectionString);

            if (triggerLogin) Login(true);

            UpdateUserEmailLabel();
            NavigationItemSelected();
            SideBarItemSelected();

            UpdateEnableSports();
            
        }

        public void UpdateSelectedSport(string sport)
        {
            selectedSport = sport;
            NavigationItemSelected();
            SideBarItemSelected();
        }

        private void ShowWelcome()
        {
            WelcomeForm welcomeForm = new WelcomeForm(this);
            welcomeForm.ShowDialog();
        }

        private void Login(bool shouldShowWelcome)
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
            UpdateEnableSports();
            if (shouldShowWelcome)
            {
                ShowWelcome();
            }
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
            SettingsForm settingsForm = new SettingsForm(this);

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

        /**
         * Gets Teams data from the database
         */
        private DataTable LoadTeamsData()
        {
            switch (selectedSport)
            {
                case "csgo":
                    return dataRepository.GetTeamsDataCSGO();
                case "nfl":
                    return dataRepository.GetTeamsDataNFL();
                case "nba":
                    return dataRepository.GetTeamsDataNBA();
                default:
                    return null;
            }
        }

        private DataTable LoadPlayersData()
        {
            switch (selectedSport)
            {
                case "csgo":
                    return dataRepository.GetPlayersDataCSGO();
                case "nfl":
                    return dataRepository.GetPlayersDataNFL();
                case "nba":
                    return dataRepository.GetPlayersDataNBA();
                default:
                    return null;
            }
        }

        // Updates the background colors for the currently selected nav button
        public void NavigationItemSelected()
        {
            contentPanel.Controls.Clear();
            if (selectedNav.Equals("teams"))
            {
                teamsNavButton.BackColor = buttonHighlightColor;
                teamsNavButton.IsSelected = true;
                // Change active panel
                enhancedListView = new CustomListControl();
                enhancedListView.SetData(LoadTeamsData(), selectedSport);
                enhancedListView.ItemSelected += CustomList_ItemSelected;
                enhancedListView.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(enhancedListView);
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
                // Change active panel
                enhancedListView = new CustomListControl();
                enhancedListView.SetData(LoadPlayersData(), selectedSport);
                enhancedListView.ItemSelected += CustomList_ItemSelected;
                enhancedListView.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(enhancedListView);
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
            /*if (selectedNav.Equals("favorites"))
            {
                favoritesNavButton.BackColor = buttonHighlightColor;
                favoritesNavButton.IsSelected = true;
            }
            else
            {
                favoritesNavButton.BackColor = navButtonStandardBackColor;
                favoritesNavButton.IsSelected = false;
            }*/

        }

        // Launches applicable stats forms
        private void CustomList_ItemSelected(object sender, ItemSelectedEventArgs e)
        {
            if (selectedSport.Equals("csgo"))
            {
                if (selectedNav.Equals("players"))
                {
                    CSGOForm csgoForm = new CSGOForm(null, e.ItemId); // Open players stats form
                    csgoForm.Show();
                } else if (selectedNav.Equals("teams"))
                {
                    CSGOForm csgoForm = new CSGOForm(e.ItemId, null); // Open teams stats form
                    csgoForm.Show();
                }
            }
            else if (selectedSport.Equals("nfl"))
            {
                if (selectedNav.Equals("players"))
                {
                    NFLForm nflForm = new NFLForm(null, e.ItemId); // Open players stats form
                    nflForm.Show();
                }
                else if (selectedNav.Equals("teams"))
                {
                    NFLForm nflForm = new NFLForm(e.ItemId, null); // Open teams stats form
                    nflForm.Show();
                }
            }
        }

        // Updates the background colors for the currently selected sidebar button
        public void SideBarItemSelected()
        {
            csgoSideBarButton.ApplyImageColor = true;
            nflSideBarButton.ApplyImageColor = true;
            nbaSideBarButton.ApplyImageColor = true;
            //customSideBarButton.ApplyImageColor = true;
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
            /*if (selectedSport.Equals("custom"))
            {
                customSideBarButton.IsSelected = true;
                customSideBarButton.ImageColor = Color.White;
            }
            else
            {
                customSideBarButton.IsSelected = false;
                customSideBarButton.ImageColor = selectColor;
            }*/
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
            //NBAForm NBAForm = new NBAForm();
            //NBAForm.ShowDialog();
        }

        private void favoritesNavButton_Click(object sender, EventArgs e)
        {
            //selectedNav = "favorites";
            //NavigationItemSelected();


            // Testing

            //CSGOForm csgoForm = new CSGOForm();
            //csgoForm.ShowDialog();
            NBAForm nBAForm = new NBAForm();
            nBAForm.ShowDialog();
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
                Login(false);
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

        public void UpdateEnableSports()
        {
            string enabledSports = dataRepository.GetGlobalSettings(Program.CurrentSettingsUserEmail).EnabledSports;
            if (enabledSports.Contains("CSGO"))
            {
                csgoSideBarButton.Visible = true;
            }
            else
            {
                csgoSideBarButton.Visible = false;
            }
            if (enabledSports.Contains("Football"))
            {
                nflSideBarButton.Visible = true;
            }
            else
            {
                nflSideBarButton.Visible = false;
            }
            if (enabledSports.Contains("Basketball"))
            {
                nbaSideBarButton.Visible = true;
            }
            else
            {
                nbaSideBarButton.Visible = false;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void nameLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
