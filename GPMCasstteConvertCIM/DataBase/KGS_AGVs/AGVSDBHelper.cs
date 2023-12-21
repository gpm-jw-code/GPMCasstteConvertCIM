using GPMCasstteConvertCIM.DataBase.KGS_AGVs.Models;
using GPMCasstteConvertCIM.Utilities;
using GPMCasstteConvertCIM.Utilities.SysConfigs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.DataBase.KGS_AGVs
{
    public class AGVSDBHelper : IDisposable
    {

        public static string DBConnection = "Server=127.0.0.1;Database=WebAGVSystem;User Id=sa;Password=12345678;Encrypt=False";
        public static event EventHandler<clsNewTaskObj> OnAGVStartNewTask;
        public static BindingList<ExecutingTask> ExecutingTaskList = new BindingList<ExecutingTask>();
        public static event EventHandler OnExecutingTasksUpdated;
        public static event EventHandler OnExecutingTasksALLClear;
        public static event EventHandler<string> OnError;

        private static LoggerBase logger;
        private bool disposedValue;

        public class clsNewTaskObj : clsAGVInfo
        {
            public ExecutingTask OrderInfo { get; set; } = new ExecutingTask();
        }
        public static bool Init(LoggerBase _logger, out string errMsg, bool EnsureCreated = false, string connectionStr = null)
        {
            logger = _logger;
            errMsg = string.Empty;
            try
            {
                if (connectionStr != null)
                {
                    DBConnection = connectionStr;
                }
                logger.Info($"Init AGVs Database:{DBConnection}...");
                var helper = new AGVSDBHelper();
                if (EnsureCreated)
                {
                    helper.DBConn.Database.EnsureCreated();
                    helper.DBConn.SaveChanges();
                }
                ExcutingTaskMonitorWorker();
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }
        private static void ExcutingTaskMonitorWorker()
        {
            Task.Factory.StartNew(async () =>
            {
                var database = new AGVSDBHelper();
                var context = database.DBConn;
                Dictionary<int, string> agvExecutingTaskList = new Dictionary<int, string>();
                int lastTasksNum = 0;
                while (true)
                {
                    await Task.Delay(1000);
                    try
                    {
                        if (context.ExecutingTasks.AsNoTracking().Any())
                        {
                            lastTasksNum = context.ExecutingTasks.Count();
                            ExecutingTaskList.Clear();
                            foreach (var task in context.ExecutingTasks.AsNoTracking())
                            {
                                ExecutingTaskList.Add(task);
                                var agv_id = task.ExeVehicleID;
                                if (!agvExecutingTaskList.ContainsKey(agv_id))
                                {
                                    agvExecutingTaskList.Add(agv_id, task.Name);
                                    OnAGVStartNewTask?.Invoke("", new clsNewTaskObj
                                    {
                                        AGVID = agv_id,
                                        TaskNameExecuting = task.Name,
                                        OrderInfo = task
                                    });
                                }
                                else
                                {
                                    var previousTaskName = agvExecutingTaskList[agv_id];
                                    var currentTaskName = task.Name;
                                    if (previousTaskName != currentTaskName)
                                    {
                                        agvExecutingTaskList[agv_id] = currentTaskName;
                                        OnAGVStartNewTask?.Invoke("", new clsNewTaskObj
                                        {
                                            AGVID = agv_id,
                                            TaskNameExecuting = task.Name,
                                            OrderInfo = task
                                        });
                                    }
                                }
                            }
                            OnExecutingTasksUpdated?.Invoke("", EventArgs.Empty);
                        }
                        else
                        {
                            if (lastTasksNum > 0)
                            {
                                OnExecutingTasksALLClear?.Invoke("", EventArgs.Empty);
                                await Task.Delay(1000);
                                lastTasksNum = 0;
                            }
                            ExecutingTaskList.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        OnError?.Invoke("", ex.Message);
                        continue;
                    }

                }
            });
        }
        public WebAGVSystemDbcontext DBConn
        {
            get
            {
                try
                {
                    var optionbuilder = new DbContextOptionsBuilder<WebAGVSystemDbcontext>();
                    optionbuilder.UseSqlServer(DBConnection);
                    var context = new WebAGVSystemDbcontext(optionbuilder.Options);
                    return context;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public int GetAGVID(string AGVName)
        {
            using (var dbConn = DBConn)
            {
                var agv = dbConn.AGVInfos.FirstOrDefault(agv => agv.AGVName == AGVName);
                if (agv == null)
                    return 1;
                return agv.AGVID;
            }
        }

        public clsAGVStates GetAGVMainStatus(string AGVName)
        {
            using (var dbConn = DBConn)
            {
                var agv = dbConn.AGVInfos.FirstOrDefault(agv => agv.AGVName == AGVName);
                if (agv == null)
                {
                    return new clsAGVStates()
                    {
                        AutoStatus = AUTO_STATE.MANUAL,
                        RunStatus = RUN_STATE.DOWN,
                        OnlineStatus = ONLINE_STATE.OFFLINE
                    };
                }
                else
                {
                    var main_status = Enum.GetValues(typeof(RUN_STATE)).Cast<RUN_STATE>().FirstOrDefault(st => (int)st == agv.AGVMainStatus);
                    var online_status = Enum.GetValues(typeof(ONLINE_STATE)).Cast<ONLINE_STATE>().FirstOrDefault(st => (int)st == agv.AGVMode);
                    return new clsAGVStates
                    {
                        RunStatus = main_status,
                        OnlineStatus = online_status
                    };
                }

            }
        }

        public List<ExecutingTask> GetExecutingTasks()
        {
            using (var conn = DBConn)
            {
                return conn.ExecutingTasks.ToList();
            }
        }

        internal int ADD_TASK(ExecutingTask executingTask)
        {
            using (var conn = DBConn)
            {
                conn.ExecutingTasks.Add(executingTask);
                return conn.SaveChanges();
            }
        }

        internal ExecutingTask GetTaskByTaskName(string taskName)
        {
            using (var conn = DBConn)
            {
                return conn.ExecutingTasks.FirstOrDefault(entity => entity.Name == taskName);
            }
        }

        internal void ClearExecutingTasks()
        {
            using (var conn = DBConn)
            {
                conn.ExecutingTasks.ExecuteDelete();
                conn.SaveChanges();
            }
        }

        internal void RemoveTaskByID(string TaskName)
        {
            using (var conn = DBConn)
            {
                var existTask = conn.ExecutingTasks.FirstOrDefault(tk => tk.Name == TaskName);
                if (existTask != null)
                {
                    conn.ExecutingTasks.Remove(existTask);
                    conn.SaveChanges();
                }
            };
        }

        internal List<TaskDto> QueryTask(DateTime from, DateTime to, string userName = "")
        {
            using (var dbConn = DBConn)
            {
                var tasks = dbConn.Tasks
                    .Where(tk => tk.Receive_Time >= from & tk.Receive_Time <= to & (userName == "" ? true : tk.AssignUserName.ToLower().Contains(userName)))
                    //.Where(tk => tk.Receive_Time >= from & tk.Receive_Time <= to)
                    .OrderByDescending(t => t.Receive_Time);
                return tasks.ToList();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 處置受控狀態 (受控物件)
                }
                DBConn.Database.CloseConnection();
                DBConn.Dispose();
                // TODO: 釋出非受控資源 (非受控物件) 並覆寫完成項
                // TODO: 將大型欄位設為 Null
                disposedValue = true;
            }
        }

        // // TODO: 僅有當 'Dispose(bool disposing)' 具有會釋出非受控資源的程式碼時，才覆寫完成項
        // ~AGVSDBHelper()
        // {
        //     // 請勿變更此程式碼。請將清除程式碼放入 'Dispose(bool disposing)' 方法
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // 請勿變更此程式碼。請將清除程式碼放入 'Dispose(bool disposing)' 方法
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        internal bool DeleteTask(TaskDto task)
        {
            try
            {

                using var dbConn = DBConn;
                dbConn.Tasks.Remove(task);
                int delete_num = dbConn.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
