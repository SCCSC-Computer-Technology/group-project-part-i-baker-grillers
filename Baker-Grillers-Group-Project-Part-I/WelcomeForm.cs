/* Group Project Part 1
 * Team Name: Baker - Grillers
 * Members: Thomas Speich, Ashley Smith, Michael Lee
 * CPT-206-A01S-2025 Spring Smester: Adv Event-Driven Program
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

        bool triggerLogin;
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
            if (triggerLogin) Login();
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

        private void Login()
        {
            //load the login form
            LoginForm loginForm = new LoginForm();

            //this decides if the user will have access to everything or not
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                //placeholder for unlocking features
                //loginButton.Visible = false;
            }
            else
            {
                //loginButton.Visible = true;
            }
            //UpdateUserEmailLabel();
        }

        public void OpenCSGO()
        {
            MainForm mainForm = new MainForm(false);
            mainForm.Show();
            mainForm.UpdateSelectedSport("csgo");
        }

        public void OpenNBA()
        {
            MainForm mainForm = new MainForm(false);
            mainForm.Show();
            mainForm.UpdateSelectedSport("nba");
        }

        public void OpenFootball()
        {
            MainForm mainForm = new MainForm(false);
            mainForm.Show();
            mainForm.UpdateSelectedSport("nfl");
        }

    }
}
