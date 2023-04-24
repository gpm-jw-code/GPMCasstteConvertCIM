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
