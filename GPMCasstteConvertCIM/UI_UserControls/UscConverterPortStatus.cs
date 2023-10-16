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
        private clsConverterPort _CstCVPort;
        public clsConverterPort CstCVPort
        {
            get => _CstCVPort;
            set
            {
                _CstCVPort = value;
                if (_CstCVPort != null)
                {
                    _CstCVPort.OnMCSNoTransferNotify += _CstCVPort_OnMCSNoTransferNotify;
                    _CstCVPort.OnWaitOutRefuseByCIM += HandleCVPortWaitOutRefuseByCIM;
                }
            }
        }

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

            labPortStatusDown.RenderBGColorByState(CstCVPort.PortStatusDownForceOn ? CstCVPort.PortStatusDownForceOn : CstCVPort.PortStatusDown, active_color);
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
            labServiceStatusText.ForeColor = CstCVPort.Properties.InSerivce ? Color.FromArgb(0, 57, 155) : Color.Red;

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

        private void labPortStatusDown_DoubleClick(object sender, EventArgs e)
        {
            if (CstCVPort.PortStatusDownForceOn)
            {
                if (DialogResult.OK == MessageBox.Show("確定要將PortStatusDownForceOn OFF? ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                {
                    CstCVPort.PortStatusDownForceOn = false;
                }
                return;
            }
            if (CstCVPort.PortStatusDown == false)
            {
                if (DialogResult.OK == MessageBox.Show("確定要強制將Port Status Down ON? ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                {
                    CstCVPort.PortStatusDownForceOn = true;
                }
            }
        }

        private void HandleCVPortWaitOutRefuseByCIM(object? sender, clsConverterPort e)
        {
            Task.Factory.StartNew(() =>
            {
                Form frm = new Form()
                {
                    TopMost = true,
                    TopLevel = true,
                    StartPosition = FormStartPosition.CenterScreen
                };
                frm.BringToFront();
                if (MessageBox.Show(frm, $"轉換架Wait Out請求異常(轉換架內無貨物)", $"{DateTime.Now} | Carrier Wait Out Abnormal Suituation", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    frm.Dispose();
                }
            });
        }

        private void _CstCVPort_OnMCSNoTransferNotify(object? sender, Tuple<string, string> mcs_notify_dto)
        {
            Task.Factory.StartNew(() =>
            {
                MessageBox.Show($"MCS NO TRANSFER TASK NOW NOTIFY !  \r\nPort ID = {mcs_notify_dto.Item1}\r\nCarrier ID = {mcs_notify_dto.Item2}", "MCS Notifier", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            });
        }

        private void labAutoStatus_DoubleClick(object sender, EventArgs e)
        {
            bool isOnline = CstCVPort.EQParent.X33_OnlineMode;
            //= !CstCVPort.EQParent.X33_OnlineMode;
        }
    }
}
