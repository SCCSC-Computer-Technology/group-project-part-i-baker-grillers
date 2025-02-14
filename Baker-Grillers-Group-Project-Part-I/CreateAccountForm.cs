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
        private string Connection;
        public CreateAccountForm(string connection)
        {
            InitializeComponent();
            Connection = connection;
        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {
            //check if the email or password boxes are empty
            if(string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                MessageBox.Show("Please enter an email for the account");
                return;
            }
            if(string.IsNullOrWhiteSpace(passwordTextBox.Text) || string.IsNullOrWhiteSpace(confirmPasswordTextBox.Text))
            {
                MessageBox.Show("Please enter and confirm a password for the account");
                return;
            }

            //check if the passwords match
            if (passwordTextBox.Text != confirmPasswordTextBox.Text)
            {
                MessageBox.Show("Passwords do not match");
                return;
            }
            //generate salt
            string salt = Guid.NewGuid().ToString().Replace('-', ' ');

            //try to add the credentials and check if it was successful
            if(Authenticator.AddCredentials(Connection, emailTextBox.Text, passwordTextBox.Text, salt))
            {
                MessageBox.Show("Account Created!");
                this.Close();
            }
        }
    }
}
