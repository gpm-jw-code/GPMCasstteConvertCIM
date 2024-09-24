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
            BindingTableData();
        }

        private void BindingTableData()
        {
            List<TransferCommandModel> ordered = S2F49TransferQueueOperator.transferCommandsRecord.OrderByDescending(t => t.Time).ToList();
            transferCommands = new BindingList<TransferCommandModel>(ordered);
            dataGridView1.DataSource = transferCommands;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindingTableData();
        }
    }
}
