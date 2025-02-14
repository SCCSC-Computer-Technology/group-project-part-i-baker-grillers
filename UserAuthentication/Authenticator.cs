using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserAuthentication
{
    public class Authenticator
    {
        public static bool AddCredentials(string connectionString, string email, string password, string salt)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO CREDENTIALS VALUES(@email, @hashedPassword, @salt)", conn))
                        {
                            byte[] hashedPassword = Authenticator.HashPassword(password, salt);

                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.Parameters.AddWithValue("@hashedPassword", hashedPassword);
                            cmd.Parameters.AddWithValue("@salt", salt);

                            cmd.ExecuteNonQuery();

                            return true;
                        }
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627) //the insert violated the primary key constraint
                        {
                            MessageBox.Show("An account already exists with that email");
                        }
                        else
                        {
                            MessageBox.Show($"{ex.GetType()}\n{ex.Number}\n{ex.Message}");
                        }
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

        public static bool AddCredentials(string connectionString, string email, string password, string salt, string tableName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand($"INSERT INTO {tableName} VALUES(@email, @hashedPassword, @salt)", conn))
                        {
                            byte[] hashedPassword = Authenticator.HashPassword(password, salt);

                            cmd.Parameters.AddWithValue("@email", email.ToLower());
                            cmd.Parameters.AddWithValue("@hashedPassword", hashedPassword);
                            cmd.Parameters.AddWithValue("@salt", salt);

                            cmd.ExecuteNonQuery();

                            return true;
                        }
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627) //the insert violated the primary key constraint
                        {
                            MessageBox.Show("An account already exists with that email");
                        }
                        else
                        {
                            MessageBox.Show($"{ex.GetType()}\n{ex.Number}\n{ex.Message}");
                        }
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

        public static bool IsValidCredentials(string connectionString, string email, string password)
        {
            try
            {
                //instantiate a SQL connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //open the connect
                    conn.Open();
                    try
                    {
                        //instantiate a SQL command object with a query to get the hashed password and salt
                        using (SqlCommand cmd = new SqlCommand("SELECT HashedPassword, Salt FROM Credentials WHERE Email = @email", conn))
                        {
                            //add the email from the textbox as the @email parameter
                            cmd.Parameters.AddWithValue("@email", email);

                            //execute the query and store the results in a reader
                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                //move to the first (and only) row in the reader
                                reader.Read();

                                //hash the entered password with the salt associated with the email
                                byte[] passAndSalt = HashPassword(password, reader["Salt"].ToString());

                                //get the hashed password from the user record
                                byte[] hashedPass = (byte[])reader["HashedPassword"];
                                reader.Close();


                                //check if the entered password hash matches the one stored in the DB
                                if (passAndSalt.SequenceEqual(hashedPass))
                                {
                                    return true;
                                }
                                else
                                {
                                    MessageBox.Show("Credentials do not match any existing user accounts");
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Credentials do not match any existing user accounts");
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.GetType()}\n{ex.Message}");
                return false;
            }
        }

        public static bool IsValidCredentials(string connectionString, string email, string password, string tableName, string emailColumn, string saltColumn, string hashedPasswordColumn)
        {
            try
            {
                //instantiate a SQL connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //open the connect
                    conn.Open();
                    try
                    {
                        //instantiate a SQL command object with a query to get the hashed password and salt
                        using (SqlCommand cmd = new SqlCommand($"SELECT {hashedPasswordColumn}, {saltColumn} FROM {tableName} WHERE {emailColumn}= @email", conn))
                        {
                            //add the email from the textbox as the @email parameter
                            cmd.Parameters.AddWithValue("@email", email);

                            //execute the query and store the results in a reader
                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                //move to the first (and only) row in the reader
                                reader.Read();


                                //hash the entered password with the salt associated with the email
                                byte[] passAndSalt = HashPassword(password, reader["Salt"].ToString());

                                //get the hashed password from the user record
                                byte[] hashedPass = (byte[])reader[hashedPasswordColumn];
                                reader.Close();


                                //check if the entered password hash matches the one stored in the DB
                                if (passAndSalt.SequenceEqual(hashedPass))
                                {
                                    return true;
                                }
                                else
                                {
                                    MessageBox.Show("Credentials do not match any existing user accounts");
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Credentials do not match any existing user accounts");
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.GetType()}\n{ex.Message}");
                return false;
            }
        }
    
        public static byte[] HashPassword(string password)
        {
            SHA256 sha = SHA256.Create();

            return sha.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public static byte[] HashPassword(string password, string salt)
        {
            SHA256 sha = SHA256.Create();

            return sha.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
        }
    }
}
