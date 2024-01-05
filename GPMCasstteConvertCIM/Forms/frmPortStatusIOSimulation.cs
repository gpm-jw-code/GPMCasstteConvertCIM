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
            ckbEQ_READY.Visible = ckbEQ_BUSY.Visible = ckbEQ_L_REQ.Visible = ckbEQ_U_REQ.Visible = DevicesManager.cclink_master.simulation_mode;
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
            ChnageIndicator(LDULD_STATUS.DOWN);
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

        private void CkbEQ_L_REQ_CheckedChanged(object sender, EventArgs e)
        {
            DevicesManager.cclink_master.EQPMemOptions.memoryTable.WriteOneBit(port.PortEQBitAddress[Enums.PROPERTY.L_REQ], ckbEQ_L_REQ.Checked);

        }

        private void CkbEQ_U_REQ_CheckedChanged(object sender, EventArgs e)
        {
            DevicesManager.cclink_master.EQPMemOptions.memoryTable.WriteOneBit(port.PortEQBitAddress[Enums.PROPERTY.U_REQ], ckbEQ_U_REQ.Checked);

        }

        private void CkbEQ_READY_CheckedChanged(object sender, EventArgs e)
        {
            DevicesManager.cclink_master.EQPMemOptions.memoryTable.WriteOneBit(port.PortEQBitAddress[Enums.PROPERTY.EQ_READY], ckbEQ_READY.Checked);
        }

        private void CkbEQ_BUSY_CheckedChanged(object sender, EventArgs e)
        {
            DevicesManager.cclink_master.EQPMemOptions.memoryTable.WriteOneBit(port.PortEQBitAddress[Enums.PROPERTY.EQ_BUSY], ckbEQ_BUSY.Checked);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            ckb_agv_valid.Checked = port.agv_hs_status.AGV_VALID;
            ckb_agv_tr_req.Checked = port.agv_hs_status.AGV_TR_REQ;
            ckb_agv_busy.Checked = port.agv_hs_status.AGV_BUSY;
            ckb_agv_ready.Checked = port.agv_hs_status.AGV_READY;
            ckb_agv_compt.Checked = port.agv_hs_status.AGV_COMPT;
        }
    }
}
