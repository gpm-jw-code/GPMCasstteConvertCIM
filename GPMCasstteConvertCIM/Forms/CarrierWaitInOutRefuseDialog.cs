using GPMCasstteConvertCIM.CasstteConverter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPMCasstteConvertCIM.Forms
{
    public partial class CarrierWaitInOutRefuseDialog : Form
    {
        public CarrierWaitInOutRefuseDialog()
        {
            InitializeComponent();
        }

        private void CarrierWaitInOutRefuseDialog_Load(object sender, EventArgs e)
        {

        }
        public clsConverterPort _port { get; private set; }
        private DateTime eventTriggerTime;
        public new void ShowDialog(clsConverterPort port)
        {
            _port = port;
            labPortName.Text = port.PortName;
            labCarrierID.Text = port.WIPINFO_BCR_ID;
            eventTriggerTime = DateTime.Now;
            labTime.Text = eventTriggerTime.ToString("yyyy/MM/dd HH:mm:ss");
            ckbPortExistCheck.Checked = port.PortExist;
            ckbCarrierIDReadDone.Checked = port.WIPINFO_BCR_ID != "";

            ckbPortExistCheck.ForeColor = ckbPortExistCheck.Checked ? Color.Black : Color.Red;
            ckbCarrierIDReadDone.ForeColor = ckbCarrierIDReadDone.Checked ? Color.Black : Color.Red;
            var timer = new System.Windows.Forms.Timer()
            {
                Interval = 1000
            };
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
            base.ShowDialog();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            var passed_time_sec = (DateTime.Now - eventTriggerTime).TotalSeconds;
            labTimePassed.Text = $"({Math.Round(passed_time_sec, 0)}s ago)";
        }

        private void ckbsCheck_Click(object sender, EventArgs e)
        {
            ckbPortExistCheck.Checked = _port.PortExist;
            ckbCarrierIDReadDone.Checked = _port.WIPINFO_BCR_ID != "";
        }
    }
}
