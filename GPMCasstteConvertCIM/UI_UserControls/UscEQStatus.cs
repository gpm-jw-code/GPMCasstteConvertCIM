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

namespace GPMCasstteConvertCIM.UI_UserControls
{
    public partial class UscEQStatus : UserControl
    {


        public BindingList<clsConverterPort> BindingPorts;
        /// <summary>
        /// 
        /// </summary>
        public UscEQStatus()
        {
            InitializeComponent();


        }

        internal void BindData(List<clsConverterPort> allEqPortList)
        {
            BindingPorts = new BindingList<clsConverterPort>(allEqPortList);
            dataGridView1.DataSource = BindingPorts;
        }

        ///
        //uscAlarmTable1.BindData(AlarmManager.AlarmsList);
        //    AlarmManager.onAlarmAdded += (sender, arg) => { uscAlarmTable1.alarmListBinding.ResetBindings(); };
    }
}
