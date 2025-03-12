using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baker_Grillers_Group_Project_Part_I
{

    /*
     * Necessary to combine FirstName and LastName for the NbaPlayer table
     */
    public partial class NbaPlayer
    {
        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }
    }
}
