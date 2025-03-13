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
using DataManager;

namespace Baker_Grillers_Group_Project_Part_I.Settings
{
    public partial class GeneralSettingsUserControl : UserControl
    {

        private string connectionString = Program.connectionString;
        DataRepository dataRepository;

        public GeneralSettingsUserControl()
        {
            InitializeComponent();

            // Initialize data
            dataRepository = new DataRepository(Program.connectionString);

            // Load settings
            LoadPreferences();
        }

        private void GeneralSettingsUserControl_Load(object sender, EventArgs e)
        {
            LoadSystemFontsAsync();
        }

        private void LoadPreferences()
        {

            
            GlobalSettings globalSettigns = dataRepository.GetGlobalSettings(Program.CurrentSettingsUserEmail);

            // Update UI
            fontComboBox.Text = globalSettigns.Font;
            themeComboBox.SelectedIndex = globalSettigns.ThemeIndex;
            LoadEnabledSports(globalSettigns.EnabledSports);

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
            GlobalSettings globalSettings = new GlobalSettings(fontComboBox.Text, themeComboBox.SelectedIndex, GetEnabledSports());
            dataRepository.SaveGlobalSettings(globalSettings, Program.CurrentSettingsUserEmail);
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
