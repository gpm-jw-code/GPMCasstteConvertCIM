using GPMCasstteConvertCIM.DataBase.KGS_AGVs;
using GPMCasstteConvertCIM.Utilities;
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
            pnlDebug.Visible = StaUsersManager.CurrentUser.Group != StaUsersManager.USER_GROUP.VISITOR;
            StaUsersManager.OnRD_Login += StaUsersManager_OnRD_Login;
            StaUsersManager.OnLogout += StaUsersManager_OnLogout;
            var splited = AGVSDBHelper.DBConnection.Split(";");
            labConnection.Text = string.Join(";", new string[3] { splited[0], splited[1], splited[2] });
            timer1.Enabled = true;
        }

        private void StaUsersManager_OnLogout(object? sender, EventArgs e)
        {
            pnlDebug.Visible = false;
        }

        private void StaUsersManager_OnRD_Login(object? sender, EventArgs e)
        {
            pnlDebug.Visible = true;
        }

        private void Worker()
        {
            try
            {
                var db = new AGVSDBHelper();
                dataGridView1.DataSource = db.GetExecutingTasks();
            }
            catch (Exception)
            {

            }
        }


        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var database = new AGVSDBHelper();
            database.ClearExecutingTasks();
        }
        private string lastFakeTaskName = "";
        private void button1_Click(object sender, EventArgs e)
        {

            var database = new AGVSDBHelper();
            if (lastFakeTaskName != "")
                database.RemoveTaskByID(lastFakeTaskName);

            lastFakeTaskName = $"Task-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}";
            database.ADD_TASK(new DataBase.KGS_AGVs.Models.ExecutingTask
            {
                AcquireTime = DateTime.Now,
                DepositTime = DateTime.Now,
                Receive_Time = DateTime.Now,
                StartTime = DateTime.Now,
                Name = lastFakeTaskName,
                AGVID = 1,
                ExeVehicleID = 1,
                CSTID = "",
                ActionType = "Transfer",
                AssignUserName = "RD",
                CSTType = 1,
                FromStation = "186",
                FromStationId = 186,
                FromStationName = "2-AA",
                FromStationPortNo = 2,
                ToStation = "195",
                ToStationId = 195,
                ToStationName = "3-BB",

            });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Worker();
        }
    }
}
