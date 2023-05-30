using GPMCasstteConvertCIM.GPM_SECS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.CasstteConverter.Enums;
using static GPMCasstteConvertCIM.VirtualAGVSystem.clsAGVCState;

namespace GPMCasstteConvertCIM.API.WebsocketSupport.ViewModel
{
    public class PortViewModel
    {
        public string PortID { get; set; } = "";
        public bool IsInService { get; set; }

        public string Carrier_ID { get; set; } = "";

        public PortUnitType PortType { get; set; }
        public AUTO_MANUAL_MODE AutoState { get; set; } = AUTO_MANUAL_MODE.MANUAL;

        public DIOViewModel DIOSignalsState { get; set; } = new DIOViewModel();
        public HSSignalViewModel HSSignalsState { get; set; } = new HSSignalViewModel();

    }

    public class HSSignalViewModel
    {
        public bool L_REQ { get; set; }
        public bool U_REQ { get; set; }
        public bool EQ_BUSY { get; set; }
        public bool EQ_READY { get; set; }
    }

    public class DIOViewModel
    {
        public bool LoadRequest { get; set; }
        public bool UnloadRequest { get; set; }

        public bool PortExist { get; set; }

        public bool PortStatusDown { get; set; }

        public bool LDUpPose { get; set; }
        public bool LDDownPose { get; set; }
    }
}
