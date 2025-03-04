using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baker_Grillers_Group_Project_Part_I.Settings
{
    public partial class GeneralSettingsUserControl : UserControl
    {

        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\UserCredentials.mdf;Integrated Security=True";

        public GeneralSettingsUserControl()
        {
            InitializeComponent();
            LoadPreferences();
        }

        private void GeneralSettingsUserControl_Load(object sender, EventArgs e)
        {
            LoadSystemFontsAsync();
        }

        private void LoadPreferences()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Open connection
                conn.Open();

                // Defaults
                string font = "Microsoft Sans Serif";
                int themeIndex = 2; // Use system theme
                string enabledSports = "Football,Basketball,Baseball,Soccer";

                // Initialize query
                string query = "SELECT Font, Theme, EnabledSports FROM Preference WHERE Email = @Email";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (Program.CurrentSettingsUserEmail != null)
                    {
                        cmd.Parameters.AddWithValue("@Email", Program.CurrentSettingsUserEmail);
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Load from database
                            font = reader.IsDBNull(0) ? font : reader.GetString(0);
                            themeIndex = reader.IsDBNull(1) ? themeIndex : reader.GetInt32(1);
                            enabledSports = reader.IsDBNull(2) ? enabledSports : reader.GetString(2);   
                        }
                    }
                }

                // Update UI
                fontComboBox.Text = font;
                themeComboBox.SelectedIndex = themeIndex;
                LoadEnabledSports(enabledSports);

            }
        }

        // Asynchronously gets font names via System.Drawing.Text and updates UI
        private async void LoadSystemFontsAsync()
        {
            // Clear font ComboBox
            fontComboBox.Items.Clear();

            // Load fonts
            var fonts = await Task.Run(() => GetFontNames());

            // Load all installed fonts from System.Drawing.Text package
            List<string> fontNames = new List<string>();

            fontComboBox.Items.Clear();
            fontComboBox.Items.AddRange(fonts);
        }

        // Load installed fonts
        // Get font names as string[]
        private string[] GetFontNames()
        {
            var installedFonts = new InstalledFontCollection().Families;
            string[] fontNames = new string[installedFonts.Length];

            for (int i = 0; i < installedFonts.Length; i++)
            {
                fontNames[i] = installedFonts[i].Name;
            }

            return fontNames;
        }


        private void LoadEnabledSports(string sports)
        {
            string[] enabledSports = sports.Trim().Split(',');
            for (int i = 0; i < enabledSportsCheckedListBox.Items.Count; i++)
            {
                // Compare with CheckedListBox items
                bool sportEnabled = enabledSports.Contains(enabledSportsCheckedListBox.Items[i].ToString());
                
                enabledSportsCheckedListBox.SetItemChecked(i, sportEnabled);
                
            }
        }

        public void SavePreferences()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // How this query works:
                // Checks if the user already has preferences.gi
                // If they do, then we overwrite them with the new preferences
                // If not, create a new record.
                string query = @"
            MERGE INTO Preference AS target
            USING (VALUES (@Email, @Font, @Theme, @EnabledSports)) 
            AS source (Email, Font, Theme, EnabledSports)
            ON target.Email = source.Email
            WHEN MATCHED THEN 
                UPDATE SET Font = source.Font, Theme = source.Theme, EnabledSports = source.EnabledSports
            WHEN NOT MATCHED THEN 
                INSERT (Email, Font, Theme, EnabledSports) 
                VALUES (source.Email, source.Font, source.Theme, source.EnabledSports);";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", (object) Program.CurrentSettingsUserEmail ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Font", fontComboBox.Text);
                    cmd.Parameters.AddWithValue("@Theme", themeComboBox.SelectedIndex);
                    cmd.Parameters.AddWithValue("@EnabledSports", GetEnabledSports());

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private string GetEnabledSports()
        {
            List<string> sports = new List<string>();
            for (int i = 0; i < enabledSportsCheckedListBox.Items.Count; i++)
            {
                if (enabledSportsCheckedListBox.GetItemChecked(i))
                {
                    sports.Add(enabledSportsCheckedListBox.Items[i].ToString().Trim());
                }
            }
            return string.Join(",", sports);
        }

    }
}
