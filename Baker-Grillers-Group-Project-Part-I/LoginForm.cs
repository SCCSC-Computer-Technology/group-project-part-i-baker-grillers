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
        //private string credentialsConnection = @"Server=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Users.mdf;Integrated Security=True;";
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
            bool isValid = await Task.Run(() => Authenticator.IsValidCredentials(MainForm.conn, emailTextBox.Text, passwordTextBox.Text));
            if (isValid)
            {
                DialogResult = DialogResult.OK;
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
            CreateAccountForm createAccountForm = new CreateAccountForm();
            createAccountForm.ShowDialog();
        }

        private void forgotPasswordButton_Click(object sender, EventArgs e)
        {
            ForgotPasswordForm forgotPasswordForm = new ForgotPasswordForm();
            forgotPasswordForm.ShowDialog();
        }
    }
}
