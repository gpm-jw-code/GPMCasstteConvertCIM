using GPMCasstteConvertCIM.Alarm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPMCasstteConvertCIM.UI_UserControls
{
    public partial class UscAlarmTable : UserControl
    {
        public BindingList<clsAlarmDto> alarmListBinding;
        public UscAlarmTable()
        {
            InitializeComponent();
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
        }

        private void DataGridView1_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var alarm = dataGridView1.Rows[e.RowIndex].DataBoundItem as clsAlarmDto;
                if (alarm != null)
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = alarm.Level == ALARM_LEVEL.ALARM ? Color.Red : Color.Orange;
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                }

                var val = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (val is DateTime)
                {
                    e.Value = ((DateTime)val).ToString("yyyy/MM/dd HH:mm:ss");
                    e.FormattingApplied = true;
                }
            }
        }

        public void BindData(List<clsAlarmDto> alarms)
        {
            alarmListBinding = new BindingList<clsAlarmDto>(alarms);
            dataGridView1.DataSource = alarmListBinding;
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
