using GPMCasstteConvertCIM.CasstteConverter.Data;
using GPMCasstteConvertCIM.CIM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.CasstteConverter
{
    public class EQPHandShakeHandler
    {
        private clsCasstteConverter CasstteConverter;

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
                //var response = await CIMDevices.secs_client.SendAsync(,);

                //寫結果

                await CarrierWaitInReply(portData, true);

                Console.WriteLine("Handshake:Carrier wait in FINISH");

            });
        }

        private async Task CarrierWaitInReply(clsPortData portData, bool accpect)
        {
            Enums.PROPERTY wait_in_ = accpect ? Enums.PROPERTY.Carrier_WaitIn_System_Accept : Enums.PROPERTY.Carrier_WaitIn_System_Refuse;
            Enums.EQ_SCOPE port_no = portData.PortNo == 1 ? Enums.EQ_SCOPE.PORT1 : Enums.EQ_SCOPE.PORT2;

            var carrier_wait_in_result_flag_address = CasstteConverter.LinkBitMap.First(mem => mem.EOwner == clsMemoryAddress.OWNER.CIM && mem.EScope == port_no && mem.EProperty == wait_in_).Address;
            var carrier_wait_in_reply_address = CasstteConverter.LinkBitMap.First(mem => mem.EOwner == clsMemoryAddress.OWNER.CIM && mem.EScope == port_no && mem.EProperty == Enums.PROPERTY.Carrier_WaitIn_System_Reply).Address;

            CasstteConverter.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_result_flag_address, true);
            CasstteConverter.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_reply_address, true);


            while (portData.CarrierWaitINSystemRequest)
            {
                await Task.Delay(1);
            }

            CasstteConverter.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_reply_address, false);
            CasstteConverter.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_result_flag_address, false);

        }
    }
}
