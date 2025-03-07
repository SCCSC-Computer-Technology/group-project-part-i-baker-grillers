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
            this.exitButton = new System.Windows.Forms.Button();
            this.globalSettingsButton = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.dropdownLabel = new System.Windows.Forms.Label();
            this.userEmailLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.customSideBarButton = new System.Windows.Forms.Button();
            this.nbaSideBarButton = new System.Windows.Forms.Button();
            this.nflSideBarButton = new System.Windows.Forms.Button();
            this.csgoSideBarButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.sportsSettingsButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.navigationPanel = new System.Windows.Forms.Panel();
            this.favoritesNavButton = new System.Windows.Forms.Button();
            this.teamsNavButton = new System.Windows.Forms.Button();
            this.selectedSportLabel = new System.Windows.Forms.Label();
            this.playersNavButton = new System.Windows.Forms.Button();
            this.statisticsNavButton = new System.Windows.Forms.Button();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.loginButton = new System.Windows.Forms.Button();
            this.topPanel.SuspendLayout();
            this.sidebarPanel.SuspendLayout();
            this.settingsPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.navigationPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.Location = new System.Drawing.Point(668, 492);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(81, 25);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "E&xit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
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
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(255)))));
            this.topPanel.Controls.Add(this.dropdownLabel);
            this.topPanel.Controls.Add(this.userEmailLabel);
            this.topPanel.Controls.Add(this.nameLabel);
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1013, 90);
            this.topPanel.TabIndex = 3;
            // 
            // dropdownLabel
            // 
            this.dropdownLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropdownLabel.Location = new System.Drawing.Point(953, 0);
            this.dropdownLabel.Name = "dropdownLabel";
            this.dropdownLabel.Size = new System.Drawing.Size(32, 90);
            this.dropdownLabel.TabIndex = 2;
            this.dropdownLabel.Text = "▼";
            this.dropdownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dropdownLabel.Click += new System.EventHandler(this.dropdownLabel_Click);
            // 
            // userEmailLabel
            // 
            this.userEmailLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userEmailLabel.Location = new System.Drawing.Point(758, 0);
            this.userEmailLabel.Name = "userEmailLabel";
            this.userEmailLabel.Size = new System.Drawing.Size(189, 90);
            this.userEmailLabel.TabIndex = 1;
            this.userEmailLabel.Text = "admin@sccsc.edu";
            this.userEmailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.userEmailLabel.Click += new System.EventHandler(this.userEmailLabel_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(32, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(350, 90);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "BG Sports Statistics";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sidebarPanel.Controls.Add(this.customSideBarButton);
            this.sidebarPanel.Controls.Add(this.nbaSideBarButton);
            this.sidebarPanel.Controls.Add(this.nflSideBarButton);
            this.sidebarPanel.Controls.Add(this.csgoSideBarButton);
            this.sidebarPanel.Controls.Add(this.label1);
            this.sidebarPanel.Location = new System.Drawing.Point(0, 90);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(250, 481);
            this.sidebarPanel.TabIndex = 4;
            // 
            // customSideBarButton
            // 
            this.customSideBarButton.Location = new System.Drawing.Point(14, 237);
            this.customSideBarButton.Name = "customSideBarButton";
            this.customSideBarButton.Size = new System.Drawing.Size(222, 50);
            this.customSideBarButton.TabIndex = 8;
            this.customSideBarButton.Text = "Custom";
            this.customSideBarButton.UseVisualStyleBackColor = true;
            this.customSideBarButton.Click += new System.EventHandler(this.customSideBarButton_Click);
            // 
            // nbaSideBarButton
            // 
            this.nbaSideBarButton.Location = new System.Drawing.Point(14, 181);
            this.nbaSideBarButton.Name = "nbaSideBarButton";
            this.nbaSideBarButton.Size = new System.Drawing.Size(222, 50);
            this.nbaSideBarButton.TabIndex = 7;
            this.nbaSideBarButton.Text = "NBA";
            this.nbaSideBarButton.UseVisualStyleBackColor = true;
            this.nbaSideBarButton.Click += new System.EventHandler(this.nbaSideBarButton_Click);
            // 
            // nflSideBarButton
            // 
            this.nflSideBarButton.Location = new System.Drawing.Point(14, 125);
            this.nflSideBarButton.Name = "nflSideBarButton";
            this.nflSideBarButton.Size = new System.Drawing.Size(222, 50);
            this.nflSideBarButton.TabIndex = 6;
            this.nflSideBarButton.Text = "NFL";
            this.nflSideBarButton.UseVisualStyleBackColor = true;
            this.nflSideBarButton.Click += new System.EventHandler(this.nflSideBarButton_Click);
            // 
            // csgoSideBarButton
            // 
            this.csgoSideBarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(228)))), ((int)(((byte)(254)))));
            this.csgoSideBarButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.csgoSideBarButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.csgoSideBarButton.Location = new System.Drawing.Point(14, 69);
            this.csgoSideBarButton.Name = "csgoSideBarButton";
            this.csgoSideBarButton.Size = new System.Drawing.Size(222, 50);
            this.csgoSideBarButton.TabIndex = 5;
            this.csgoSideBarButton.Text = "CS:GO";
            this.csgoSideBarButton.UseVisualStyleBackColor = false;
            this.csgoSideBarButton.Click += new System.EventHandler(this.csgoSideBarButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 72);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sports";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // settingsPanel
            // 
            this.settingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.settingsPanel.Controls.Add(this.sportsSettingsButton);
            this.settingsPanel.Controls.Add(this.globalSettingsButton);
            this.settingsPanel.Location = new System.Drawing.Point(0, 571);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(250, 119);
            this.settingsPanel.TabIndex = 5;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.navigationPanel);
            this.panel2.Location = new System.Drawing.Point(250, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(763, 70);
            this.panel2.TabIndex = 6;
            // 
            // navigationPanel
            // 
            this.navigationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(192)))), ((int)(((byte)(223)))));
            this.navigationPanel.Controls.Add(this.favoritesNavButton);
            this.navigationPanel.Controls.Add(this.teamsNavButton);
            this.navigationPanel.Controls.Add(this.selectedSportLabel);
            this.navigationPanel.Controls.Add(this.playersNavButton);
            this.navigationPanel.Controls.Add(this.statisticsNavButton);
            this.navigationPanel.Location = new System.Drawing.Point(1, -1);
            this.navigationPanel.Name = "navigationPanel";
            this.navigationPanel.Size = new System.Drawing.Size(762, 70);
            this.navigationPanel.TabIndex = 2;
            // 
            // favoritesNavButton
            // 
            this.favoritesNavButton.Location = new System.Drawing.Point(627, 9);
            this.favoritesNavButton.Name = "favoritesNavButton";
            this.favoritesNavButton.Size = new System.Drawing.Size(121, 51);
            this.favoritesNavButton.TabIndex = 6;
            this.favoritesNavButton.Text = "Favorites";
            this.favoritesNavButton.UseVisualStyleBackColor = true;
            this.favoritesNavButton.Click += new System.EventHandler(this.favoritesTabButton_Click);
            // 
            // teamsNavButton
            // 
            this.teamsNavButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(228)))), ((int)(((byte)(254)))));
            this.teamsNavButton.Location = new System.Drawing.Point(246, 9);
            this.teamsNavButton.Name = "teamsNavButton";
            this.teamsNavButton.Size = new System.Drawing.Size(121, 51);
            this.teamsNavButton.TabIndex = 4;
            this.teamsNavButton.Text = "Teams";
            this.teamsNavButton.UseVisualStyleBackColor = false;
            this.teamsNavButton.Click += new System.EventHandler(this.teamsNavButton_Click);
            // 
            // selectedSportLabel
            // 
            this.selectedSportLabel.Font = new System.Drawing.Font("Calibri", 14F);
            this.selectedSportLabel.Location = new System.Drawing.Point(20, -1);
            this.selectedSportLabel.Name = "selectedSportLabel";
            this.selectedSportLabel.Size = new System.Drawing.Size(97, 72);
            this.selectedSportLabel.TabIndex = 3;
            this.selectedSportLabel.Text = "CS:GO";
            this.selectedSportLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // playersNavButton
            // 
            this.playersNavButton.Location = new System.Drawing.Point(500, 9);
            this.playersNavButton.Name = "playersNavButton";
            this.playersNavButton.Size = new System.Drawing.Size(121, 51);
            this.playersNavButton.TabIndex = 3;
            this.playersNavButton.Text = "Players";
            this.playersNavButton.UseVisualStyleBackColor = true;
            this.playersNavButton.Click += new System.EventHandler(this.playersNavButton_Click);
            // 
            // statisticsNavButton
            // 
            this.statisticsNavButton.Location = new System.Drawing.Point(373, 9);
            this.statisticsNavButton.Name = "statisticsNavButton";
            this.statisticsNavButton.Size = new System.Drawing.Size(121, 51);
            this.statisticsNavButton.TabIndex = 5;
            this.statisticsNavButton.Text = "Statistics";
            this.statisticsNavButton.UseVisualStyleBackColor = true;
            this.statisticsNavButton.Click += new System.EventHandler(this.statisticsNavButton_Click);
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.exitButton);
            this.contentPanel.Controls.Add(this.loginButton);
            this.contentPanel.Location = new System.Drawing.Point(250, 160);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(760, 530);
            this.contentPanel.TabIndex = 7;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(554, 492);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(81, 25);
            this.loginButton.TabIndex = 1;
            this.loginButton.Text = "&Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.exitButton;
            this.ClientSize = new System.Drawing.Size(1011, 691);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.settingsPanel);
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
            this.panel2.ResumeLayout(false);
            this.navigationPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button globalSettingsButton;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label userEmailLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label dropdownLabel;
        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button csgoSideBarButton;
        private System.Windows.Forms.Button customSideBarButton;
        private System.Windows.Forms.Button nbaSideBarButton;
        private System.Windows.Forms.Button nflSideBarButton;
        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.Button sportsSettingsButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel navigationPanel;
        private System.Windows.Forms.Button teamsNavButton;
        private System.Windows.Forms.Label selectedSportLabel;
        private System.Windows.Forms.Button favoritesNavButton;
        private System.Windows.Forms.Button playersNavButton;
        private System.Windows.Forms.Button statisticsNavButton;
        private System.Windows.Forms.Panel contentPanel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button loginButton;
    }
}

