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
    public partial class frmPortEventReportTest : Form
    {
        private readonly clsConverterPort portData;

        public frmPortEventReportTest(clsConverterPort portData)
        {
            this.portData = portData;
            InitializeComponent();
        }

        private void btnInServiceReport_Click(object sender, EventArgs e)
        {
            portData.SecsEventReport(GPM_SECS.CEID.PortInServiceReport);
        }

        private void btnOutOfServiceReport_Click(object sender, EventArgs e)
        {
            portData.SecsEventReport(GPM_SECS.CEID.PortOutOfServiceReport);
        }


        private void btnPortTypeInputReport_Click(object sender, EventArgs e)
        {
            portData.SecsEventReport(GPM_SECS.CEID.PortTypeInputReport);

        }

        private void btnPortTypeOutputReport_Click(object sender, EventArgs e)
        {
            portData.SecsEventReport(GPM_SECS.CEID.PortTypeOutputReport);

        }

        private void frmPortEventReportTest_Load(object sender, EventArgs e)
        {

        }
    }
}
