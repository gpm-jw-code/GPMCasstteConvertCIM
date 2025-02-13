using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.GPM_SECS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.CasstteConverter.Enums;

namespace GPMCasstteConvertCIM.Emulators
{
    internal class clsConverterPortEmulator : clsConverterPort
    {

        public bool cstReadFailSimulation = false;
        public bool cstReadMismatchSimulation = false;

        internal clsConverterPortEmulator(clsPortProperty property, clsCasstteConverter converterParent) : base(property, converterParent)
        {
            //CSTIDOnPort = "TAE123";
        }


        internal override async Task<bool> ModeChangeRequestHandshake(PortUnitType portUnitType, string requester_name = "MCS", bool no_change_if_current_type_is_req = true)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            bool response = false;
            _ = Task.Run(async () =>
            {
                response = await base.ModeChangeRequestHandshake(portUnitType, requester_name, no_change_if_current_type_is_req);
                cts.Cancel();
            });
            await Task.Delay(220);
            if (cts.IsCancellationRequested)
            {
                return response;
            }
            await _waitCimPortTypeChgRequestBitON(); //等待CIM Port Type CHange request bit flag ON
            EQParent.EQPMemOptions.memoryTable.WriteOneBit(PortEQBitAddress[PROPERTY.Port_Mode_Change_Accept], true); //接受port type 變換
            await Task.Delay(220);
            await _waitCimPortTypeChgRequestBitOFF(); //等待CIM Port Type CHange request bit flag OFF, Finish handshake
            EQParent.EQPMemOptions.memoryTable.WriteOneBit(PortEQBitAddress[PROPERTY.Port_Mode_Change_Accept], false); //清空接受訊號
            //模擬EQ切換Port完成 狀態訊號上報
            EQParent.EQPMemOptions.memoryTable.WriteBinary(PortEQWordAddress[PROPERTY.Port_Type_Status], portUnitType == PortUnitType.Input ? 0 : 1); //接受port type 變換
            return true;


            async Task<bool> _waitCimPortTypeChgRequestBitON()
            {
                string Port_Mode_Change_Request_address_name = PortCIMBitAddress[PROPERTY.Port_Mode_Change_Request];
                while (!EQParent.CIMMemOptions.memoryTable.ReadOneBit(Port_Mode_Change_Request_address_name))
                {
                    await Task.Delay(100);
                }

                return true;
            }
            async Task<bool> _waitCimPortTypeChgRequestBitOFF()
            {
                string Port_Mode_Change_Request_address_name = PortCIMBitAddress[PROPERTY.Port_Mode_Change_Request];
                while (EQParent.CIMMemOptions.memoryTable.ReadOneBit(Port_Mode_Change_Request_address_name))
                {
                    await Task.Delay(100);
                }

                return true;
            }
        }
        public override string WIPINFO_BCR_ID
        {
            get => base.WIPINFO_BCR_ID;
            set
            {
                string newVale = value + "";
                if (_WIPINFO_BCR_ID != newVale)
                {
                    bool isNewAdd = string.IsNullOrEmpty(_WIPINFO_BCR_ID) && !string.IsNullOrEmpty(newVale);
                    bool isRemoved = !string.IsNullOrEmpty(_WIPINFO_BCR_ID) && string.IsNullOrEmpty(newVale);
                    bool isChanged = !string.IsNullOrEmpty(_WIPINFO_BCR_ID) && !string.IsNullOrEmpty(newVale);
                    bool isReadFail = newVale.ToLower().Contains("error");
                    if (isReadFail)
                        newVale = "T" + base.CreateTUNID();

                    if (isNewAdd)
                    {
                        SecsEventReport(CEID.CarrierInstallCompletedReport, newVale);
                        Properties.CarrierInstallTime = DateTime.Now;
                    }
                    if (isRemoved)
                    {
                        SecsEventReport(CEID.CarrierRemovedCompletedReport, newVale);
                    }

                    if (isChanged)
                    {
                        SecsEventReport(CEID.CarrierRemovedCompletedReport, _WIPINFO_BCR_ID).ContinueWith(async t =>
                        {
                            SecsEventReport(CEID.CarrierInstallCompletedReport, newVale);
                            Properties.CarrierInstallTime = DateTime.Now;
                        });
                    }
                    CSTIDOnPort = _WIPINFO_BCR_ID = newVale;
                    UpdateModbusBCRReport(newVale);

                }
            }
        }
        protected override async Task CarrierWaitoutSecsGemReportProcess(bool needWaitTransferCompletedReported = true, bool waitUnloadRequestOn = false)
        {
            if (Properties.SecsReport)
                await SecsEventReport(CEID.CarrierWaitOut, CSTIDOnPort);
            await base.CarrierWaitoutSecsGemReportProcess();
        }
    }
}
