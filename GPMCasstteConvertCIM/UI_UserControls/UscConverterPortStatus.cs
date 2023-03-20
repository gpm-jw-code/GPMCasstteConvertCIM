using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.Forms;
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
        public clsConverterPort portData { get; set; }
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
            Color active_color = Color.SeaGreen;
            labReadyStatusBit.RenderBGColorByState(portData.ReadyStatus, active_color);
            labLoadRequestBit.RenderBGColorByState(portData.LoadRequest, active_color);
            labUnloadRequestBit.RenderBGColorByState(portData.UnloadRequest, active_color);
            labPortExistBit.RenderBGColorByState(portData.PortExist, active_color);
            labL_REQBit.RenderBGColorByState(portData.L_REQ, active_color);
            labU_REQBit.RenderBGColorByState(portData.U_REQ, active_color);
            labReadyBit.RenderBGColorByState(portData.EQ_READY, active_color);
            labLOW_ReadyBit.RenderBGColorByState(portData.LOW_READY, active_color);

            labUpPosition.RenderBGColorByState(portData.LD_UP_POS, active_color);
            labDownPosition.RenderBGColorByState(portData.LD_DOWN_POS, active_color);

            active_color = Color.Pink;
            labLoading.RenderBGColorByState(portData.IsLoadHSRunning, active_color);
            labUnloading.RenderBGColorByState(portData.IsUnloadHSRunning, active_color);


            labAutoStatus.Text = portData.EPortAutoStatus.ToString();

            if (portData.EPortAutoStatus == CasstteConverter.Enums.AUTO_MANUAL_MODE.Unknown)
                labAutoStatus.BackColor = Color.Gray;
            else
                labAutoStatus.BackColor = portData.EPortAutoStatus == CasstteConverter.Enums.AUTO_MANUAL_MODE.AUTO ? Color.Green : Color.Orange;

        }

        private void label2_Click(object sender, EventArgs e)
        {
            frmPortEventReportTest testFrom = new frmPortEventReportTest(portData);
            testFrom.Show();
        }
    }
}
