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

namespace GPMCasstteConvertCIM.API.KGAGVS
{
    public partial class UnknownIDNotifyDialog : Form
    {
        public UnknownIDNotifyDialog()
        {
            InitializeComponent();
        }

        internal void ShowDialog(EQLotIDMonitor.CarrierIDState e, string url = "http://localhost:6600")
        {
            linkLabel1.Links[0].LinkData = url;
            labCarrierID.Text = $"Carrier ID = [{e.CarrierID}]";
            labNotifyText.Text = $"【{e.DisplayName}】Carrier ID 未知\r\n請至派車系統修改帳籍";
            base.ShowDialog();
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
    }
}
