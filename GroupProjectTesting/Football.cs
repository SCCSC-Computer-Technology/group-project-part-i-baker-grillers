using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupProjectTesting
{
    public partial class Football : Form
    {
        public Football()
        {
            InitializeComponent();
        }

        //Closes Football form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
