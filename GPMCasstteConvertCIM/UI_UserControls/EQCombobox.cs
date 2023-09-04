using GPMCasstteConvertCIM.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GPMCasstteConvertCIM.UI_UserControls
{
    public partial class EQCombobox : UserControl
    {
        public int SelectedIndex
        {
            get => comboBox1.SelectedIndex;
            set => comboBox1.SelectedIndex = value;
        }
        public string DisplayText
        {
            get => comboBox1.Text;
            set =>comboBox1.Text = value;
        }

        public event EventHandler<string> OnEQSelectChanged;
        public EQCombobox()
        {
            InitializeComponent();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("ALL");
            comboBox1.Items.AddRange(DevicesManager.casstteConverters.Select(eq => eq.Name).ToArray());

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnEQSelectChanged?.Invoke(this, comboBox1.SelectedItem.ToString());
        }
    }
}
