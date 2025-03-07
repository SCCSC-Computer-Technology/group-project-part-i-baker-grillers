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
    public partial class Baseball : Form
    {
        public Baseball()
        {
            InitializeComponent();
        }

        //Closes the Baseball form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
