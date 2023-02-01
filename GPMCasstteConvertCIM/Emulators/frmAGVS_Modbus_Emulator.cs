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
        public frmAGVS_Modbus_Emulator()
        {
            InitializeComponent();
        }

        private void frmAGVS_Modbus_Emulator_FormClosing(object sender, FormClosingEventArgs e)
        {
            uscagvsModbusClientEmulator1.CancelTask();
            Dispose();
        }
    }
}
