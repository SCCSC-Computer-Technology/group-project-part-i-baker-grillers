/* Group Project Part 1
 * Team Name: Baker - Grillers
 * Members: Thomas Speich, Ashley Smith, Michael Lee
 * CPT-206-A01S-2025 Spring Smester: Adv Event-Driven Program
 */

using Baker_Grillers_Group_Project_Part_I;
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
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            if (triggerLogin) Login();
        }

        //Shows Football form
        private void btnFootBall_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(false);
            mainForm.Show();
            mainForm.UpdateSelectedSport("nfl");
        }

        //Shows Basketball form
        private void btnBasketBall_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(false);
            mainForm.Show();
            mainForm.UpdateSelectedSport("nba");
        }

        //Shows CSGO (E-sport) Form
        private void btnCSGO_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(false);
            mainForm.Show();
            mainForm.UpdateSelectedSport("csgo");
        }

        /*The Drop Down Menu "Sports" takes them to the selected sport form*/
        //Goes to the Football form
        private void footballToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Football groupFootballForm = new Football();
            //groupFootballForm.ShowDialog();
        }

        //Goes to the Basketball form
        private void basketballToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Basketball groupBasketballForm = new Basketball();
            //groupBasketballForm.ShowDialog();
        }

        //Goes to the CSGO (E-sport) form
        private void cSGOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CSGO groupCSGOForm = new CSGO();
            //groupCSGOForm.ShowDialog();
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

    }
}
