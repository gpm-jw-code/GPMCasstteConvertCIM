using AGVSystemCommonNet6.AGVDispatch.Messages;
using AGVSystemCommonNet6.MAP;
using GPMCasstteConvertCIM.DataBase.KGS_AGVs;
using GPMCasstteConvertCIM.DataBase.KGS_AGVs.Models;
using GPMCasstteConvertCIM.HttpTools;
using GPMCasstteConvertCIM.Utilities;
using GPMCasstteConvertCIM.Utilities.SysConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.DataBase.KGS_AGVs.AGVSDBHelper;

namespace GPMCasstteConvertCIM.AGVsMiddleware
{
    public class AGVsOrderInfoTransfer
    {
        public static List<clsAGVInfo> AGVList { get; private set; }
        private static Map _Map = new Map();
        static LoggerBase logger;
        public static void Initialize(LoggerBase _logger = null)
        {
            logger = _logger;
            Utility.LoadConfigs();
            AGVList = Utility.SysConfigs.AGVList;
            AGVSDBHelper.OnAGVStartNewTask += AGVSDBHelper_OnAGVStartNewTaskAsync;
            AGVSDBHelper.OnExecutingTasksALLClear += AGVSDBHelper_OnExecutingTasksALLClear;
            _Map = MapManager.LoadMapFromFile(Utility.SysConfigs.MapFilePath, out var errMsg, auto_create_segment: false, false);

        }

        private static void AGVSDBHelper_OnExecutingTasksALLClear(object? sender, EventArgs e)
        {
            foreach (clsAGVInfo agvInfo in AGVList)
            {
                Task.Factory.StartNew(async () =>
                {
                    await PostOrderInfoToAGV(new clsNewTaskObj
                    {
                        AGVID = agvInfo.AGVID,
                        AGVIP = agvInfo.AGVIP,
                        OrderInfo = new ExecutingTask
                        {
                            ActionType = "NO_ACTION"
                        }
                    });
                });
            }


        }

        public static void AGVSDBHelper_OnAGVStartNewTaskAsync(object? sender, clsNewTaskObj e)
        {
            logger.Info(e.OrderInfo.ToJson());
            var agv = AGVList.FirstOrDefault(agv => agv.AGVID == e.AGVID);
            if (agv == null)
                return;
            Task.Factory.StartNew(async () =>
            {
                await PostOrderInfoToAGV(new clsNewTaskObj
                {
                    AGVID = agv.AGVID,
                    AGVIP = agv.AGVIP,
                    OrderInfo = e.OrderInfo,
                });
            });
        }

        public static async Task<bool> PostOrderInfoToAGV(clsNewTaskObj? agv)
        {
            HttpHelper http = new HttpHelper($"http://{agv.AGVIP}:7025");
            clsOrderInfo order_info = CreateOrderInfo(agv.OrderInfo);
            logger.Info($"Try Post order_info to {agv.AGVIP}:7025 ({order_info.ToJson()})");
            try
            {
                bool result = await http.PostAsync<bool, clsOrderInfo>("/api/TaskDispatch/OrderInfo", order_info);
                if (!result)
                {
                    logger.Error($"Post order_info to {agv.AGVIP}:7025 Fail");
                }
                else
                    logger.Info($"Post order_info to {agv.AGVIP}:7025 ({order_info.ToJson()}) SUCCESSFUL!");
                return result;
            }
            catch (Exception ex)
            {
                logger.Error($"Post order_info to {agv.AGVIP}:7025 Fail", ex);
                return false;
            }

        }

        private static clsOrderInfo CreateOrderInfo(ExecutingTask orderInfo)
        {
            if (orderInfo.ActionType == "NO_ACTION")
            {
                return new clsOrderInfo
                {
                    ActionName = AGVSystemCommonNet6.AGVDispatch.Messages.ACTION_TYPE.NoAction
                };
            }
            bool fromMapPointExist = _Map.Points.TryGetValue((int)orderInfo.FromStationId, out MapPoint fromMapPoint);
            bool toMapPointExist = _Map.Points.TryGetValue((int)orderInfo.ToStationId, out MapPoint toMapPoint);

            return new clsOrderInfo
            {
                ActionName = orderInfo.ActionType.ToActionEnum(),
                SourceName = fromMapPointExist ? fromMapPoint.Name : orderInfo.FromStationId.ToString(),
                DestineName = toMapPointExist ? toMapPoint.Name : orderInfo.ToStationId.ToString(),
            };
        }

        public class clsOrderInfo
        {
            public string DestineName { get; set; } = "";
            public string SourceName { get; set; } = "";
            public AGVSystemCommonNet6.AGVDispatch.Messages.ACTION_TYPE ActionName { get; set; } = AGVSystemCommonNet6.AGVDispatch.Messages.ACTION_TYPE.NoAction;
        }
    }
    public static class Extensions
    {
        public static AGVSystemCommonNet6.AGVDispatch.Messages.ACTION_TYPE ToActionEnum(this string action_name)
        {
            switch (action_name)
            {
                case "搬運":
                    return AGVSystemCommonNet6.AGVDispatch.Messages.ACTION_TYPE.Carry;

                default:
                    return AGVSystemCommonNet6.AGVDispatch.Messages.ACTION_TYPE.NoAction;
            }
        }
    }
}
