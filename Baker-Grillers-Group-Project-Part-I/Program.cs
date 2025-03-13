using GroupProjectTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baker_Grillers_Group_Project_Part_I
{
    internal static class Program
    {

        public static string CurrentSettingsUserEmail = "";
        public static string connectionString = @"Server=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BGSportsStatsDB.mdf;Integrated Security=True;";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(true));
        }
    }
}
