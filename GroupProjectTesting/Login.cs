/* Group Project Part 1
 * Team Name: Baker - Grillers
 * Members: Thomas Speich, Ashley Smith, Michael Lee
 * CPT-206-A01S-2025 Spring Smester: Adv Event-Driven Program
 */

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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //Goes to the Welcome Form
        private void btnLogin_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.ShowDialog();
            this.Hide();
        }

        //Stop the program/leave the program
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
