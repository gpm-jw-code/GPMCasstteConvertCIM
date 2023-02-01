using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPMCasstteConvertCIM.UI_UserControls
{
    public partial class WordValueChangeDialog : Form
    {
        public WordValueChangeDialog()
        {
            InitializeComponent();
        }

        private void btnComfirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        internal int ShowDialog(string address, int value)
        {
            Text = string.Format("Word Value Change-[{0}]", address);
            labWordAddress.Text = address;
            numericUpDown1.Value = value;
            ShowDialog();
            return (int)numericUpDown2.Value;
        }
    }
}
