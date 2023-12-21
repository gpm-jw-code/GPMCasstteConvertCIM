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
using static GPMCasstteConvertCIM.CasstteConverter.clsConverterPort;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GPMCasstteConvertCIM.Forms
{
    public partial class frmPortStatusIOSimulation : Form
    {
        public clsConverterPort port { get; private set; }

        public frmPortStatusIOSimulation()
        {
            InitializeComponent();
        }

        private void frmPortStatusIOSimulation_Load(object sender, EventArgs e)
        {

        }
        public new void ShowDialog(clsConverterPort port)
        {
            this.port = port;
            this.Text = $"Port Status Simulator-{port.PortName}";
            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
            comboBox1.SelectedIndex = port.IsIOSimulating ? 0 : 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            ChnageIndicator(port.LDULD_Status_Simulation);
            base.ShowDialog();
        }

        private void btnLoadable_Click(object sender, EventArgs e)
        {
            port.LDULD_Status_Simulation = LDULD_STATUS.LOADABLE;
            ChnageIndicator(LDULD_STATUS.LOADABLE);
        }

        private void btnUnloadable_Click(object sender, EventArgs e)
        {
            port.LDULD_Status_Simulation = LDULD_STATUS.UNLOADABLE;
            ChnageIndicator(LDULD_STATUS.UNLOADABLE);

        }

        private void btnDownStatus_Click(object sender, EventArgs e)
        {
            port.LDULD_Status_Simulation = LDULD_STATUS.DOWN;
            ChnageIndicator( LDULD_STATUS.DOWN);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            port.IOSignalMode = comboBox1.SelectedIndex == 0 ? Enums.IO_MODE.FromCIMSimulation : Enums.IO_MODE.FromIOModule;
            port.RaiseStatusIOChangeInvoke();

        }

        private void ChnageIndicator(LDULD_STATUS status)
        {
            tlpIndicatorContainer.Controls.Add(labIndicator, 0, status == LDULD_STATUS.LOADABLE ? 0 : status == LDULD_STATUS.UNLOADABLE ? 1 : 2);
        }
    }
}
