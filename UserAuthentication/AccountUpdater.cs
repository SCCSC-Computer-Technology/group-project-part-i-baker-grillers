using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserAuthentication
{
    public class AccountUpdater
    {
        public async static Task<bool> ChangePassword(string connection, string userEmail, string password, string salt)
        {
            return await ChangePassword(connection, userEmail, password, salt, "Credentials", "Email", "HashedPassword", "Salt");
        }
        public async static Task<bool> ChangePassword(string connection, string userEmail, string password, string salt, string tableName, string emailColumn, string passwordColumn, string saltColumn)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand($"UPDATE {tableName} " +
                                                               $"SET {passwordColumn} = @password, {saltColumn} = @salt " +
                                                               $"WHERE {emailColumn} = @email;", conn))
                        {
                            byte[] passAndSalt = Authenticator.HashPassword(password, salt);
                            cmd.Parameters.AddWithValue("@password", passAndSalt);
                            cmd.Parameters.AddWithValue("@salt", salt);
                            cmd.Parameters.AddWithValue("@email", userEmail);

                            return cmd.ExecuteNonQuery() != 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.GetType()}\n{ex.Message}");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.GetType()}\n{ex.Message}");
                return false;
            }
        }

        public async static Task<bool> CheckForExistingEmail(string connection, string userEmail)
        {
            return await CheckForExistingEmail(connection, userEmail, "Credentials", "Email");
        }
        public async static Task<bool> CheckForExistingEmail(string connection, string userEmail, string tableName, string emailColumn)
        {

            try
            {
                //create a connection to the SQL server
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    //open the connection
                    conn.Open();

                    try
                    {
                        //create and run a SQL command to check if the email exists
                        using (SqlCommand cmd = new SqlCommand($"SELECT 1 FROM {tableName} WHERE {emailColumn} = @email", conn))
                        {
                            cmd.Parameters.AddWithValue("@email", userEmail);
                            SqlDataReader reader = cmd.ExecuteReader();
                            return reader.HasRows;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.GetType()}\n{ex.Message}");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.GetType()}\n{ex.Message}");
                return false;
            }
        }

        public async static Task<int> SendResetCode(string userEmail, string bodyMessage)
        {
            //declare email objects
            MailAddress fromEmail = new MailAddress("speichdev396@gmail.com", "BG Sports Statistics");
            MailAddress toEmail = new MailAddress(userEmail, "User");

            //app password
            const string fromPassword = "zdzv usjj xtox glhy";

            //create an instance of an SMTP client
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromEmail.Address, fromPassword),
                Timeout = 20000
            };

            //create and use a message object
            using (MailMessage message = new MailMessage(fromEmail, toEmail))
            {
                //generate a random password code
                Random rand = new Random();
                int code = rand.Next(999999);

                //set the email subject and body
                message.Subject = "Password Reset";
                message.Body = $"{bodyMessage}\n{code}";

                //try to send the code
                try
                {
                    smtp.Send(message);
                    return code;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.GetType()}\n{ex.Message}");
                    return -1;
                }
            }
        }

        public async static Task<int> SendResetCode(string userEmail)
        {
            return await SendResetCode(userEmail, "Use the code below to reset your password:");
        }
    }
}
