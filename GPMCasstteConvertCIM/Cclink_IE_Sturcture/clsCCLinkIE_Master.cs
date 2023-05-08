using GPMCasstteConvertCIM.Alarm;
using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.CasstteConverter.Data;
using GPMCasstteConvertCIM.UI_UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.CasstteConverter.Enums;

namespace GPMCasstteConvertCIM.Cclink_IE_Sturcture
{
    public class clsCCLinkIE_Master : clsCasstteConverter
    {
        internal new UscEQStatus mainGUI;
        internal List<clsCCLinkIE_Station> Stations { get; set; } = new List<clsCCLinkIE_Station>();

        public List<clsConverterPort> AllEqPortList
        {
            get
            {
                return Stations.SelectMany(eq => eq.PortDatas.Select(st => (clsConverterPort)st)).ToList();
            }
        }
        public clsCCLinkIE_Master(string name, UscEQStatus ui)
        {
            this.Name = name;
            this.mainGUI = ui;
            this.plcInterface = PLC_CONN_INTERFACE.MX;
            LoadPLCMapData();
            PLCMemorySyncTask();
            DataSyncTask();
        }



        protected override void PLCMemoryDatatToEQDataDTO()
        {
        }

        protected override void SyncMemData()
        {
            try
            {
                base.SyncMemData();
                if (mainGUI.BindingPorts != null)
                {
                    mainGUI.Invoke(new Action(() =>
                    {
                        mainGUI.BindingPorts.ResetBindings();
                    }));
                }
            }
            catch (Exception ex)
            {
                AlarmManager.AddAlarm( ALARM_CODES.SYNCMEMDATA_FUNCTION_CODE_ERROR , GetType().Name,false);
            }
        }
    }
}
