/* Group Project Part 1
 * Team Name: Baker - Grillers
 * Members: Thomas Speich, Ashley Smith, Michael Lee
 * CPT-206-A01S-2025 Spring Smester: Adv Event-Driven Program
 * 
 * Welcome Form
 */

using Baker_Grillers_Group_Project_Part_I;
using Baker_Grillers_Group_Project_Part_I.Settings;
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

namespace GroupProjectTesting
{
    public partial class WelcomeForm : Form
    {

        MainForm mainForm;
        public WelcomeForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            DataRepository dataRepository = new DataRepository(Program.connectionString);
            SettingsUtil.SetFormTheme(this, dataRepository, Program.CurrentSettingsUserEmail);
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {

        }

        //Shows Football form
        private void btnFootBall_Click(object sender, EventArgs e)
        {
            OpenFootball();
        }

        //Shows Basketball form
        private void btnBasketBall_Click(object sender, EventArgs e)
        {
            OpenNBA();
        }

        //Shows CSGO (E-sport) Form
        private void btnCSGO_Click(object sender, EventArgs e)
        {
            OpenCSGO();
        }

        /*The Drop Down Menu "Sports" takes them to the selected sport form*/
        //Goes to the Football form
        private void footballToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFootball();
        }

        //Goes to the Basketball form
        private void basketballToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenNBA();
        }

        //Goes to the CSGO (E-sport) form
        private void cSGOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCSGO();
        }


        //Logs out of the dashboard to go back to login
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Program.CurrentSettingsUserEmail = "";
            Application.Restart();
        }

        public void OpenCSGO()
        {
            mainForm.UpdateSelectedSport("csgo");
            this.Dispose();
        }

        public void OpenNBA()
        {
            mainForm.UpdateSelectedSport("nba");
            this.Dispose();
        }

        public void OpenFootball()
        {
            mainForm.UpdateSelectedSport("nfl");
            this.Dispose();
        }

    }
}
