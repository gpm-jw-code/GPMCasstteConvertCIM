using GPMCasstteConvertCIM.CasstteConverter.Data;
using GPMCasstteConvertCIM.CIM;
using GPMCasstteConvertCIM.CIM.SecsMessageHandle;
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
                item.ModeChangeOnRequest += ModeChangeOnRequestHandle;
            }

        }


        private void ModeChangeOnRequestHandle(object? sender, clsConverterPort e)
        {

        }

        private void AGVValidSignalActiveHandle(object? sender, clsConverterPort port)
        {

        }

        private void CarrierRemovedCompletedOnReportHandle(object? sender, clsConverterPort port)
        {
            Task.Factory.StartNew(async () =>
            {

                await CarrierRemovedCompletedReply(port);
                //TODO 上報MCS

                Console.WriteLine("Handshake:Carrier Wait Out Report HS FINISH");

            });
        }

        private async Task CarrierRemovedCompletedReply(clsConverterPort? port)
        {

            Enums.EQ_SCOPE port_no = port.Properties.PortNo == 1 ? Enums.EQ_SCOPE.PORT1 : Enums.EQ_SCOPE.PORT2;
            var carrier_removed_com_reply_address = CasstteConverter.LinkBitMap.First(mem => mem.EOwner == clsMemoryAddress.OWNER.CIM && mem.EScope == port_no && mem.EProperty == Enums.PROPERTY.Carrier_Removed_Completed_Report_Reply).Address;
            CasstteConverter.CIMMemOptions.memoryTable.WriteOneBit(carrier_removed_com_reply_address, true);
            while (port.CarrierRemovedCompletedReport)
            {
                await Task.Delay(1);
            }
            CasstteConverter.CIMMemOptions.memoryTable.WriteOneBit(carrier_removed_com_reply_address, false);
        }

        private void CarrierWaitOutOnReportHandle(object? sender, clsConverterPort port)
        {
            //TODO 上報MCS
            Task.Factory.StartNew(async () =>
            {
                await port.CarrierWaitOutReply();

                Console.WriteLine("Handshake:Carrier Wait Out Report HS FINISH");

            });
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">clsPortData</param>
        /// <param name="e"></param>
        private void CarrierWaitInOnRequestHandle(object? sender, clsConverterPort port)
        {
            Task.Factory.StartNew(async () =>
            {
                //送訊息給SECS HOST   //TODO 上報MCS
                await port.WaitMCSAccpectCarrierIn();

                bool mcs_accpet = false;
                //寫結果
                CarrierWaitOutHSResult.Reset();
                bool IsTimeout = await port.CarrierWaitInReply(mcs_accpet);
                CarrierWaitOutHSResult.Timeout = IsTimeout;
                CarrierWaitOutHSResult.Finish = true;

                Console.WriteLine("Handshake:Carrier wait in FINISH");

            });
        }

    }
}
