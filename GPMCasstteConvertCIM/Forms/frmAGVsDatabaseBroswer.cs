using GPMCasstteConvertCIM.DataBase.KGS_AGVs;
using GPMCasstteConvertCIM.DataBase.KGS_AGVs.Models;
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
    public partial class frmAGVsDatabaseBroswer : Form
    {
        public frmAGVsDatabaseBroswer()
        {
            InitializeComponent();
        }

        private void FrmAGVsDatabaseBroswer_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            dgvTaskHistory.DataSource = null;
            using AGVSDBHelper database = new AGVSDBHelper();
            DateTime from = new DateTime(start_date.Value.Year, start_date.Value.Month, start_date.Value.Day,
                start_time.Value.Hour, start_time.Value.Minute, start_time.Value.Second);

            DateTime to = new DateTime(end_date.Value.Year, end_date.Value.Month, end_date.Value.Day,
                end_time.Value.Hour, end_time.Value.Minute, end_time.Value.Second);
            List<DataBase.KGS_AGVs.Models.TaskDto> tasks = database.QueryTask(from, to, txbAssignUserName.Text);
            dgvTaskHistory.DataSource = tasks;
            dgvTaskHistory.Invalidate();
        }

        private void DgvTaskHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 | e.RowIndex == -1)
                return;
            TaskDto? data = dgvTaskHistory.Rows[e.RowIndex].DataBoundItem as TaskDto;
            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("確定刪除此筆任務資料?", "Task History Delete Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    return;

                using var db = new AGVSDBHelper();
                if (db.DeleteTask(data))
                {
                    BtnQuery_Click(sender, EventArgs.Empty);
                }
            }
        }
    }
}
