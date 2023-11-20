using GPMCasstteConvertCIM.DataBase.KGS_AGVs;
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
    public partial class UscAGVsInfo : UserControl
    {
        BindingList<DataBase.KGS_AGVs.Models.ExecutingTask> DataSource = new BindingList<DataBase.KGS_AGVs.Models.ExecutingTask>();
        public UscAGVsInfo()
        {
            InitializeComponent();
        }

        private void UscAGVsInfo_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataSource;
            AGVSDBHelper.OnExecutingTasksUpdated += (sender, e) =>
            {
                var _DataSource = AGVSDBHelper.ExecutingTaskList;
                if (_DataSource.ToJson() != DataSource.ToJson())
                {
                    DataSource = new BindingList<DataBase.KGS_AGVs.Models.ExecutingTask>(_DataSource);

                    this.Invoke(new Action(() =>
                    {
                        dataGridView1.DataSource = DataSource;
                    }));

                }

            };
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
