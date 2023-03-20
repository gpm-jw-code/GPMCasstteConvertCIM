using GPMCasstteConvertCIM.CasstteConverter.Data;
using GPMCasstteConvertCIM.CIM;
using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.GPM_SECS;
using Secs4Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.CasstteConverter
{
    public class EQPHandShakeHandler
    {

        public class HandShakeResult
        {
            public bool Finish;
            public string Message;
            public bool Timeout;

            public void Reset()
            {
                Finish = Timeout = false;
                Message = "";
            }
        }


        private clsCasstteConverter CasstteConverter;

        public HandShakeResult CarrierWaitInHSResult = new HandShakeResult();
        public HandShakeResult CarrierWaitOutHSResult = new HandShakeResult();

        public EQPHandShakeHandler(clsCasstteConverter CasstteConverter)
        {
            this.CasstteConverter = CasstteConverter;

            foreach (var item in CasstteConverter.EQPData.PortDatas)
            {
                item.CarrierWaitInOnRequest += CarrierWaitInOnRequestHandle;
                item.CarrierWaitOutOnReport += CarrierWaitOutOnReportHandle;
                item.CarrierRemovedCompletedOnReport += CarrierRemovedCompletedOnReportHandle;
                item.OnValidSignalActive += AGVValidSignalActiveHandle;
            }

        }

        private void AGVValidSignalActiveHandle(object? sender, clsPortData portData)
        {

        }

        private void CarrierRemovedCompletedOnReportHandle(object? sender, clsPortData portData)
        {
            Task.Factory.StartNew(async () =>
            {

                await CarrierRemovedCompletedReply(portData);
                //TODO 上報MCS

                Console.WriteLine("Handshake:Carrier Wait Out Report HS FINISH");

            });
        }

        private async Task CarrierRemovedCompletedReply(clsPortData? portData)
        {

            Enums.EQ_SCOPE port_no = portData.PortNo == 1 ? Enums.EQ_SCOPE.PORT1 : Enums.EQ_SCOPE.PORT2;
            var carrier_removed_com_reply_address = CasstteConverter.LinkBitMap.First(mem => mem.EOwner == clsMemoryAddress.OWNER.CIM && mem.EScope == port_no && mem.EProperty == Enums.PROPERTY.Carrier_Removed_Completed_Report_Reply).Address;
            CasstteConverter.CIMMemOptions.memoryTable.WriteOneBit(carrier_removed_com_reply_address, true);
            while (portData.CarrierRemovedCompletedReport)
            {
                await Task.Delay(1);
            }
            CasstteConverter.CIMMemOptions.memoryTable.WriteOneBit(carrier_removed_com_reply_address, false);
        }

        private void CarrierWaitOutOnReportHandle(object? sender, clsPortData portData)
        {
            //TODO 上報MCS
            Task.Factory.StartNew(async () =>
            {
                await CarrierWaitOutReply(portData);

                Console.WriteLine("Handshake:Carrier Wait Out Report HS FINISH");

            });
        }

        private async Task CarrierWaitOutReply(clsPortData? portData)
        {

            Enums.EQ_SCOPE port_no = portData.PortNo == 1 ? Enums.EQ_SCOPE.PORT1 : Enums.EQ_SCOPE.PORT2;
            var carrier_wait_out_reply_address = CasstteConverter.LinkBitMap.First(mem => mem.EOwner == clsMemoryAddress.OWNER.CIM && mem.EScope == port_no && mem.EProperty == Enums.PROPERTY.Carrier_WawitOut_System_Reply).Address;
            CasstteConverter.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_out_reply_address, true);
            while (portData.CarrierWaitOUTSystemRequest)
            {
                await Task.Delay(1);
            }
            CasstteConverter.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_out_reply_address, false);

            try
            {

                await DevicesManager.secs_client.SendAsync(SECSMessageHelper.EVENT_REPORT.CarrierWaitOutReportMessage(portData.WIPINFO_BCR_ID, "", ""));
            }
            catch (Exception ex)
            {

            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">clsPortData</param>
        /// <param name="e"></param>
        private void CarrierWaitInOnRequestHandle(object? sender, clsPortData portData)
        {
            Task.Factory.StartNew(async () =>
            {
                //送訊息給SECS HOST   //TODO 上報MCS
                var carrier_id = portData.WIPINFO_BCR_ID;

                await WaitMCSAccpectCarrierIn(carrier_id);

                bool mcs_accpet = false;

                //寫結果
                CarrierWaitOutHSResult.Reset();
                bool IsTimeout = await CarrierWaitInReply(portData, mcs_accpet);
                CarrierWaitOutHSResult.Timeout = IsTimeout;
                CarrierWaitOutHSResult.Finish = true;

                Console.WriteLine("Handshake:Carrier wait in FINISH");

            });
        }

        bool isReply = false;
        bool isAccept = false;

        private async Task<bool> WaitMCSAccpectCarrierIn(string carrier_id, int T_timout = 20)
        {
            isReply = false;
            isAccept = false;

            bool isEventReportAck = false;
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(T_timout));

            while (!isEventReportAck)
            {
                if (cancellationTokenSource.IsCancellationRequested)
                {
                    return false;
                }
                try
                {
                    var msc_reply = await DevicesManager.secs_client.SendAsync(SECSMessageHelper.EVENT_REPORT.CarrierWaitInReportMessage(carrier_id, "", ""));
                    isEventReportAck = true;
                }
                catch (Exception ex)
                {

                }
                Thread.Sleep(1);
            }

            DevicesManager.secs_client.OnPrimaryMessageRecieve += Secs_client_OnPrimaryMessageRecieve;

            cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(T_timout));
            while (!isReply)
            {
                try
                {
                    await Task.Delay(1, cancellationTokenSource.Token);
                }
                catch (TaskCanceledException ex)
                {
                    //表示timeout
                    break;
                }
            }
            DevicesManager.secs_client.OnPrimaryMessageRecieve -= Secs_client_OnPrimaryMessageRecieve;
            return isAccept && isReply;
        }

        private void Secs_client_OnPrimaryMessageRecieve(object? sender, PrimaryMessageWrapper messagePrimary)
        {
            Task.Factory.StartNew(() =>
            {
                var mcs_msg = messagePrimary.PrimaryMessage;
                bool IsRCMD = mcs_msg.TryGetRCMDAction(out SECSMessageHelper.RCMD RCMD);
                if (IsRCMD && RCMD == SECSMessageHelper.RCMD.TRANSFER)
                {
                    isReply = true;
                    isAccept = true;
                }
                if (IsRCMD && RCMD == SECSMessageHelper.RCMD.NOTRANSFER)
                {
                    isReply = true;
                    isAccept = false;
                }
            });
        }

        private async Task<bool> CarrierWaitInReply(clsPortData portData, bool accpect, int T_timeout = 5000)
        {
            bool timeout = false;

            Enums.PROPERTY wait_in_ = accpect ? Enums.PROPERTY.Carrier_WaitIn_System_Accept : Enums.PROPERTY.Carrier_WaitIn_System_Refuse;
            Enums.EQ_SCOPE port_no = portData.PortNo == 1 ? Enums.EQ_SCOPE.PORT1 : Enums.EQ_SCOPE.PORT2;

            var carrier_wait_in_result_flag_address = CasstteConverter.LinkBitMap.First(mem => mem.EOwner == clsMemoryAddress.OWNER.CIM && mem.EScope == port_no && mem.EProperty == wait_in_).Address;
            var carrier_wait_in_reply_address = CasstteConverter.LinkBitMap.First(mem => mem.EOwner == clsMemoryAddress.OWNER.CIM && mem.EScope == port_no && mem.EProperty == Enums.PROPERTY.Carrier_WaitIn_System_Reply).Address;

            CasstteConverter.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_result_flag_address, true);
            CasstteConverter.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_reply_address, true);

            Stopwatch sw = Stopwatch.StartNew();
            while (portData.CarrierWaitINSystemRequest)
            {
                if (sw.ElapsedMilliseconds > T_timeout)
                {
                    timeout = true;
                    break;
                }
                await Task.Delay(1);
            }

            CasstteConverter.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_reply_address, false);
            CasstteConverter.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_result_flag_address, false);

            return timeout;

        }
    }
}
