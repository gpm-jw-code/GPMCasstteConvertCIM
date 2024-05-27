using Secs4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Secs4Net.Sml;
namespace GPMCasstteConvertCIM.GPM_SECS.SecsMessageHandle
{

    /// <summary>
    /// 在 {_timeWindow } 設定秒數內流量超過 {_limit } Byte=> DDOS!
    /// </summary>
    public class AGVSSecsDDOSWatchDog
    {
        private readonly int _timeWindow;
        private readonly int _countLimit;
        private readonly long _limit;
        public readonly Queue<(DateTime Timestamp, int Size, SecsMessage message)> _trafficData = new Queue<(DateTime, int, SecsMessage)>();

        public AGVSSecsDDOSWatchDog(int timeWindowInSeconds, long limit, int countLimit)
        {
            _timeWindow = timeWindowInSeconds;
            _limit = limit;
            _countLimit = countLimit;
        }

        public (bool isSizeOverload, bool isCountOverload) Monitor(SecsMessage primaryMessage)
        {
            CleanOldData();
            var messageSize = Encoding.ASCII.GetBytes(primaryMessage.ToSml()).Length;
            AddNewData(messageSize, primaryMessage);

            bool isSizeOverload = GetCurrentTraffic() > _limit;
            bool isCountOverload = GetCurrentTrafficCount() > _countLimit;

            return (isSizeOverload, isCountOverload);
        }
        private void CleanOldData()
        {
            var threshold = DateTime.Now.AddSeconds(-_timeWindow);
            while (_trafficData.Count > 0 && _trafficData.Peek().Timestamp < threshold)
            {
                _trafficData.Dequeue();
            }
        }

        private void AddNewData(int size, SecsMessage primaryMessage)
        {
            _trafficData.Enqueue((DateTime.Now, size, primaryMessage));
        }

        private long GetCurrentTraffic()
        {
            return _trafficData.Sum(item => (long)item.Size);
        }

        // 獲取當前時間窗口內的資料筆數
        private int GetCurrentTrafficCount()
        {
            return _trafficData.Count;
        }
    }
}
