﻿using System;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //load the login form
            LoginForm loginForm = new LoginForm();

            //this decides if the user will have access to everything or not
            if(loginForm.ShowDialog() == DialogResult.OK)
            {
                //placeholder
                MessageBox.Show("You have access to all of the features of this app :)");
            }
            else
            {
                //placeholder
                MessageBox.Show("You do not have access to all of the features of this app :(");
            }
        }
    }
}
