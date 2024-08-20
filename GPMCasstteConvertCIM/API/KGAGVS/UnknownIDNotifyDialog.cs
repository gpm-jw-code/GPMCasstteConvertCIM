using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        internal void ShowDialog(EQLotIDMonitor.CarrierIDState e)
        {
            labCarrierID.Text = $"Carrier ID = [{e.CarrierID}]";
            labNotifyText.Text = $"【{e.EQName}】Carrier ID 未知\r\n請至派車系統修改帳籍";
            base.ShowDialog();
        }
    }
}
