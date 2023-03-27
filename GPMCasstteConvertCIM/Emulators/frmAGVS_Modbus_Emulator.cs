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

namespace GPMCasstteConvertCIM.Emulators
{
    public partial class frmAGVS_Modbus_Emulator : Form
    {

        public frmAGVS_Modbus_Emulator(clsConverterPort linkedCasstteConverterPort)
        {
            InitializeComponent();
            uscagvsModbusClientEmulator1.casstte_port = linkedCasstteConverterPort;
        }

        public frmAGVS_Modbus_Emulator()
        {
            InitializeComponent();
        }

        private void frmAGVS_Modbus_Emulator_FormClosing(object sender, FormClosingEventArgs e)
        {
            uscagvsModbusClientEmulator1.CancelTask();
            Dispose();
        }

        private void uscagvsModbusClientEmulator1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            frmDemo demo_ = new frmDemo(uscagvsModbusClientEmulator1);
            demo_.Show();
        }

        private void frmAGVS_Modbus_Emulator_Load(object sender, EventArgs e)
        {

        }
    }
}
