using GPMCasstteConvertCIM.CasstteConverter;
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
    public partial class frmConvertPLCMemoryTables : Form
    {
        private clsCasstteConverter _CasstteConverter;
        internal clsCasstteConverter CasstteConverter
        {
            get => _CasstteConverter;
            set
            {
                _CasstteConverter = value;
                uscMemoryTable1.bitMemoryAddressList = CasstteConverter?.LinkBitMap;
                uscMemoryTable1.wordMemoryAddressList = CasstteConverter?.LinkWordMap;
                uscMemoryTable1.Editable = true;
            }
        }

        public frmConvertPLCMemoryTables()
        {
            InitializeComponent();
        }

        private void frmConvertPLCMemoryTables_Load(object sender, EventArgs e)
        {
            uscMemoryTable1.DataTableColorInitSet();
        }

        private void frmConvertPLCMemoryTables_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void ckbMonitor_CheckedChanged(object sender, EventArgs e)
        {
            CasstteConverter.monitor = ckbMonitor.Checked;
        }
    }
}
