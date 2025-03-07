using Baker_Grillers_Group_Project_Part_I.Settings;
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
        public SettingsForm()
        {
            InitializeComponent();
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
            // TODO: Need to save changes here. 

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}


