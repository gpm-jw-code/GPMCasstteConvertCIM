using GPMCasstteConvertCIM.Alarm;
using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.CasstteConverter.Data;
using GPMCasstteConvertCIM.UI_UserControls;
using GPMCasstteConvertCIM.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.CasstteConverter.Enums;

namespace GPMCasstteConvertCIM.Cclink_IE_Sturcture
{
    public class clsCCLinkIE_Master : clsCasstteConverter
    {

        protected override string BitMapFileName_EQ { get; set; } = "src\\Map_U007\\PLC_Bit_Map_EQ.csv";
        protected override string WordMapFileName_EQ { get; set; } = "src\\Map_U007\\PLC_Word_Map_EQ.csv";
        protected override string BitMapFileName_CIM { get; set; } = "src\\Map_U007\\PLC_Bit_Map_CIM.csv";
        protected override string WordMapFileName_CIM { get; set; } = "src\\Map_U007\\PLC_Word_Map_CIM.csv";

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
            RegistMemoryAddressValuesChangedEvent();
        }

        protected override void Item_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            clsMemoryAddress add = (clsMemoryAddress)sender;

            if (add.EProperty == PROPERTY.Interface_Clock)
            {
                return;
            }
            clsCCLinkIE_Station? station = Stations.FirstOrDefault(st => st.LinkBitMap.Any(ad => ad.Address == add.Address));
            var stationName = station == null ? "" : station.PortDatas[add.EScope == EQ_SCOPE.PORT1 ? 0 : 1].PortName;
            Utility.SystemLogger.Info($"{Name}-{stationName}-->{add.DataName}({add.Address}) Changed to [{add.Value}]");
        }

        protected override void PLCMemoryDatatToEQDataDTO()
        {
        }

        protected override async Task SyncMemData()
        {
            try
            {
                await base.SyncMemData();
                //if (mainGUI.BindingPorts != null)
                //{
                //    mainGUI.Invoke(new Action(() =>
                //    {
                //        mainGUI.GUIRefresh();
                //    }));
                //}
            }
            catch (Exception ex)
            {
                AlarmManager.AddAlarm(ALARM_CODES.SYNCMEMDATA_FUNCTION_CODE_ERROR, GetType().Name, false);
            }
        }
    }
}
