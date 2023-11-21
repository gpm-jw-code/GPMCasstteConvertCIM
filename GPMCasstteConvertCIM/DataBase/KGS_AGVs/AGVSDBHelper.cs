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
    public class AGVSDBHelper
    {

        public static string DBConnection = "Server=127.0.0.1;Database=WebAGVSystem;User Id=sa;Password=12345678;Encrypt=False";
        public static event EventHandler<clsNewTaskObj> OnAGVStartNewTask;
        public static BindingList<ExecutingTask> ExecutingTaskList = new BindingList<ExecutingTask>();
        public static event EventHandler OnExecutingTasksUpdated;
        public static event EventHandler OnExecutingTasksALLClear;
        public static event EventHandler<string> OnError;

        private static LoggerBase logger;
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

                                if (!agvExecutingTaskList.ContainsKey(task.AGVID))
                                {
                                    agvExecutingTaskList.Add(task.AGVID, task.Name);
                                    OnAGVStartNewTask?.Invoke("", new clsNewTaskObj
                                    {
                                        AGVID = task.AGVID,
                                        TaskNameExecuting = task.Name,
                                        OrderInfo = task
                                    });
                                }
                                else
                                {
                                    var previousTaskName = agvExecutingTaskList[task.AGVID];
                                    var currentTaskName = task.Name;
                                    if (previousTaskName != currentTaskName)
                                    {
                                        agvExecutingTaskList[task.AGVID] = currentTaskName;
                                        OnAGVStartNewTask?.Invoke("", new clsNewTaskObj
                                        {
                                            AGVID = task.AGVID,
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
    }
}
