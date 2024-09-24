using GPMCasstteConvertCIM.GPM_SECS;
using GPMCasstteConvertCIM.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.DataBase.KGS_AGVs
{
    public class WebAGVSystemDBBackgroundWorker : IHostedService
    {

        public class CancelChargeTaskFunction
        {
            public bool Enable { get; set; } = false;
            public List<CancelChargeTaskRule> Rules = new List<CancelChargeTaskRule>();

            public class CancelChargeTaskRule
            {
                public bool Enable { get; set; } = false;
                public string ApplyEQPortID { get; set; } = "";
                public string ChargeStationName { get; set; } = "RACK_4_12|13|14";
            }

        }


        public CancelChargeTaskFunction CancelChargeFunctional = new CancelChargeTaskFunction();

        KGSWebAGVSystemAPI.Models.WebAGVSystemContext dbContext;
        public readonly string dbConnection;
        public List<KGSWebAGVSystemAPI.Models.Task> taskHistory = new();
        public List<KGSWebAGVSystemAPI.Models.ExecutingTask> excutingTasks = new();
        private LoggerBase _logger;
        public WebAGVSystemDBBackgroundWorker(string dbConnection)
        {
            this.dbConnection = dbConnection;
            _logger = new LoggerBase(null, Utility.SysConfigs.Log.SyslogFolder, "WebAGVSystem");

        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(1).ContinueWith(async _task =>
            {
                var optionbuilder = new DbContextOptionsBuilder<KGSWebAGVSystemAPI.Models.WebAGVSystemContext>();
                optionbuilder.UseSqlServer(dbConnection);
                dbContext = new KGSWebAGVSystemAPI.Models.WebAGVSystemContext(optionbuilder.Options);
                List<string> currentTaskNames = new List<string>();
                while (true)
                {
                    try
                    {
                        excutingTasks = await dbContext.ExecutingTask.ToListAsync();
                        taskHistory = await dbContext.Task.AsNoTracking().OrderByDescending(_task => _task.Receive_Time)
                                                                         .Take(50).ToListAsync();

                        List<string> _newewstTaskNames = excutingTasks.Select(tk => tk.Name).ToList();
                        List<string> newAddTaskNames = _newewstTaskNames.Where(name => !currentTaskNames.Contains(name)).ToList();

                        if (newAddTaskNames.Any())
                        {
                            HandleNewTaskAdded(newAddTaskNames);
                        }
                        currentTaskNames = _newewstTaskNames.ToList();
                    }
                    catch (Exception ex)
                    {

                    }
                    await Task.Delay(100);
                }
            });
        }

        private void HandleNewTaskAdded(List<string> newAddTaskNames)
        {
            _logger.Info($"新任務產生 [{newAddTaskNames.Count}]");

            if (!newAddTaskNames.Any())
                return;

            List<KGSWebAGVSystemAPI.Models.ExecutingTask> taskOrders = dbContext.ExecutingTask.Where(tk => newAddTaskNames.Contains(tk.Name)).ToList();
            List<KGSWebAGVSystemAPI.Models.ExecutingTask> chargeTasks = dbContext.ExecutingTask.Where(tk => tk.ActionType == "Charge").ToList();
            if (chargeTasks.Any() && CancelChargeFunctional.Enable)
            {

                foreach (KGSWebAGVSystemAPI.Models.ExecutingTask task_ in taskOrders)
                {
                    try
                    {

                        if (task_.ActionType != "Transfer")
                            continue;
                        CancelChargeTaskFunction.CancelChargeTaskRule? _ruleApply = CancelChargeFunctional.Rules.FirstOrDefault(rule => rule.Enable && rule.ApplyEQPortID == task_.FromStation);

                        if (_ruleApply == null)
                        {
                            _logger.Info($"no rule found");
                            continue;
                        }

                        KGSWebAGVSystemAPI.Models.ExecutingTask? toCancelTask = chargeTasks.FirstOrDefault(tk => tk.ToStation == _ruleApply.ChargeStationName);
                        if (toCancelTask == null)
                        {
                            _logger.Info($"not any charge task need cancel");
                            continue;
                        }
                        //finally, cancel task!

                        _logger.Info($"搬運任務 [{task_.Name}] 終點為{task_.ToStation} 且系統有設置取消充電功能 ,取消充電任務[{toCancelTask.Name}]");


                        KGSWebAGVSystemAPI.TaskOrder.OrderAPI.CancelTask(toCancelTask.Name);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }

                //CancelChargeFunctional.Rules.FirstOrDefault(rule => rule.Enable &&  rule.ApplyEQPortID)
            }

        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
        }

        internal async Task<int> DeleteTask(string taskName)
        {
            var dbo = dbContext.Task.FirstOrDefault(tk => tk.Name == taskName);
            if (dbo != null)
            {
                dbContext.Task.Remove(dbo);
                return await dbContext.SaveChangesAsync();
            }
            else
                return 0;
        }
    }
}
