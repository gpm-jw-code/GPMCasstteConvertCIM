using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.Database
{
    public class AGVSDBHelper
    {
        internal static string DBConnection = "Server=127.0.0.1;Database=WebAGVSystem;User Id=sa;Password=12345678;Encrypt=False";

        public WebAGVSystemDbcontext DBConn
        {
            get
            {
                try
                {
                    var optionbuilder = new DbContextOptionsBuilder<WebAGVSystemDbcontext>();
                    optionbuilder.UseSqlServer("Server=127.0.0.1;Database=WebAGVSystem;User Id=sa;Password=12345678;Encrypt=False");
                    return new WebAGVSystemDbcontext(optionbuilder.Options);
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
