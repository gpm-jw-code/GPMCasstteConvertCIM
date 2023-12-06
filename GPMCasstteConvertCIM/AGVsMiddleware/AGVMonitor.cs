using GPMCasstteConvertCIM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.AGVsMiddleware
{
    public class AGVMonitor
    {

        public static void Start()
        {
            foreach (Utilities.SysConfigs.clsAGVInfo agv_ in Utility.SysConfigs.AGVList)
            {
                Task.Factory.StartNew(() =>
                {
                    AGVPingWorker(agv_);
                });
            }
        }

        private static async void AGVPingWorker(Utilities.SysConfigs.clsAGVInfo agv_)
        {
            while (true)
            {
                await Task.Delay(1000);
                try
                {
                    using Ping ping = new Ping();
                    PingReply result = ping.Send(agv_.AGVIP);
                    agv_.PingSuccess = result.Status == IPStatus.Success;
                }
                catch (Exception ex)
                {
                    agv_.PingSuccess = false;
                }
            }
        }
    }
}
