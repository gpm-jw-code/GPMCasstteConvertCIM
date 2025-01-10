using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.GPM_SECS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //return base.ModeChangeRequestHandshake(portUnitType, requester_name, no_change_if_current_type_is_req);
            PortType = (int)portUnitType;
            return true;
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
            //return base.CarrierWaitoutSecsGemReportProcess();
        }
    }
}
