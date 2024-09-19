using GPMCasstteConvertCIM.DataBase.KGS_AGVs;
using GPMCasstteConvertCIM.Utilities;
using KGSWebAGVSystemAPI;
using KGSWebAGVSystemAPI.User;
using System.ComponentModel;
using System.Text;

namespace GPMCasstteConvertCIM.Forms
{
    public partial class frmKGSWebAGVSystem : Form
    {
        private WebAGVSystemDBBackgroundWorker webAGVSystemDBBackground;
        private BindingList<KGSWebAGVSystemAPI.Models.ExecutingTask> taskList;
        private BindingList<KGSWebAGVSystemAPI.Models.Task> taskHistory;
        public bool IsAutoRefreshEnabled => autoRefreshToolStripMenuItem.CheckState == CheckState.Checked;
        public frmKGSWebAGVSystem()
        {
            InitializeComponent();
        }

        public frmKGSWebAGVSystem(WebAGVSystemDBBackgroundWorker webAGVSystemDBBackground)
        {
            this.webAGVSystemDBBackground = webAGVSystemDBBackground;
            InitializeComponent();
        }

        private void frmKGSWebAGVSystem_Load(object sender, EventArgs e)
        {
            UpdateConnectionInfoDisplayFromConfiguration();
            BindingTasksData();
            autoRefreshTimer.Enabled = true;
            autoRefreshToolStripMenuItem.CheckState = CheckState.Checked;
            Auth.OnUserLoginStart += Auth_OnUserLoginStart;
            Auth.OnUserLoginSuccess += Auth_OnUserLoginSuccess;
            Auth.OnUserLoginFailure += Auth_OnUserLoginFailure;
        }

        private void Auth_OnUserLoginFailure(object? sender, (string userName, string password, string sid, string io) e)
        {
            if (string.IsNullOrEmpty(e.userName) && string.IsNullOrEmpty(e.sid))
                tlabWebServerActionInfo.Text = $"Login FAILURE: Couldn't Get SID From Website-{Globals.KGSWebAGVSystemAPI}";
            else
                tlabWebServerActionInfo.Text = $"Login FAILURE with {e.userName}/{e.password}!";
        }

        private void Auth_OnUserLoginSuccess(object? sender, (string userName, string password, string sid, string io) e)
        {
            tlabWebServerActionInfo.Text = $"Login Success with {e.userName}/{e.password}!";
        }

        private void Auth_OnUserLoginStart(object? sender, (string userName, string password, string sid, string io) e)
        {
            tlabWebServerActionInfo.Text = $"Try Login with {e.userName}/{e.password}...";
        }

        public void UpdateConnectionInfoDisplayFromConfiguration()
        {
            tlabDBConnectionStr.Text = Utility.SysConfigs.KGSDBConnectionString;
            tlabKGAGVSAPIUrl.Text = KGSWebAGVSystemAPI.Globals.KGSHotIP + ":" + KGSWebAGVSystemAPI.Globals.KGSHotPort;
        }

        private async Task BindingTasksData()
        {
            await Task.Delay(300);
            BindingExecutingTask();
            BindingHistoryTasks();
        }

        private void BindingHistoryTasks()
        {
            dgvTaskHistory.DataSource = null;
            taskHistory = new BindingList<KGSWebAGVSystemAPI.Models.Task>(webAGVSystemDBBackground.taskHistory);
            dgvTaskHistory.DataSource = taskHistory;
        }

        private void BindingExecutingTask()
        {

            dgvExecutingTask.DataSource = null;
            taskList = new BindingList<KGSWebAGVSystemAPI.Models.ExecutingTask>(webAGVSystemDBBackground.excutingTasks);
            dgvExecutingTask.DataSource = taskList;
        }

        private void frmKGSWebAGVSystem_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BindingTasksData();
        }

        private async void dgvTaskHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                string taskName = (dgvTaskHistory.Rows[e.RowIndex].DataBoundItem as KGSWebAGVSystemAPI.Models.Task).Name;
                //confirm first
                DialogResult result = MessageBox.Show($"確定要刪除歷史任務[{taskName}]?", "刪除歷史任務確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                    return;


                int deleteCnt = await webAGVSystemDBBackground.DeleteTask(taskName);
                if (deleteCnt != 0 && !IsAutoRefreshEnabled)
                {
                    await Task.Delay(200);
                    BindingHistoryTasks();
                }
            }
        }

        private async void dgvExecutingTask_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                try
                {
                    string taskName = (dgvExecutingTask.Rows[e.RowIndex].DataBoundItem as KGSWebAGVSystemAPI.Models.ExecutingTask).Name;

                    //confirm first
                    DialogResult result = MessageBox.Show($"確定要取消任務[{taskName}]?", "取消任務確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Cancel)
                        return;

                    string response = await KGSWebAGVSystemAPI.TaskOrder.OrderAPI.CancelTask(taskName);

                    if (!IsAutoRefreshEnabled)
                    {
                        await Task.Delay(200);
                        BindingExecutingTask();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "取消任務失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void dgvTaskHistory_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            // set table current selected row is e.RowIndex
        }

        private async void dgvTaskHistory_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
                dgvTaskHistory.Rows[e.RowIndex].Selected = true;
        }

        private void dgvExecutingTask_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
                dgvExecutingTask.Rows[e.RowIndex].Selected = true;
        }

        private void autoRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autoRefreshToolStripMenuItem.CheckState = autoRefreshToolStripMenuItem.CheckState == CheckState.Unchecked ?
                                                       CheckState.Checked : CheckState.Unchecked;
            autoRefreshTimer.Enabled = autoRefreshToolStripMenuItem.CheckState == CheckState.Checked;
        }
        string lastExecutingTaskNameAssemble = "";
        string lastHistoryTaskNameAssemble = "";
        private void autoRefreshTimer_Tick(object sender, EventArgs e)
        {


            var _lastExecutingTaskNameAssemble = GetTaskNameAssemble(webAGVSystemDBBackground.excutingTasks);
            var _lastHistoryTaskNameAssemble = GetTaskNameAssemble(webAGVSystemDBBackground.taskHistory);

            if (_lastExecutingTaskNameAssemble != lastExecutingTaskNameAssemble)
            {
                BindingExecutingTask();
            }
            if (_lastHistoryTaskNameAssemble != lastHistoryTaskNameAssemble)
            {
                BindingHistoryTasks();
            }

            lastExecutingTaskNameAssemble = _lastExecutingTaskNameAssemble;
            lastHistoryTaskNameAssemble = _lastHistoryTaskNameAssemble;
        }

        private string GetTaskNameAssemble(IEnumerable<KGSWebAGVSystemAPI.Models.ExecutingTask> tasks)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in tasks)
            {
                sb.Append(item.Name);
            }
            return sb.ToString();
        }

        private string GetTaskNameAssemble(IEnumerable<KGSWebAGVSystemAPI.Models.Task> tasks)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in tasks)
            {
                sb.Append(item.Name);
            }
            return sb.ToString();
        }
    }
}
