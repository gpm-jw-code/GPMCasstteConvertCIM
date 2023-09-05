using GPMCasstteConvertCIM.CasstteConverter;
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

                string firstEQName = DevicesManager.casstteConverters.Select(eq => eq.Name).FirstOrDefault();
                if (firstEQName != null)
                {
                    eqCombobox1.DisplayText = firstEQName;
                }
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

        private void eqCombobox1_OnEQSelectChanged(object sender, string eq_name)
        {
            uscMemoryTable1.SpecficEqName = eq_name;
        }
    }
}
