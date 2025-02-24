using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using UserAuthentication;
using System.Data.SqlClient;
using System.Diagnostics;
using Baker_Grillers_Group_Project_Part_I.Properties;

namespace Baker_Grillers_Group_Project_Part_I
{
    public partial class ForgotPasswordForm : Form
    {
        private string connectionString;
        private string lastEmail;
        private int resetCode;
        public ForgotPasswordForm(string connection)
        {
            InitializeComponent();
            connectionString = connection;
            resetCode = -1;
            lastEmail = "";
        }

        private async void sendEmailButton_Click(object sender, EventArgs e)
        {
            //declare and intialize variables
            string email = emailTextBox.Text.Trim().ToLower();
            bool isRegistered = false;

            //check if the email textbox is blank
            if(string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter the email for the account you forgot the password for");
                return;
            }

            sendEmailButton.Enabled = false;

            //check if the email belongs to a registered account (ASYNC)
            isRegistered = await Task.Run(() => AccountUpdater.CheckForExistingEmail(connectionString, email));


            //if the email belongs to a registered account, send them an email with a reset code
            if (isRegistered)
            {
                try
                {
                    //send an email with the reset code and store the reset code in a variable
                    resetCode = await Task.Run(() => AccountUpdater.SendResetCode(email));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                //store the email that was entered
                lastEmail = email;
            }

            sendEmailButton.Enabled = true;

            MessageBox.Show("If an account with the entered email exists, we have sent a code to reset your password\n\nOnce this window closes, the reset code will be invalid");

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(resetCodeTextBox.Text, out int code))
            {
                //check if a code was actually sent, then if the code matches the one sent
                if (string.IsNullOrWhiteSpace(lastEmail) || code != resetCode)
                {
                    MessageBox.Show("Reset code does not match\nEnsure that you do not close this screen before receiving and entering the code");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Invalid code entered");
                return;
            }

            //switch to another panel so the user can enter a new password
            sendPanel.Visible = false;
            resetPanel.Visible = true;

            //set the focus to the password textbox
            passwordTextBox.Focus();
        }

        private async void resetPasswordButton_Click(object sender, EventArgs e)
        {
            //get the password and confirmed password
            string password = passwordTextBox.Text;
            string confirmPassword = confirmPasswordTextBox.Text;

            //check if either password textbox was blank
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please enter and confirm a new password");
                return;
            }

            //check if the passwords match
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match");
                return;
            }

            resetPasswordButton.Enabled = false;

            //change the password and store the result as a boolean
            //true for changed, false for unchanged
            bool passwordChanged = await AccountUpdater.ChangePassword(connectionString, lastEmail, password, Guid.NewGuid().ToString());
            
            resetPasswordButton.Enabled = true;

            //check if the password was changed
            if (passwordChanged)
            {
                MessageBox.Show("Password has been changed");
                this.Close();
            }
            else
            {
                MessageBox.Show("Could not change password");
            }
        }

        private void seePasswordButton_Click(object sender, EventArgs e)
        {
            //sets the password censor boolean to the opposite value
            passwordTextBox.UseSystemPasswordChar = !passwordTextBox.UseSystemPasswordChar;
            confirmPasswordTextBox.UseSystemPasswordChar = !confirmPasswordTextBox.UseSystemPasswordChar;

            //set the image of the button to the corrosponding image
            seePasswordButton.BackgroundImage = (passwordTextBox.UseSystemPasswordChar) ? Resources.ClosedEye : Resources.OpenEye;
        }
    }
}
