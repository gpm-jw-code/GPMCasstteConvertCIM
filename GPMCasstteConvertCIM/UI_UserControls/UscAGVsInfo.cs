using GPMCasstteConvertCIM.DataBase.KGS_AGVs;
using System.ComponentModel;

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
        }
        private void Worker()
        {
            var db = new AGVSDBHelper();

            dataGridView1.DataSource = db.GetExecutingTasks();
        }
     

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var database = new AGVSDBHelper();
            database.ClearExecutingTasks();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var database = new AGVSDBHelper();
            database.ADD_TASK(new DataBase.KGS_AGVs.Models.ExecutingTask
            {
                AcquireTime = DateTime.Now,
                DepositTime = DateTime.Now,
                Receive_Time = DateTime.Now,
                StartTime = DateTime.Now,
                Name = $"Task-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}",
                AGVID = 1,
                ExeVehicleID = 1,
                CSTID = "",
                ActionType = "Transfer",
                AssignUserName = "RD",
                CSTType = 1,
                FromStation = "2",
                FromStationId = 2,
                FromStationName = "2-AA",
                FromStationPortNo = 2,
                ToStation = "3",
                ToStationId = 3,
                ToStationName = "3-BB",

            });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Worker();
        }
    }
}
