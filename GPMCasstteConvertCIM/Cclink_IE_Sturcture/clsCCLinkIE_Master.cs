using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.CasstteConverter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.CasstteConverter.Enums;

namespace GPMCasstteConvertCIM.Cclink_IE_Sturcture
{
    internal class clsCCLinkIE_Master : clsCasstteConverter
    {
        public clsCCLinkIE_Master(string name )
        {
            this.Name = name;
            this.plcInterface = PLC_CONN_INTERFACE.MX;
            LoadPLCMapData();
            PLCMemorySyncTask();
            DataSyncTask();
        }

        protected override void PLCMemoryDatatToEQDataDTO()
        {
        }
    }
}
