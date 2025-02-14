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
            if(string.IsNullOrEmpty(emailTextBox.Text))
            {
                MessageBox.Show("Please enter an email for the account");
                return;
            }

            if(string.IsNullOrEmpty(passwordTextBox.Text) || string.IsNullOrEmpty(confirmPasswordTextBox.Text))
            {
                MessageBox.Show("Please enter and confirm a password for the account");
                return;
            }

            if (passwordTextBox.Text != confirmPasswordTextBox.Text)
            {
                MessageBox.Show("Passwords do not match");
                return;
            }
            string salt = Guid.NewGuid().ToString().Replace('-', ' ');
            if(Authenticator.AddCredentials(Connection, emailTextBox.Text, passwordTextBox.Text, salt))
            {
                MessageBox.Show("Account Created!");
                this.Close();
            }
        }
    }
}
