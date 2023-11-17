using GPMCasstteConvertCIM.DataBase.KGS_AGVs;
using GPMCasstteConvertCIM.DataBase.KGS_AGVs.Models;
using GPMCasstteConvertCIM.HttpTools;
using GPMCasstteConvertCIM.Utilities;
using GPMCasstteConvertCIM.Utilities.SysConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.AGVsMiddleware
{
    public class AGVsOrderInfoTransfer
    {
        public static List<clsAGVInfo> AGVList { get; private set; }

        public static void Initialize()
        {
            Utility.LoadConfigs();
            AGVList = Utility.SysConfigs.AGVList;
            AGVSDBHelper.OnAGVStartNewTask += AGVSDBHelper_OnAGVStartNewTaskAsync;
        }

        public static void AGVSDBHelper_OnAGVStartNewTaskAsync(object? sender, clsAGVInfo e)
        {
            var agv = AGVList.FirstOrDefault(agv => agv.AGVID == e.AGVID);
            if (agv == null)
                return;
            PostOrderInfoToAGV(agv);
        }

        public static async Task<bool> PostOrderInfoToAGV(clsAGVInfo? agv)
        {
            HttpHelper http = new HttpHelper($"http://{agv.AGVIP}:7025");
            bool result = await http.PostAsync<bool, clsOrderInfo>("/api/TaskDispatch/OrderInfo", new clsOrderInfo()
            {
                ActionName = clsOrderInfo.ACTION_TYPE.Carry,
                DestineName = "DE1",
                SourceName = "SO1"
            });
            return result;

        }

        public class clsOrderInfo
        {
            public string DestineName { get; set; } = "";
            public string SourceName { get; set; } = "";
            public ACTION_TYPE ActionName { get; set; } = ACTION_TYPE.NoAction;
            public enum ACTION_TYPE
            {
                None,
                Unload,
                LoadAndPark,
                Forward,
                Backward,
                FaB,
                Measure,
                Load,
                Charge,
                Carry,
                Discharge,
                Escape,
                Park,
                Unpark,
                ExchangeBattery,
                Hold,
                Break,
                Unknown,
                NoAction = 999
            }
        }
    }
}
