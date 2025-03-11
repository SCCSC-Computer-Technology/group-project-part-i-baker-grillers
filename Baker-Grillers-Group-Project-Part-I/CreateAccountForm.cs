using Baker_Grillers_Group_Project_Part_I.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserAuthentication;

namespace Baker_Grillers_Group_Project_Part_I
{
    public partial class CreateAccountForm : Form
    {
        //private string Connection;
        public CreateAccountForm()
        {
            InitializeComponent();
            //Connection = connection;
        }

        private async void createAccountButton_Click(object sender, EventArgs e)
        {
            string email = emailTextBox.Text;
            string password = passwordTextBox.Text;
            string confirmPassword = confirmPasswordTextBox.Text;
            //check if the email or password boxes are empty
            if(string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter an email for the account");
                return;
            }
            if(string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please enter and confirm a password for the account");
                return;
            }

            //check if the passwords match
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match");
                return;
            }
            //generate salt
            string salt = Guid.NewGuid().ToString();

            createAccountButton.Enabled = false;
            //try to add the credentials and check if it was successful
            bool isSuccessful = await Task.Run(() => Authenticator.AddCredentials(MainForm.conn, email, password, salt));
            if (isSuccessful)
            {
                MessageBox.Show("Account Created!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Something went wrong when trying to create an account.\nPlease try again.");
            }
            createAccountButton.Enabled = true;
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
