using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    public class GlobalSettings
    {
        public string Font { get; set; }
        public int ThemeIndex { get; set; }
        public string EnabledSports { get; set; }

        public GlobalSettings(string font, int themeIndex, string enabledSports)
        {
            Font = font;
            ThemeIndex = themeIndex;
            EnabledSports = enabledSports;
        }

    }

}
