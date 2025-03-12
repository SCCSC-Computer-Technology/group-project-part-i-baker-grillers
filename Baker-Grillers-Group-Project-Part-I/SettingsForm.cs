using Baker_Grillers_Group_Project_Part_I.Settings;
using DataManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baker_Grillers_Group_Project_Part_I
{
    public partial class SettingsForm : Form
    {

        private GeneralSettingsUserControl generalSettingsControl;
        MainForm mainForm;
        public SettingsForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void settingsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

            // Clear whatever is already in the GroupBox
            settingsPanel.Controls.Clear();

            switch (e.Node.Name)
            {
                case "general":
                    generalSettingsControl = new GeneralSettingsUserControl();
                    settingsPanel.Controls.Add(generalSettingsControl);
                    break;
            }

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
            generalSettingsControl.SavePreferences();
            DataRepository dataRepository = new DataRepository(Program.connectionString);
            SettingsUtil.SetFormTheme(mainForm, dataRepository, Program.CurrentSettingsUserEmail);
            SettingsUtil.SetFormTheme(this, dataRepository, Program.CurrentSettingsUserEmail);
            mainForm.UpdateEnableSports();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}


