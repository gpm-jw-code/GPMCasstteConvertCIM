using GPMCasstteConvertCIM.GPM_Modbus;
using GPMCasstteConvertCIM.GPM_SECS;
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
    public partial class frmTransferCommandsViewer : Form
    {

        BindingList<TransferCommandModel> transferCommands = new BindingList<TransferCommandModel>();
        public frmTransferCommandsViewer()
        {
            InitializeComponent();
        }

        private void frmTransferCommandsViewer_Load(object sender, EventArgs e)
        {
            transferCommands = new BindingList<TransferCommandModel>(S2F49TransferQueueOperator.transferCommandsRecord);
            dataGridView1.DataSource = transferCommands;
        }
    }
}
