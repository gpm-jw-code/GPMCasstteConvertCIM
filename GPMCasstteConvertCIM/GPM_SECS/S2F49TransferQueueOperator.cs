﻿using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.GPM_SECS.SecsMessageHandle;
using GPMCasstteConvertCIM.Utilities;
using Secs4Net;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.GPM_SECS
{
    public class S2F49TransferQueueOperator
    {

        public class Configurations
        {
            public bool Enable { get; set; } = false;
            public int TimeWindow { get; set; } = 10;
            public List<string> HighPriorityPortID { get; set; } = new();

        }

        internal static Stopwatch _timer { get; private set; } = new Stopwatch();

        public static Configurations configuration => Utility.SysConfigs.S2F49QueuingConfigurations;

        internal static ConcurrentDictionary<DateTime, PrimaryMessageWrapper> queueingTransgerPrimaryMesWrappers = new ConcurrentDictionary<DateTime, PrimaryMessageWrapper>();
        internal static LoggerBase logger = new LoggerBase(null, Utility.SysConfigs.Log.SyslogFolder, "S2F49TransferQueue");
        internal static int InQueueCount => queueingTransgerPrimaryMesWrappers.Count;

        private static SemaphoreSlim _asyncSemaphoreSlim = new SemaphoreSlim(1, 1);

        public static async Task Queueing(Secs4Net.PrimaryMessageWrapper _primaryMessageWrapper)
        {
            if (queueingTransgerPrimaryMesWrappers.TryAdd(DateTime.Now, _primaryMessageWrapper))
            {
                logger.Info($"{_primaryMessageWrapper.Id}-{_primaryMessageWrapper.PrimaryMessage.ToString()} Add to queue");

                if (!_timer.IsRunning)
                {
                    _StartCountDown();

                }
            }

        }

        private static async Task _StartCountDown()
        {
            _ = Task.Run(async () =>
            {
                try
                {
                    await _asyncSemaphoreSlim.WaitAsync();
                    if (_timer.IsRunning)
                        return;
                    _timer.Reset();
                    _timer.Restart();

                    logger.Info($"Start Timer countdown--> {configuration.TimeWindow}s");

                    while (_timer.IsRunning)
                    {
                        if (_timer.ElapsedMilliseconds >= configuration.TimeWindow * 1000)
                        {
                            _timer.Stop();
                            _timer.Reset();
                            logger.Info($"Timer countdown finish--> {configuration.TimeWindow}s");
                            break;
                        }
                        await Task.Delay(100);
                    }
                    PrimaryMessageWrapper[] _ii = queueingTransgerPrimaryMesWrappers.Values.ToArray();
                    logger.Info($"There are {_ii.Length} S2F49 Transfer command now is in queue");
                    queueingTransgerPrimaryMesWrappers.Clear();
                    ActionWhenTimeWindowRecordFinish(_ii);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {


                    _asyncSemaphoreSlim.Release();
                }
            });
        }

        private static async Task ActionWhenTimeWindowRecordFinish(PrimaryMessageWrapper[] _ii)
        {
            try
            {
                logger.Info($"[{typeof(S2F49TransferQueueOperator).Name}] start send s2f49 queue to AGVS({_ii.Length})");


                SecsMessage[] orderedS2F49Transfers = OrderByPrority(_ii);


                string _logDebug = "Transfer From/To Ordered : \r\n";
                foreach (var item in orderedS2F49Transfers)
                {
                    if (item.TryParseTransferInfo(out var carrierID, out var from, out var to))
                    {
                        _logDebug += $"From {from} To {to} \r\n";
                    }
                }
                logger.Info(_logDebug);

                foreach (var item in orderedS2F49Transfers)
                {
                    item.TryParseTransferInfo(out var carrierID, out var from, out var to);
                    logger.Info($"[{typeof(S2F49TransferQueueOperator).Name}].Carrier ({carrierID}) Transfer FROM [{from}] TO [{to}] start send s2f49 to AGVS");
                    await Task.Delay(600);
                    SendPrimaryMesgFromQueueToAGV(item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //TODO: modify Prority of s2f49 transfer and send to kgs agvs .
        }

        private static SecsMessage[] OrderByPrority(PrimaryMessageWrapper[] Wrappers)
        {
            List<SecsMessage> s2f49Collection = Wrappers.Select(wrap => wrap.PrimaryMessage).ToList();

            configuration.HighPriorityPortID.ForEach(portID =>
            {
                var highPriorityS2F49 = s2f49Collection.Where(s2f49 => s2f49.TryParseTransferInfo(out string carrierID, out var from, out var to) && (to == portID || from == portID)).ToList();
                if (highPriorityS2F49.Count > 0)
                {
                    s2f49Collection.RemoveAll(s2f49 => highPriorityS2F49.Contains(s2f49));
                    s2f49Collection.InsertRange(0, highPriorityS2F49);
                }
            });
            return s2f49Collection.ToArray();
        }

        private static async Task SendPrimaryMesgFromQueueToAGV(SecsMessage primaryMessage)
        {
            SecsMessage response = await DevicesManager.secs_client_for_agvs.SendMsg(primaryMessage);
            if (response.IsS9F7())
            {
                logger.Error($"[{typeof(S2F49TransferQueueOperator).Name}] send s2f49 to AGVS fail");
            }
            else
            {
                logger.Info($"[{typeof(S2F49TransferQueueOperator).Name}] send s2f49 to AGVS success");
            }

        }

        private void GetTransferFromTo(SecsMessage S2F49Transfer)
        {


        }

        internal static void ClearQueue()
        {
            queueingTransgerPrimaryMesWrappers.Clear();

            _timer?.Stop();
            _timer?.Reset();
        }

        internal static void SendMessageInstanly()
        {
            _timer?.Stop();
            _timer?.Reset();
        }
    }
}
