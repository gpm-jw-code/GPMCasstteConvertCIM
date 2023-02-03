using GPMCasstteConvertCIM.CIM;
using GPMCasstteConvertCIM.GPM_SECS;
using GPMCasstteConvertCIM.GPM_SECS.Emulator;
using Secs4Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GPMCasstteConvertCIM.GPM_SECS.SECSMessageHelper;
using MsgHelper = GPMCasstteConvertCIM.GPM_SECS.SECSMessageHelper;

namespace GPMCasstteConvertCIM
{
    /// <summary>
    /// 模擬MCS發送 SECS MESSAGE
    /// </summary>
    public partial class frmMCSSimulator : Form
    {
        public frmMCSSimulator()
        {
            InitializeComponent();

            cmbPortTypeSelector.Items.AddRange(Enum.GetValues(typeof(PortUnitType)).Cast<object>().ToArray());
        }

        private async void btnEQOnlineRequest_Click(object sender, EventArgs e)
        {
            try
            {
                var crMsg = MsgHelper.COMMUNICATION.EstablishCommunicationRequestMessage("Model_SN_123", "v1.2.3");
                var secondMesg = await EmulatorManager.mcsEmulator.secsIF.secsGem.SendAsync(crMsg);

                if (secondMesg.TryGetConnectRequestAckResult(out MsgHelper.COMMACK ack, out string _mdln, out string softrev))
                {
                    if (ack != MsgHelper.COMMACK.Accepted)
                    {
                        MessageBox.Show($"Connect Establish Fail..{ack.ToString()}");
                        return;
                    }

                    // Send S1F17

                    var onlineReqMsg = MsgHelper.ONOFFLINE.OnLineRequestMessage();
                    var onlineReqMsgAck = await EmulatorManager.mcsEmulator.secsIF.secsGem.SendAsync(onlineReqMsg);
                    onlineReqMsgAck.TryGetOnlineRequestAckResult(out ONLACK online_ack);
                    if (online_ack == ONLACK.Not_Allowed)
                    {
                        MessageBox.Show($"要求EQP上線失敗 Fail..{online_ack.ToString()}");
                    }
                }

            }
            catch (Exception ex)
            {
                //Timeout exception
            }

        }

        private void frmMCSSimulator_Load(object sender, EventArgs e)
        {
        }

        private void frmMCSSimulator_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void btnEQOfflineRequest_Click(object sender, EventArgs e)
        {

            //send s1f15
            //await s1f16
            //eqp will send primary msg s6f11
            Task.Factory.StartNew(async () =>
            {
                try
                {
                    var offlineReqMsg = MsgHelper.ONOFFLINE.OffLineRequestMessage();
                    var secondMesg = await EmulatorManager.mcsEmulator.secsIF.secsGem.SendAsync(offlineReqMsg);

                }
                catch (Exception)
                {
                }
            });
        }

        private async void btnSendPortTypeChangeMsg_Click(object sender, EventArgs e)
        {
            var msg = MsgHelper.RemoteCommand.PortTypeChange(txbPortID.Text, (PortUnitType)cmbPortTypeSelector.SelectedItem);
            var rpt = await EmulatorManager.mcsEmulator.secsIF.SendAsync(msg);
        }
    }




    public class PortTypeChange
    {
        public string port_id { get; set; }
        public PortUnitType port_type { get; set; }
    }

}
