using Baker_Grillers_Group_Project_Part_I.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserAuthentication;

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

            // Change current user email - for applying settings
            Program.CurrentSettingsUserEmail = "guest@local.app";
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            /* Admin Credentials
             * Email: admin@sccsc.edu
             * Password: admin
             */

            //check if the email or password boxes are empty
            if (string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                MessageBox.Show("Please enter an email");
                return;
            }
            if(string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                MessageBox.Show("Please enter a password");
                return;
            }

            loginButton.Enabled = false;

            //check if the credentials are valid
            bool isValid = await Task.Run(() => Authenticator.IsValidCredentials(Program.credentialsConnection, emailTextBox.Text, passwordTextBox.Text));
            if (isValid)
            {
                DialogResult = DialogResult.OK;

                // Change current user email - for applying settings
                Program.CurrentSettingsUserEmail = emailTextBox.Text;

                this.Close();
            }
            loginButton.Enabled = true;
        }

        private void seePasswordButton_Click(object sender, EventArgs e)
        {
            //sets the password censor boolean to the opposite value
            passwordTextBox.UseSystemPasswordChar = !passwordTextBox.UseSystemPasswordChar;

            //set the image of the button to the corrosponding image
            seePasswordButton.BackgroundImage = (passwordTextBox.UseSystemPasswordChar) ? Resources.ClosedEye : Resources.OpenEye;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //closes the entire application
            Application.Exit();
        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {
            CreateAccountForm createAccountForm = new CreateAccountForm(Program.credentialsConnection);
            createAccountForm.ShowDialog();
        }

        private void forgotPasswordButton_Click(object sender, EventArgs e)
        {
            ForgotPasswordForm forgotPasswordForm = new ForgotPasswordForm(Program.credentialsConnection);
            forgotPasswordForm.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
