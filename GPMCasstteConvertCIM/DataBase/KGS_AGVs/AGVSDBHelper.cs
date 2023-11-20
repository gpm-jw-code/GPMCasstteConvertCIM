using GPMCasstteConvertCIM.DataBase.KGS_AGVs.Models;
using GPMCasstteConvertCIM.Utilities;
using GPMCasstteConvertCIM.Utilities.SysConfigs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.DataBase.KGS_AGVs
{
    public class AGVSDBHelper
    {

        internal static string DBConnection = "Server=192.168.1.100;Database=WebAGVSystem;User Id=sa;Password=12345678;Encrypt=False";


        public static event EventHandler<clsNewTaskObj> OnAGVStartNewTask;
        public class clsNewTaskObj : clsAGVInfo
        {
            public ExecutingTask OrderInfo { get; set; } = new ExecutingTask();
        }
        public static bool Init(out string errMsg)
        {
            errMsg = string.Empty;
            try
            {
                var helper = new AGVSDBHelper();
                helper.DBConn.Database.EnsureCreated();
                helper.DBConn.SaveChanges();
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
                while (true)
                {
                    await Task.Delay(1000);
                    if (context.ExecutingTasks.Any())
                    {
                        foreach (var task in context.ExecutingTasks)
                        {
                            if (!agvExecutingTaskList.ContainsKey(task.AGVID))
                                agvExecutingTaskList.Add(task.AGVID, task.Name);
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

    }
}
