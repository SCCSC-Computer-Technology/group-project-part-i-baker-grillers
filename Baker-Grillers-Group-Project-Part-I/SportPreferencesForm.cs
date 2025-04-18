﻿using Baker_Grillers_Group_Project_Part_I.Settings;
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
    public partial class SportPreferencesForm : Form
    {

        string selectedSport = string.Empty;

        public SportPreferencesForm(string selectedSport)
        {
            InitializeComponent();
            DataRepository dataRepository = new DataRepository(Program.connectionString);
            SettingsUtil.SetFormTheme(this, dataRepository, Program.CurrentSettingsUserEmail);
        }

        private void SportPreferencesForm_Load(object sender, EventArgs e)
        {

        }

        public void InitializeForm()
        {
            switch(selectedSport)
            {
                case "csgo":
                    this.Text = "CSGO Preferences";
                    CSGOPreferencesUserControl csgoPreferencesUserControl = new CSGOPreferencesUserControl();
                    settingsPanel.Controls.Add(csgoPreferencesUserControl);
                    break;
                case "nfl":
                    this.Text = "NFL Preferences";
                    break;
                case "nba":
                    this.Text = "NBA Preferences";
                    break;
                case "custom":
                    this.Text = "Custom Preferences";
                    break;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
