using GPMCasstteConvertCIM.CasstteConverter.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPMCasstteConvertCIM.UI_UserControls
{
    public partial class UscConverterPortStatus : UserControl
    {
        public clsPortData portData { get; set; }
        public UscConverterPortStatus()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (portData == null)
                return;
            txbWIP_BCR_ID.Text = portData.WIPINFO_BCR_ID;

            labCurrentPortMode.Text = portData.EPortModeStatus.ToString().ToUpper();
            //labCurrentRackMode.Text = portData.ERackModeStatus.ToString();

            labReadyStatusBit.ToBitState(portData.ReadyStatus);
            labLoadRequestBit.ToBitState(portData.LoadRequest);
            labUnloadRequestBit.ToBitState(portData.UnloadRequest);
            labPortExistBit.ToBitState(portData.PortExist);
            labEQPStatusRunBit.ToBitState(portData.EQP_Status_Run);
            labEQPStatusIdleBit.ToBitState(portData.EQP_Status_Idle);
            labEQPStatusDownBit.ToBitState(portData.EQP_Status_Down);
            labL_REQBit.ToBitState(portData.L_REQ);
            labU_REQBit.ToBitState(portData.U_REQ);
            labReadyBit.ToBitState(portData.EQ_READY);
            labUP_ReadyBit.ToBitState(portData.UP_READY);
            labLOW_ReadyBit.ToBitState(portData.LOW_READY);
            labMode_Change_Request.ToBitState(portData.Mode_Change_Request);

            labUpPosition.ToBitState(portData.LD_UP_POS);
            labDownPosition.ToBitState(portData.LD_DOWN_POS);
        }
    }
}
