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

namespace GPMCasstteConvertCIM.UI_UserControls
{
    public partial class UscCasstteConverter : UserControl
    {
        frmConvertPLCMemoryTables MemoryTable = new frmConvertPLCMemoryTables();
        frmConverterPLCSimulator PLCSimulator = new frmConverterPLCSimulator();

        private clsCasstteConverter _casstteConverter;
        internal clsCasstteConverter casstteConverter
        {
            get => _casstteConverter;
            set
            {
                PLCSimulator.CasstteConverter = MemoryTable.CasstteConverter = _casstteConverter = value;
                uscConverterPortStatus1.portData = _casstteConverter.EQPData.PortDatas[0];
                uscConverterPortStatus2.portData = _casstteConverter.EQPData.PortDatas[1];


            }
        }
        public string NameDisplay
        {
            get => labNameDisplay.Text;
            set => labNameDisplay.Text = value;
        }
        public UscCasstteConverter()
        {
            InitializeComponent();
        }

        private void UscCasstteConverter_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (casstteConverter == null)
                return;

            try
            {
                labPLCMCAddress.Text = string.Format("{0}:{1}", _casstteConverter.mcInterfaceOptions.RemoteIP, _casstteConverter.mcInterfaceOptions.RemotePort);

                var eqpData = casstteConverter.EQPData;
                var btnRun_BackColor = eqpData.EQP_RUN ? Color.SeaGreen : Color.Black;
                var btnIdle_BackColor = eqpData.EQP_IDLE ? Color.Yellow : Color.Black;
                var btnDown_BackColor = eqpData.EQP_DOWN ? Color.Red : Color.Black;

                if (btnRun.BackColor != btnRun_BackColor)
                    btnRun.BackColor = btnRun_BackColor;

                if (btnIDLE.BackColor != btnIdle_BackColor)
                {
                    btnIDLE.BackColor = btnIdle_BackColor;
                    btnIDLE.ForeColor = btnIdle_BackColor == Color.Yellow ? Color.Black : Color.White;
                }

                if (btnDown.BackColor != btnDown_BackColor)
                    btnDown.BackColor = btnDown_BackColor;


                labPLCConnectState.Text = _casstteConverter.connectionState.ToString();
            }
            catch (Exception ex)
            {
            }


            //txbWIP_BCR_ID.Text = eqpData.WIPINFO_BCR_ID;
            //txbWIP_LOC.Text = eqpData.WIPINFO_LOC;
            //txbManualLoadBCR.Text = eqpData.ManualLoad_BCR_ID;
            //txbManualUnloadBCR.Text = eqpData.ManuaUnlLoad_BCR_ID;

            //labCurrentPortMode.Text = eqpData.EPortModeStatus.ToString();
            //labCurrentRackMode.Text = eqpData.ERackModeStatus.ToString();

            //labReadyStatusBit.ToBitState(eqpData.ReadyStatus);
            //labLoadRequestBit.ToBitState(eqpData.LoadRequest);
            //labUnloadRequestBit.ToBitState(eqpData.UnloadRequest);
            //labPortExistBit.ToBitState(eqpData.PortExist);
            //labEQPStatusRunBit.ToBitState(eqpData.EQP_Status_Run);
            //labEQPStatusIdleBit.ToBitState(eqpData.EQP_Status_Idle);
            //labEQPStatusDownBit.ToBitState(eqpData.EQP_Status_Down);
            //labL_REQBit.ToBitState(eqpData.L_REQ);
            //labU_REQBit.ToBitState(eqpData.U_REQ);
            //labReadyBit.ToBitState(eqpData.READY);
            //labUP_ReadyBit.ToBitState(eqpData.UP_READY);
            //labLOW_ReadyBit.ToBitState(eqpData.LOW_READY);
            //labMode_Change_Request.ToBitState(eqpData.Mode_Change_Request);
        }

        private void btnOpenMemoryTable_Click(object sender, EventArgs e)
        {
            MemoryTable.Show();
        }

        private void btnOpenConvertPLCSimulator_Click(object sender, EventArgs e)
        {
            OpenConvertPLCSumulator();
        }

        public void OpenConvertPLCSumulator()
        {
            PLCSimulator.Show();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {

        }

        private void btnIDLE_Click(object sender, EventArgs e)
        {

        }

        private void btnRun_Click(object sender, EventArgs e)
        {

        }

        private void btnSoftwareEMO_Click(object sender, EventArgs e)
        {
            casstteConverter.CIMinputMemOptions.memoryTable.WriteOneBit("X100", true);
        }

        private void btnAlarmReset_Click(object sender, EventArgs e)
        {
            casstteConverter.AlarmResetFlag = true;
        }
    }
}
