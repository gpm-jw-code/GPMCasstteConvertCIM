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
        public static void Initialize()
        {
            Utility.LoadConfigs();
            AGVList = Utility.SysConfigs.AGVList;
            AGVSDBHelper.OnAGVStartNewTask += AGVSDBHelper_OnAGVStartNewTaskAsync;

            _Map = MapManager.LoadMapFromFile(Utility.SysConfigs.MapFilePath, out var errMsg, auto_create_segment: false, false);

        }

        public static void AGVSDBHelper_OnAGVStartNewTaskAsync(object? sender, clsNewTaskObj e)
        {
            var agv = AGVList.FirstOrDefault(agv => agv.AGVID == e.AGVID);
            if (agv == null)
                return;
            PostOrderInfoToAGV(e);
        }

        public static async Task<bool> PostOrderInfoToAGV(clsNewTaskObj? agv)
        {
            HttpHelper http = new HttpHelper($"http://{agv.AGVIP}:7025");
            clsOrderInfo order_info = CreateOrderInfo(agv.OrderInfo);
            bool result = await http.PostAsync<bool, clsOrderInfo>("/api/TaskDispatch/OrderInfo", order_info);
            return result;

        }

        private static clsOrderInfo CreateOrderInfo(ExecutingTask orderInfo)
        {
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
                    return AGVSystemCommonNet6.AGVDispatch.Messages.ACTION_TYPE.None;
            }
        }
    }
}
