using DataManager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baker_Grillers_Group_Project_Part_I.Settings
{
    internal class SettingsUtil
    {

        public static void SetFormTheme(Form form, DataRepository dataRepository, string email)
        {
            GlobalSettings globalSettings = dataRepository.GetGlobalSettings(email);

            string fontName = globalSettings.Font;

            // Ensure not null
            if (fontName.Equals("") || fontName.Equals(null)) fontName = "Microsoft Sans Serif";
            float fontSize = 9.75f;
            FontStyle fontStyle = FontStyle.Bold;

            form.Font = new Font(fontName, fontSize, fontStyle);
        }

    }
}
