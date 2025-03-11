namespace Baker_Grillers_Group_Project_Part_I
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.topPanel = new System.Windows.Forms.Panel();
            this.dropdownLabel = new System.Windows.Forms.Label();
            this.userEmailLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.customSideBarButton = new Baker_Grillers_Group_Project_Part_I.CustomElements.RoundedButton();
            this.nbaSideBarButton = new Baker_Grillers_Group_Project_Part_I.CustomElements.RoundedButton();
            this.nflSideBarButton = new Baker_Grillers_Group_Project_Part_I.CustomElements.RoundedButton();
            this.csgoSideBarButton = new Baker_Grillers_Group_Project_Part_I.CustomElements.RoundedButton();
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.sportsSettingsButton = new System.Windows.Forms.Button();
            this.globalSettingsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.navigationPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.favoritesNavButton = new Baker_Grillers_Group_Project_Part_I.CustomElements.RoundedButton();
            this.statisticsNavButton = new Baker_Grillers_Group_Project_Part_I.CustomElements.RoundedButton();
            this.playersNavButton = new Baker_Grillers_Group_Project_Part_I.CustomElements.RoundedButton();
            this.teamsNavButton = new Baker_Grillers_Group_Project_Part_I.CustomElements.RoundedButton();
            this.selectedSportLabel = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.logoutButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.topPanel.SuspendLayout();
            this.sidebarPanel.SuspendLayout();
            this.settingsPanel.SuspendLayout();
            this.navigationPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topPanel.BackColor = System.Drawing.Color.SeaGreen;
            this.topPanel.Controls.Add(this.dropdownLabel);
            this.topPanel.Controls.Add(this.userEmailLabel);
            this.topPanel.Controls.Add(this.nameLabel);
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1155, 90);
            this.topPanel.TabIndex = 3;
            // 
            // dropdownLabel
            // 
            this.dropdownLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dropdownLabel.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.dropdownLabel.ForeColor = System.Drawing.Color.White;
            this.dropdownLabel.Location = new System.Drawing.Point(1095, 0);
            this.dropdownLabel.Name = "dropdownLabel";
            this.dropdownLabel.Size = new System.Drawing.Size(32, 90);
            this.dropdownLabel.TabIndex = 2;
            this.dropdownLabel.Text = "▼";
            this.dropdownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dropdownLabel.Click += new System.EventHandler(this.dropdownLabel_Click);
            // 
            // userEmailLabel
            // 
            this.userEmailLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userEmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.userEmailLabel.ForeColor = System.Drawing.Color.White;
            this.userEmailLabel.Location = new System.Drawing.Point(819, 0);
            this.userEmailLabel.Name = "userEmailLabel";
            this.userEmailLabel.Size = new System.Drawing.Size(270, 90);
            this.userEmailLabel.TabIndex = 1;
            this.userEmailLabel.Text = "admin@sccsc.edu";
            this.userEmailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.userEmailLabel.Click += new System.EventHandler(this.userEmailLabel_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.nameLabel.ForeColor = System.Drawing.Color.White;
            this.nameLabel.Location = new System.Drawing.Point(32, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(350, 90);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "BG Sports Statistics";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sidebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.sidebarPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sidebarPanel.Controls.Add(this.customSideBarButton);
            this.sidebarPanel.Controls.Add(this.nbaSideBarButton);
            this.sidebarPanel.Controls.Add(this.nflSideBarButton);
            this.sidebarPanel.Controls.Add(this.csgoSideBarButton);
            this.sidebarPanel.Controls.Add(this.settingsPanel);
            this.sidebarPanel.Controls.Add(this.label1);
            this.sidebarPanel.Location = new System.Drawing.Point(0, 89);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(250, 601);
            this.sidebarPanel.TabIndex = 4;
            // 
            // customSideBarButton
            // 
            this.customSideBarButton.ApplyImageColor = false;
            this.customSideBarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(235)))));
            this.customSideBarButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(148)))), ((int)(((byte)(83)))));
            this.customSideBarButton.BorderSize = 2;
            this.customSideBarButton.CornerRadius = 14;
            this.customSideBarButton.FlatAppearance.BorderSize = 0;
            this.customSideBarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customSideBarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.customSideBarButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(94)))), ((int)(((byte)(57)))));
            this.customSideBarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.customSideBarButton.ImageColor = System.Drawing.Color.White;
            this.customSideBarButton.ImagePadding = 5;
            this.customSideBarButton.ImageSize = new System.Drawing.Size(24, 24);
            this.customSideBarButton.IsSelected = false;
            this.customSideBarButton.Location = new System.Drawing.Point(11, 277);
            this.customSideBarButton.Name = "customSideBarButton";
            this.customSideBarButton.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.customSideBarButton.SelectedForeColor = System.Drawing.Color.White;
            this.customSideBarButton.SelectedImageColor = System.Drawing.Color.White;
            this.customSideBarButton.Size = new System.Drawing.Size(226, 62);
            this.customSideBarButton.TabIndex = 12;
            this.customSideBarButton.Text = "Custom";
            this.customSideBarButton.UseVisualStyleBackColor = false;
            this.customSideBarButton.Click += new System.EventHandler(this.customSideBarButton_Click);
            // 
            // nbaSideBarButton
            // 
            this.nbaSideBarButton.ApplyImageColor = true;
            this.nbaSideBarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(235)))));
            this.nbaSideBarButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(148)))), ((int)(((byte)(83)))));
            this.nbaSideBarButton.BorderSize = 2;
            this.nbaSideBarButton.CornerRadius = 14;
            this.nbaSideBarButton.FlatAppearance.BorderSize = 0;
            this.nbaSideBarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nbaSideBarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.nbaSideBarButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(94)))), ((int)(((byte)(57)))));
            this.nbaSideBarButton.Image = global::Baker_Grillers_Group_Project_Part_I.Properties.Resources.basketball;
            this.nbaSideBarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nbaSideBarButton.ImageColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(94)))), ((int)(((byte)(57)))));
            this.nbaSideBarButton.ImagePadding = 5;
            this.nbaSideBarButton.ImageSize = new System.Drawing.Size(24, 24);
            this.nbaSideBarButton.IsSelected = false;
            this.nbaSideBarButton.Location = new System.Drawing.Point(9, 209);
            this.nbaSideBarButton.Name = "nbaSideBarButton";
            this.nbaSideBarButton.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.nbaSideBarButton.SelectedForeColor = System.Drawing.Color.White;
            this.nbaSideBarButton.SelectedImageColor = System.Drawing.Color.White;
            this.nbaSideBarButton.Size = new System.Drawing.Size(226, 62);
            this.nbaSideBarButton.TabIndex = 11;
            this.nbaSideBarButton.Text = "NBA";
            this.nbaSideBarButton.UseVisualStyleBackColor = false;
            this.nbaSideBarButton.Click += new System.EventHandler(this.nbaSideBarButton_Click);
            // 
            // nflSideBarButton
            // 
            this.nflSideBarButton.ApplyImageColor = true;
            this.nflSideBarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(235)))));
            this.nflSideBarButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(148)))), ((int)(((byte)(83)))));
            this.nflSideBarButton.BorderSize = 2;
            this.nflSideBarButton.CornerRadius = 14;
            this.nflSideBarButton.FlatAppearance.BorderSize = 0;
            this.nflSideBarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nflSideBarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.nflSideBarButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(94)))), ((int)(((byte)(57)))));
            this.nflSideBarButton.Image = global::Baker_Grillers_Group_Project_Part_I.Properties.Resources.football;
            this.nflSideBarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nflSideBarButton.ImageColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(94)))), ((int)(((byte)(57)))));
            this.nflSideBarButton.ImagePadding = 5;
            this.nflSideBarButton.ImageSize = new System.Drawing.Size(24, 24);
            this.nflSideBarButton.IsSelected = false;
            this.nflSideBarButton.Location = new System.Drawing.Point(11, 142);
            this.nflSideBarButton.Name = "nflSideBarButton";
            this.nflSideBarButton.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.nflSideBarButton.SelectedForeColor = System.Drawing.Color.White;
            this.nflSideBarButton.SelectedImageColor = System.Drawing.Color.White;
            this.nflSideBarButton.Size = new System.Drawing.Size(226, 62);
            this.nflSideBarButton.TabIndex = 10;
            this.nflSideBarButton.Text = "NFL";
            this.nflSideBarButton.UseVisualStyleBackColor = false;
            this.nflSideBarButton.Click += new System.EventHandler(this.nflSideBarButton_Click);
            // 
            // csgoSideBarButton
            // 
            this.csgoSideBarButton.ApplyImageColor = false;
            this.csgoSideBarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(235)))));
            this.csgoSideBarButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(148)))), ((int)(((byte)(83)))));
            this.csgoSideBarButton.BorderSize = 2;
            this.csgoSideBarButton.CornerRadius = 14;
            this.csgoSideBarButton.FlatAppearance.BorderSize = 0;
            this.csgoSideBarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.csgoSideBarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.csgoSideBarButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(94)))), ((int)(((byte)(57)))));
            this.csgoSideBarButton.Image = global::Baker_Grillers_Group_Project_Part_I.Properties.Resources.pistol_white;
            this.csgoSideBarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.csgoSideBarButton.ImageColor = System.Drawing.Color.White;
            this.csgoSideBarButton.ImagePadding = 5;
            this.csgoSideBarButton.ImageSize = new System.Drawing.Size(24, 24);
            this.csgoSideBarButton.IsSelected = true;
            this.csgoSideBarButton.Location = new System.Drawing.Point(11, 74);
            this.csgoSideBarButton.Name = "csgoSideBarButton";
            this.csgoSideBarButton.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.csgoSideBarButton.SelectedForeColor = System.Drawing.Color.White;
            this.csgoSideBarButton.SelectedImageColor = System.Drawing.Color.White;
            this.csgoSideBarButton.Size = new System.Drawing.Size(226, 62);
            this.csgoSideBarButton.TabIndex = 1;
            this.csgoSideBarButton.Text = "CS:GO";
            this.csgoSideBarButton.UseVisualStyleBackColor = false;
            this.csgoSideBarButton.Click += new System.EventHandler(this.csgoSideBarButton_Click);
            // 
            // settingsPanel
            // 
            this.settingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.settingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.settingsPanel.Controls.Add(this.sportsSettingsButton);
            this.settingsPanel.Controls.Add(this.globalSettingsButton);
            this.settingsPanel.Location = new System.Drawing.Point(-2, 478);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(252, 122);
            this.settingsPanel.TabIndex = 9;
            // 
            // sportsSettingsButton
            // 
            this.sportsSettingsButton.Location = new System.Drawing.Point(12, 8);
            this.sportsSettingsButton.Name = "sportsSettingsButton";
            this.sportsSettingsButton.Size = new System.Drawing.Size(224, 47);
            this.sportsSettingsButton.TabIndex = 6;
            this.sportsSettingsButton.Text = "Sport Preferences";
            this.sportsSettingsButton.UseVisualStyleBackColor = true;
            this.sportsSettingsButton.Click += new System.EventHandler(this.sportsSettingsButton_Click);
            // 
            // globalSettingsButton
            // 
            this.globalSettingsButton.Location = new System.Drawing.Point(12, 61);
            this.globalSettingsButton.Name = "globalSettingsButton";
            this.globalSettingsButton.Size = new System.Drawing.Size(224, 47);
            this.globalSettingsButton.TabIndex = 2;
            this.globalSettingsButton.Text = "Global Settings";
            this.globalSettingsButton.UseVisualStyleBackColor = true;
            this.globalSettingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(17, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 72);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sports";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // navigationPanel
            // 
            this.navigationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.navigationPanel.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.navigationPanel.Controls.Add(this.panel1);
            this.navigationPanel.Controls.Add(this.selectedSportLabel);
            this.navigationPanel.Location = new System.Drawing.Point(250, 90);
            this.navigationPanel.Name = "navigationPanel";
            this.navigationPanel.Size = new System.Drawing.Size(904, 70);
            this.navigationPanel.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.favoritesNavButton);
            this.panel1.Controls.Add(this.statisticsNavButton);
            this.panel1.Controls.Add(this.playersNavButton);
            this.panel1.Controls.Add(this.teamsNavButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(233, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(671, 70);
            this.panel1.TabIndex = 4;
            // 
            // favoritesNavButton
            // 
            this.favoritesNavButton.ApplyImageColor = false;
            this.favoritesNavButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(245)))));
            this.favoritesNavButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(114)))), ((int)(((byte)(77)))));
            this.favoritesNavButton.BorderSize = 2;
            this.favoritesNavButton.CornerRadius = 14;
            this.favoritesNavButton.FlatAppearance.BorderSize = 0;
            this.favoritesNavButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.favoritesNavButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.favoritesNavButton.ForeColor = System.Drawing.Color.Black;
            this.favoritesNavButton.Image = global::Baker_Grillers_Group_Project_Part_I.Properties.Resources.star1;
            this.favoritesNavButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.favoritesNavButton.ImageColor = System.Drawing.Color.Black;
            this.favoritesNavButton.ImagePadding = 5;
            this.favoritesNavButton.ImageSize = new System.Drawing.Size(24, 24);
            this.favoritesNavButton.IsSelected = false;
            this.favoritesNavButton.Location = new System.Drawing.Point(523, 5);
            this.favoritesNavButton.Name = "favoritesNavButton";
            this.favoritesNavButton.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.favoritesNavButton.SelectedForeColor = System.Drawing.Color.Black;
            this.favoritesNavButton.SelectedImageColor = System.Drawing.Color.White;
            this.favoritesNavButton.Size = new System.Drawing.Size(139, 61);
            this.favoritesNavButton.TabIndex = 16;
            this.favoritesNavButton.Text = "Favorites";
            this.favoritesNavButton.UseVisualStyleBackColor = false;
            this.favoritesNavButton.Click += new System.EventHandler(this.favoritesNavButton_Click);
            // 
            // statisticsNavButton
            // 
            this.statisticsNavButton.ApplyImageColor = false;
            this.statisticsNavButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(245)))));
            this.statisticsNavButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(114)))), ((int)(((byte)(77)))));
            this.statisticsNavButton.BorderSize = 2;
            this.statisticsNavButton.CornerRadius = 14;
            this.statisticsNavButton.FlatAppearance.BorderSize = 0;
            this.statisticsNavButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statisticsNavButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.statisticsNavButton.ForeColor = System.Drawing.Color.Black;
            this.statisticsNavButton.Image = global::Baker_Grillers_Group_Project_Part_I.Properties.Resources.statistic;
            this.statisticsNavButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statisticsNavButton.ImageColor = System.Drawing.Color.Black;
            this.statisticsNavButton.ImagePadding = 5;
            this.statisticsNavButton.ImageSize = new System.Drawing.Size(24, 24);
            this.statisticsNavButton.IsSelected = false;
            this.statisticsNavButton.Location = new System.Drawing.Point(377, 5);
            this.statisticsNavButton.Name = "statisticsNavButton";
            this.statisticsNavButton.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.statisticsNavButton.SelectedForeColor = System.Drawing.Color.Black;
            this.statisticsNavButton.SelectedImageColor = System.Drawing.Color.White;
            this.statisticsNavButton.Size = new System.Drawing.Size(140, 61);
            this.statisticsNavButton.TabIndex = 15;
            this.statisticsNavButton.Text = "Statistics";
            this.statisticsNavButton.UseVisualStyleBackColor = false;
            this.statisticsNavButton.Click += new System.EventHandler(this.statisticsNavButton_Click);
            // 
            // playersNavButton
            // 
            this.playersNavButton.ApplyImageColor = false;
            this.playersNavButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(245)))));
            this.playersNavButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(114)))), ((int)(((byte)(77)))));
            this.playersNavButton.BorderSize = 2;
            this.playersNavButton.CornerRadius = 14;
            this.playersNavButton.FlatAppearance.BorderSize = 0;
            this.playersNavButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playersNavButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.playersNavButton.ForeColor = System.Drawing.Color.Black;
            this.playersNavButton.Image = global::Baker_Grillers_Group_Project_Part_I.Properties.Resources.list;
            this.playersNavButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.playersNavButton.ImageColor = System.Drawing.Color.Black;
            this.playersNavButton.ImagePadding = 5;
            this.playersNavButton.ImageSize = new System.Drawing.Size(24, 24);
            this.playersNavButton.IsSelected = false;
            this.playersNavButton.Location = new System.Drawing.Point(245, 5);
            this.playersNavButton.Name = "playersNavButton";
            this.playersNavButton.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.playersNavButton.SelectedForeColor = System.Drawing.Color.Black;
            this.playersNavButton.SelectedImageColor = System.Drawing.Color.White;
            this.playersNavButton.Size = new System.Drawing.Size(126, 61);
            this.playersNavButton.TabIndex = 14;
            this.playersNavButton.Text = "Players";
            this.playersNavButton.UseVisualStyleBackColor = false;
            this.playersNavButton.Click += new System.EventHandler(this.playersNavButton_Click);
            // 
            // teamsNavButton
            // 
            this.teamsNavButton.ApplyImageColor = false;
            this.teamsNavButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(245)))));
            this.teamsNavButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(114)))), ((int)(((byte)(77)))));
            this.teamsNavButton.BorderSize = 2;
            this.teamsNavButton.CornerRadius = 14;
            this.teamsNavButton.FlatAppearance.BorderSize = 0;
            this.teamsNavButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.teamsNavButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.teamsNavButton.ForeColor = System.Drawing.Color.Black;
            this.teamsNavButton.Image = global::Baker_Grillers_Group_Project_Part_I.Properties.Resources.trophy;
            this.teamsNavButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.teamsNavButton.ImageColor = System.Drawing.Color.Black;
            this.teamsNavButton.ImagePadding = 5;
            this.teamsNavButton.ImageSize = new System.Drawing.Size(18, 18);
            this.teamsNavButton.IsSelected = true;
            this.teamsNavButton.Location = new System.Drawing.Point(113, 5);
            this.teamsNavButton.Name = "teamsNavButton";
            this.teamsNavButton.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.teamsNavButton.SelectedForeColor = System.Drawing.Color.Black;
            this.teamsNavButton.SelectedImageColor = System.Drawing.Color.White;
            this.teamsNavButton.Size = new System.Drawing.Size(126, 61);
            this.teamsNavButton.TabIndex = 13;
            this.teamsNavButton.Text = "Teams";
            this.teamsNavButton.UseVisualStyleBackColor = false;
            this.teamsNavButton.Click += new System.EventHandler(this.teamsNavButton_Click);
            // 
            // selectedSportLabel
            // 
            this.selectedSportLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.selectedSportLabel.ForeColor = System.Drawing.Color.White;
            this.selectedSportLabel.Location = new System.Drawing.Point(20, -1);
            this.selectedSportLabel.Name = "selectedSportLabel";
            this.selectedSportLabel.Size = new System.Drawing.Size(112, 72);
            this.selectedSportLabel.TabIndex = 3;
            this.selectedSportLabel.Text = "CS:GO";
            this.selectedSportLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contentPanel
            // 
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPanel.BackColor = System.Drawing.SystemColors.Control;
            this.contentPanel.Location = new System.Drawing.Point(250, 165);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(902, 479);
            this.contentPanel.TabIndex = 7;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomPanel.Controls.Add(this.buttonPanel);
            this.bottomPanel.Location = new System.Drawing.Point(250, 645);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(899, 45);
            this.bottomPanel.TabIndex = 0;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPanel.Controls.Add(this.logoutButton);
            this.buttonPanel.Controls.Add(this.loginButton);
            this.buttonPanel.Location = new System.Drawing.Point(655, 0);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(249, 42);
            this.buttonPanel.TabIndex = 0;
            // 
            // logoutButton
            // 
            this.logoutButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.logoutButton.Location = new System.Drawing.Point(141, 9);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(81, 25);
            this.logoutButton.TabIndex = 4;
            this.logoutButton.Text = "&Exit";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(27, 9);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(81, 25);
            this.loginButton.TabIndex = 5;
            this.loginButton.Text = "&Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 691);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.navigationPanel);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.sidebarPanel);
            this.Controls.Add(this.topPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BG Sports Stats";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.topPanel.ResumeLayout(false);
            this.sidebarPanel.ResumeLayout(false);
            this.settingsPanel.ResumeLayout(false);
            this.navigationPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label userEmailLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label dropdownLabel;
        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel navigationPanel;
        private System.Windows.Forms.Label selectedSportLabel;
        private System.Windows.Forms.Panel contentPanel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.Button sportsSettingsButton;
        private System.Windows.Forms.Button globalSettingsButton;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button loginButton;
        private CustomElements.RoundedButton csgoSideBarButton;
        private CustomElements.RoundedButton nflSideBarButton;
        private CustomElements.RoundedButton customSideBarButton;
        private CustomElements.RoundedButton nbaSideBarButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private CustomElements.RoundedButton teamsNavButton;
        private CustomElements.RoundedButton statisticsNavButton;
        private CustomElements.RoundedButton playersNavButton;
        private CustomElements.RoundedButton favoritesNavButton;
    }
}

