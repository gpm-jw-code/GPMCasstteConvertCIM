using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GPMCasstteConvertCIM.API.KGAGVS
{
    public partial class UnknownIDNotifyDialog : Form
    {
        public UnknownIDNotifyDialog()
        {
            InitializeComponent();
        }
        public string eqName = "";

        public event EventHandler<string> OnAcceptButtonClicked;

        internal void ShowDialog(EQLotIDMonitor.CarrierIDState e, string url = "http://localhost:6600")
        {
            eqName = e.EQName;
            linkLabel1.Links[0].LinkData = url;
            labCarrierID.Text = $"Carrier ID = [{e.CarrierID}]";
            labNotifyText.Text = $"【{e.DisplayName}】Carrier ID 未知\r\n請至派車系統修改帳籍";
            DisposeCountDown();
            base.ShowDialog();
        }
        private async Task DisposeCountDown()
        {
            progressBar1.Maximum = 300;
            progressBar1.Value = 300;
            countDowntimer.Enabled = true;
            //countDowntimer.Start();
            await Task.Delay(30000);
            Close();
            Dispose();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = e.Link.LinkData as string;

            if (string.IsNullOrEmpty(url))
            {
                url = linkLabel1.Text; // 如果 LinkData 为空，使用 LinkLabel 的文本
            }

            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法启动默认浏览器: " + ex.Message);
            }

            Close();
            Dispose();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            OnAcceptButtonClicked?.Invoke(this, eqName);
        }

        private void countDowntimer_Tick(object sender, EventArgs e)
        {
            progressBar1.Value--;
        }
    }
}
