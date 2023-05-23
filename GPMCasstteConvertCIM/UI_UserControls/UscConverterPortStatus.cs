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
        public clsConverterPort CstCVPort { get; set; }
        public UscConverterPortStatus()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CstCVPort == null)
                return;
            txbWIP_BCR_ID.Text = CstCVPort.WIPINFO_BCR_ID;
            labPortID.Text = CstCVPort.Properties.PortID;

            labCurrentPortMode.Text = CstCVPort.EPortType.ToString();
            Color active_color = Color.SeaGreen;

            labPortStatusDown.RenderBGColorByState(CstCVPort.PortStatusDown, active_color);
            labLoadRequestBit.RenderBGColorByState(CstCVPort.LoadRequest, active_color);
            labUnloadRequestBit.RenderBGColorByState(CstCVPort.UnloadRequest, active_color);
            labPortExistBit.RenderBGColorByState(CstCVPort.PortExist, active_color);
            labL_REQBit.RenderBGColorByState(CstCVPort.L_REQ, active_color);
            labU_REQBit.RenderBGColorByState(CstCVPort.U_REQ, active_color);
            labEQReadyBit.RenderBGColorByState(CstCVPort.EQ_READY, active_color);
            labBusyBit.RenderBGColorByState(CstCVPort.EQ_BUSY, active_color);

            labUpPosition.RenderBGColorByState(CstCVPort.LD_UP_POS, active_color);
            labDownPosition.RenderBGColorByState(CstCVPort.LD_DOWN_POS, active_color);

            active_color = Color.Pink;
            labLoading.RenderBGColorByState(CstCVPort.IsLoadHSRunning, active_color);
            labUnloading.RenderBGColorByState(CstCVPort.IsUnloadHSRunning, active_color);


            labAutoStatus.Text = CstCVPort.EPortAutoStatus.ToString();

            if (CstCVPort.EPortAutoStatus == CasstteConverter.Enums.AUTO_MANUAL_MODE.Unknown)
                labAutoStatus.BackColor = Color.Gray;
            else
                labAutoStatus.BackColor = CstCVPort.EPortAutoStatus == CasstteConverter.Enums.AUTO_MANUAL_MODE.AUTO ? Color.Green : Color.Orange;


            labServiceStatusText.Text = CstCVPort.Properties.InSerivce ? "In Service" : "Out of Service";
            labServiceStatusText.ForeColor = CstCVPort.Properties.InSerivce ? Color.SeaGreen : Color.Red;

        }

        private void label2_Click(object sender, EventArgs e)
        {
            frmPortEventReportTest testFrom = new frmPortEventReportTest(CstCVPort);
            testFrom.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            CstCVPort.modbus_server.UI.Show();
        }
    }
}
