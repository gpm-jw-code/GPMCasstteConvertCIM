using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPMCasstteConvertCIM.VirtualAGVSystem
{
    public partial class frmVirtualAGVS : Form
    {
        private string CarName = "AGV_1";
        private int AGV_ID = 1;

        private string LoadStationName = "37";
        private string ParkingStationName = "RACK_4_7|8|9";
        private string ParkingSlotName = "7";

        public frmVirtualAGVS()
        {
            InitializeComponent();

            dataGridView1.DataSource = VirtualAGVSystem.StaVirtualAGVS.AGVCList;
        }



        private void frmVirtualAGVS_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["ExtcuteTaskBtnColumn"].Index && e.RowIndex >= 0)
            {
                // Perform the desired action for the button cell click here.

                clsAGVCState agvc = (clsAGVCState)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                TaskDispatchDialog taskDispatchDialog = new TaskDispatchDialog(agvc)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                taskDispatchDialog.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StaVirtualAGVS.TaskDispatcher.TryGetConnectionCookies();
        }

        private async void btnSetCookie_Click(object sender, EventArgs e)
        {
            string cookies = await StaVirtualAGVS.TaskDispatcher.TryGetConnectionCookies();
            MessageBox.Show(cookies, " Cookie", MessageBoxButtons.OK, MessageBoxIcon.Information);

            StaVirtualAGVS.SetCookie(txbCookie_ConnectSid.Text, txb_Cookie_io.Text);
            MessageBox.Show("OK", "Set Cookie", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void WriteLog(string msg)
        {
            if (!Created)
                return;
            Invoke(new Action(() =>
            {
                string msgLine = $"{DateTime.Now} {msg}";
                rtbLog.AppendText(msgLine + "\n");
                rtbLog.ScrollToCaret();
            }));
        }

        private void frmVirtualAGVS_Load(object sender, EventArgs e)
        {
            txbCookie_ConnectSid.Text = StaVirtualAGVS.TaskDispatcher.Cookies.Cookies_Connect_SID;
            txb_Cookie_io.Text = StaVirtualAGVS.TaskDispatcher.Cookies.Cookies_io;
        }
    }
}
