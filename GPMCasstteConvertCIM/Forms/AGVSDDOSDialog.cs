using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPMCasstteConvertCIM.Forms
{
    public partial class AGVSDDOSDialog : Form
    {
        public AGVSDDOSDialog()
        {
            InitializeComponent();
        }
        private Color RedColor = Color.Red;
        private Color WhiteColor = Color.White;
        private void timer1_Tick(object sender, EventArgs e)
        {
            labText.ForeColor = labText.ForeColor == RedColor ? WhiteColor : RedColor;
            BackColor = labText.ForeColor == RedColor ? WhiteColor : RedColor;
        }
    }
}
