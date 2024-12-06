using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.Forms;
using GPMCasstteConvertCIM.Utilities;
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

                    StaUsersManager.OnRD_Login += StaUsersManager_OnRD_Login;
                    StaUsersManager.OnLogout += StaUsersManager_OnLogout;

                }
            }
        }

        private void StaUsersManager_OnLogout(object? sender, EventArgs e)
        {
            labPortTypeChgReq.Visible = labPortEventRepShow.Visible = false;
        }

        private void StaUsersManager_OnRD_Login(object? sender, EventArgs e)
        {
            labPortTypeChgReq.Visible = true;
        }

        public UscConverterPortStatus()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CstCVPort == null)
                return;
            if (!CstCVPort.EQParent.simulation_mode)
                txbWIP_BCR_ID.Text = CstCVPort.WIPINFO_BCR_ID;
            txbOnPortID.Text = CstCVPort.CSTIDOnPort;

            txbPortID.Text = CstCVPort.Properties.PortID;
            labCurrentPortMode.Text = CstCVPort.EPortType.ToString() + $"({(int)CstCVPort.EPortType})";
            Color active_color = Color.SeaGreen;

            labPortStatusDown.RenderBGColorByState(CstCVPort.PortStatusDownForceOn ? CstCVPort.PortStatusDownForceOn : CstCVPort.PortStatusDown, active_color);
            labLoadRequestBit.RenderBGColorByState(CstCVPort.LoadRequest, active_color);
            labUnloadRequestBit.RenderBGColorByState(CstCVPort.UnloadRequest, active_color);
            labPortExistBit.RenderBGColorByState(CstCVPort.PortExist, active_color);


            var hs_signal_actived_color = Color.Orange;
            lab_AGV_Valid.RenderBGColorByState(CstCVPort.AGV_VALID, hs_signal_actived_color);
            lab_AGV_TR.RenderBGColorByState(CstCVPort.AGV_TR_REQ, hs_signal_actived_color);
            lab_AGV_Busy.RenderBGColorByState(CstCVPort.AGV_BUSY, hs_signal_actived_color);
            lab_AGV_Ready.RenderBGColorByState(CstCVPort.AGV_READY, hs_signal_actived_color);
            lab_AGV_Compt.RenderBGColorByState(CstCVPort.AGV_BUSY, hs_signal_actived_color);

            labL_REQBit.RenderBGColorByState(CstCVPort.L_REQ, hs_signal_actived_color);
            labU_REQBit.RenderBGColorByState(CstCVPort.U_REQ, hs_signal_actived_color);
            labEQReadyBit.RenderBGColorByState(CstCVPort.EQ_READY, hs_signal_actived_color);
            labBusyBit.RenderBGColorByState(CstCVPort.EQ_BUSY, hs_signal_actived_color);

            ChangeAGVActionText();

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

            labWaitIn.RenderBGColorByState(CstCVPort.CarrierWaitINSystemRequest, Color.Red);
            labWaitOut.RenderBGColorByState(CstCVPort.CarrierWaitOUTSystemRequest, Color.Red);

            labCIMHandshakingWithAGV.Visible = CstCVPort.AGV_READY_WAITING_EQ_BUSYON_INTER_LOCKING;

            ChangeAGVAGVLDULDStatusText();

            labWaitIn.Text = !CstCVPort.wait_in_timer.IsRunning || !CstCVPort.CarrierWaitINSystemRequest ? "Wait In" : $"Wait In({Math.Round(CstCVPort.wait_in_timer.ElapsedMilliseconds / 1000.0, 2)})";

            txbWIP_BCR_ID.ReadOnly = !CstCVPort.EQParent.simulation_mode;
            btnUpdateCarrierID.Visible = StaUsersManager.CurrentUser.Group == StaUsersManager.USER_GROUP.GPM_RD;
        }

        private void ChangeAGVAGVLDULDStatusText()
        {
            bool has_lduld_req = CstCVPort.LoadRequest | CstCVPort.UnloadRequest;
            if (!has_lduld_req)
            {
                labLDULDStatus.Visible = false;
                return;
            }
            else
            {
                labLDULDStatus.Visible = true;
                bool IsStatusError = (CstCVPort.LoadRequest && CstCVPort.UnloadRequest);
                labLDULDStatus.Text = IsStatusError ? "移載狀態錯誤" : CstCVPort.LoadRequest ? "載具可移入" : "載具移出請求";
                labLDULDStatus.ForeColor = IsStatusError ? Color.Red : Color.Gray;
            }
        }

        private void ChangeAGVActionText()
        {

            labAGVReadyToTransfer.Text = "";
            labAGVReadyToTransfer.Visible = CstCVPort.CMD_Reserve_Low || CstCVPort.CMD_Reserve_Up || CstCVPort.AGV_VALID;

            bool IsWaitingToHS = (CstCVPort.CMD_Reserve_Up || CstCVPort.CMD_Reserve_Low) && !CstCVPort.AGV_VALID;
            if (IsWaitingToHS)
            {
                labAGVReadyToTransfer.Text = "AGV準備取放";
                return;
            }

            if (CstCVPort.AGV_VALID)
            {
                labAGVReadyToTransfer.Text = "AGV交握中..";
                return;
            }
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

        private void _CstCVPort_OnMCSNoTransferNotify(object? sender, Tuple<string, string, string> mcs_notify_dto)
        {
            Task.Factory.StartNew(() =>
            {
                MessageBox.Show($"NO TRANSFER TASK NOW NOTIFY -{mcs_notify_dto.Item3}\r\nPort ID = {mcs_notify_dto.Item1}\r\nCarrier ID = {mcs_notify_dto.Item2}", "NO TRANSFER TASK NOW NOTIFY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            });
        }

        private void labAutoStatus_DoubleClick(object sender, EventArgs e)
        {
            bool isOnline = CstCVPort.EQParent.X33_OnlineMode;
            //= !CstCVPort.EQParent.X33_OnlineMode;
        }

        private async void label2_Click_1(object sender, EventArgs e)
        {
            await CstCVPort.ModeChangeRequestHandshake(CstCVPort.EPortType == GPM_SECS.PortUnitType.Input ? GPM_SECS.PortUnitType.Output : GPM_SECS.PortUnitType.Input, "GPM_CIM");
        }

        private void txbWIP_BCR_ID_TextChanged(object sender, EventArgs e)
        {
            if (!CstCVPort.EQParent.simulation_mode)
                return;
        }

        private void btnUpdateCarrierID_Click(object sender, EventArgs e)
        {
            CstCVPort.WIPINFO_BCR_ID = txbWIP_BCR_ID.Text;
        }
    }
}
