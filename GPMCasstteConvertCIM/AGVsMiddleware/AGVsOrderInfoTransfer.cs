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
            logger.Info($"Map->{_Map.Name}:{_Map.Note}");
        }

        private static void AGVSDBHelper_OnExecutingTasksALLClear(object? sender, EventArgs e)
        {
            foreach (clsAGVInfo agvInfo in AGVList)
            {
                agvInfo.PostCancelCTS.Cancel();
                Task.Factory.StartNew(async () =>
                {
                    while (agvInfo.PostingFlag)
                    {
                        await Task.Delay(1000);
                    }
                    await PostOrderViaHttp(agvInfo.AGVIP, new clsOrderInfo
                    {
                        ActionName = AGVSystemCommonNet6.AGVDispatch.Messages.ACTION_TYPE.NoAction
                    });
                });
            }


        }

        public static async void AGVSDBHelper_OnAGVStartNewTaskAsync(object? sender, clsNewTaskObj e)
        {
            logger.Info(e.OrderInfo.ToJson());
            var agv = AGVList.FirstOrDefault(agv => agv.AGVID == e.AGVID);
            if (agv == null)
                return;
            agv.PostCancelCTS.Cancel();

            while (agv.PostingFlag)
            {
                await Task.Delay(1000);
            }

            _ = Task.Factory.StartNew(async () =>
            {
                agv.PostCancelCTS = new CancellationTokenSource();
                clsOrderInfo order_info = CreateOrderInfo(e.OrderInfo);
                agv.PostingFlag = true;
                while (true)
                {
                    try
                    {
                        if (agv.PostCancelCTS.IsCancellationRequested)
                        {
                            logger.Info($"{agv.AGVIP} Post Order Info Process Interupted");
                            break;
                        }
                        await Task.Delay(1000);
                        await PostOrderViaHttp(agv.AGVIP, order_info);
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                        break;
                    }

                }
                agv.PostingFlag = false;
            });
        }






        private static async Task<bool> PostOrderViaHttp(string agvIP, clsOrderInfo order_info)
        {
            try
            {
                HttpHelper http = new HttpHelper($"http://{agvIP}:7025",1);
                logger.Info($"Try Post order_info to {agvIP}:7025-\r\n{order_info.ToJson()}");

                bool result = await http.PostAsync<bool, clsOrderInfo>("/api/TaskDispatch/OrderInfo", order_info);
                if (!result)
                {
                    logger.Error($"Post order_info to {agvIP}:7025 Fail");
                }
                else
                    logger.Info($"Post order_info to {agvIP}:7025 ({order_info.ToJson()}) SUCCESSFUL!");
                return result;
            }
            catch (Exception ex)
            {
                logger.Error($"Post order_info to {agvIP}:7025 Fail", ex);
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
                case "Transfer":
                    return AGVSystemCommonNet6.AGVDispatch.Messages.ACTION_TYPE.Carry;
                case "搬運":
                    return AGVSystemCommonNet6.AGVDispatch.Messages.ACTION_TYPE.Carry;

                default:
                    return AGVSystemCommonNet6.AGVDispatch.Messages.ACTION_TYPE.NoAction;
            }
        }
    }
}
