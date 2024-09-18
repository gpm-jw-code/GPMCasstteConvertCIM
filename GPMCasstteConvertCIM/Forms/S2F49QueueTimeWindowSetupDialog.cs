using GPMCasstteConvertCIM.Utilities;
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
    public partial class S2F49QueueTimeWindowSetupDialog : Form
    {
        public S2F49QueueTimeWindowSetupDialog()
        {
            InitializeComponent();
        }

        private void S2F49QueueTimeWindowSetupDialog_Load(object sender, EventArgs e)
        {
            numud_time.Value = GPM_SECS.S2F49TransferQueueOperator.configuration.TimeWindow;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Utility.SysConfigs.S2F49QueuingConfigurations.TimeWindow =
            GPM_SECS.S2F49TransferQueueOperator.configuration.TimeWindow = (int)numud_time.Value;
            Utility.SaveConfigs();
            this.Close();
        }
    }
}
