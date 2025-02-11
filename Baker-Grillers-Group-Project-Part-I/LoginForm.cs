using Baker_Grillers_Group_Project_Part_I.Properties;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void continueWithoutLoginButton_Click(object sender, EventArgs e)
        {
            //closes the login form with the cancel result
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            //using a hard-coded login, replace later
            if (emailTextBox.Text.Trim().ToLower() != "admin@sccsc.edu" ||
                passwordTextBox.Text != "admin01")
            {
                MessageBox.Show("Invalid login info");
                return;
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void seePasswordButton_Click(object sender, EventArgs e)
        {
            //sets the password censor boolean to the opposite value
            passwordTextBox.UseSystemPasswordChar = !passwordTextBox.UseSystemPasswordChar;
            //set the image of the button to the corrosponding image
            seePasswordButton.BackgroundImage = (passwordTextBox.UseSystemPasswordChar) ? Resources.ClosedEye : Resources.OpenEye;
        }
    }
}
