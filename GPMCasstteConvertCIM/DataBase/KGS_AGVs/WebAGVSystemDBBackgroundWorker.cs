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

        KGSWebAGVSystemAPI.Models.WebAGVSystemContext dbContext;
        public readonly string dbConnection;
        public List<KGSWebAGVSystemAPI.Models.Task> taskHistory = new();
        public List<KGSWebAGVSystemAPI.Models.ExecutingTask> excutingTasks = new();
        public WebAGVSystemDBBackgroundWorker(string dbConnection)
        {
            this.dbConnection = dbConnection;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(1).ContinueWith(async _task =>
            {
                var optionbuilder = new DbContextOptionsBuilder<KGSWebAGVSystemAPI.Models.WebAGVSystemContext>();
                optionbuilder.UseSqlServer(dbConnection);
                dbContext = new KGSWebAGVSystemAPI.Models.WebAGVSystemContext(optionbuilder.Options);
                while (true)
                {
                    try
                    {
                        excutingTasks = await dbContext.ExecutingTask.ToListAsync();
                        taskHistory = await dbContext.Task.AsNoTracking().OrderByDescending(_task => _task.Receive_Time)
                                                     .Take(50).ToListAsync();
                    }
                    catch (Exception ex)
                    {

                    }
                    await Task.Delay(100);
                }
            });
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
