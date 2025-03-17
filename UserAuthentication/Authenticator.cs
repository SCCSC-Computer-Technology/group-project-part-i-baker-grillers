using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace UserAuthentication
{
    public class Authenticator
    {
        
        public async static Task<bool> AddCredentials(SqlConnection conn, string email, string password, string salt)
        {
            return await AddCredentials(conn, email, password, salt, "UserCredential");
        }

        //used if the table name is not "BGSportsStatsDB"
        public async static Task<bool> AddCredentials(SqlConnection conn, string email, string password, string salt, string tableName)
        {
            try
            {
                if(conn.State != System.Data.ConnectionState.Open)conn.Open();

                try
                {
                    //create and execute a SQL query
                    using (SqlCommand cmd = new SqlCommand($"INSERT INTO {tableName} VALUES(@email, @hashedPassword, @salt)", conn))
                    {
                        byte[] hashedPassword = HashPassword(password, salt);

                        cmd.Parameters.AddWithValue("@email", email.Trim().ToLower());
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
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.GetType()}\n{ex.Message}");
                return false;
            }
        }

        public async static Task<bool> IsValidCredentials(SqlConnection conn, string email, string password)
        {
            return await IsValidCredentials(conn, email, password, "UserCredential", "Email", "Salt", "HashedPassword");
        }

        public async static Task<bool> IsValidCredentials(SqlConnection conn, string email, string password, string tableName, string emailColumn, string saltColumn, string hashedPasswordColumn)
        {
            try
            {
                if(conn.State != System.Data.ConnectionState.Open) conn.Open();
                try
                {
                    //instantiate a SQL command object with a query to get the hashed password and salt
                    using (SqlCommand cmd = new SqlCommand($"SELECT {hashedPasswordColumn}, {saltColumn} FROM {tableName} WHERE {emailColumn}= @email", conn))
                    {
                        //add the email from the textbox as the @email parameter
                        cmd.Parameters.AddWithValue("@email", email.Trim().ToLower());
                        SqlDataReader reader = null;
                        try
                        {
                            //execute the query and store the results in a reader
                            reader = cmd.ExecuteReader();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show($"{ex.GetType()}\n{ex.Message}");
                            if(reader != null) reader.Close();
                            return false;
                        }

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
                            reader.Close();
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
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.GetType()}\n{ex.Message}");
                return false;
            }
        }
    
        public static byte[] HashPassword(string password)
        {
            //instantiate a SHA256 object
            SHA256 sha = SHA256.Create();

            //return the hashed password
            return sha.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public static byte[] HashPassword(string password, string salt)
        {
            //return the hashed salted password
            return HashPassword(password + salt);
        }
    }
}
