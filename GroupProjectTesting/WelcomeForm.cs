<<<<<<< Updated upstream
﻿using System;
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
        public WelcomeForm()
        {
            InitializeComponent();
        }

        //Shows Football form
        private void btnFootBall_Click(object sender, EventArgs e)
        {
            Football footballForm = new Football();
            footballForm.ShowDialog();
        }

        //Shows Basketball form
        private void btnBasketBall_Click(object sender, EventArgs e)
        {
            Basketball basketballForm = new Basketball();
            basketballForm.ShowDialog();
        }

        //Shows the Baseball form
        private void btnBaseBall_Click(object sender, EventArgs e)
        {
            Baseball baseballForm = new Baseball();
            baseballForm.ShowDialog();
        }

        //Shows the Soccer form
        private void btnSoccer_Click(object sender, EventArgs e)
        {
            Soccer soccerForm = new Soccer();
            soccerForm.ShowDialog();
        }

        //The toolStrip "Sports" takes them to the selected sport
        private void footballToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Football groupFootballForm = new Football();
            groupFootballForm.ShowDialog();
        }

        private void basketballToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Basketball groupBasketballForm = new Basketball();
            groupBasketballForm.ShowDialog();
        }

        private void baseballToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Baseball groupBaseballForm = new Baseball();
            groupBaseballForm.ShowDialog();
        }

        private void soccerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Soccer groupSoccerForm = new Soccer();
            groupSoccerForm.ShowDialog();
        }


        //Goes back to login
        private void btnExit_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.ShowDialog();
        }

        
    }
}
=======
﻿/* Group Project Part 1
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
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        //Shows Football form
        private void btnFootBall_Click(object sender, EventArgs e)
        {
            Football footballForm = new Football();
            footballForm.ShowDialog();
        }

        //Shows Basketball form
        private void btnBasketBall_Click(object sender, EventArgs e)
        {
            Basketball basketballForm = new Basketball();
            basketballForm.ShowDialog();
        }

        //Shows CSGO (E-sport) Form
        private void btnCSGO_Click(object sender, EventArgs e)
        {
            CSGO csgoForm = new CSGO();
            csgoForm.ShowDialog();
        }

        /*The Drop Down Menu "Sports" takes them to the selected sport form*/
        //Goes to the Football form
        private void footballToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Football groupFootballForm = new Football();
            groupFootballForm.ShowDialog();
        }

        //Goes to the Basketball form
        private void basketballToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Basketball groupBasketballForm = new Basketball();
            groupBasketballForm.ShowDialog();
        }

        //Goes to the CSGO (E-sport) form
        private void cSGOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CSGO groupCSGOForm = new CSGO();
            groupCSGOForm.ShowDialog();
        }


        //Logs out of the dashboard to go back to login
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.ShowDialog();
        }
        

        
    }
}
>>>>>>> Stashed changes
