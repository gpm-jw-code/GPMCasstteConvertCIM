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
            if (add == null || add.EProperty == PROPERTY.Interface_Clock)
                return;

            clsCCLinkIE_Station? station = Stations.FirstOrDefault(st => st.LinkBitMap.Any(ad => ad.Address == add.Address));
            var owner_str = add.EOwner == clsMemoryAddress.OWNER.CIM ? "CIM/AGVS" : "EQ";

            try
            {
                if (add.EScope == EQ_SCOPE.PORT1 | add.EScope == EQ_SCOPE.PORT2)
                {
                    var stationName = station == null ? "" : station.PortDatas[add.EScope == EQ_SCOPE.PORT1 ? 0 : 1].PortName;
                    Utility.SystemLogger.Info($"{Name}-{stationName}-->[{owner_str}]{add.DataName}({add.Address}) Changed to [{add.Value}]");
                }
                else
                {
                    Utility.SystemLogger.Info($"{Name}-->[{owner_str}]{add.DataName}({add.Address}) Changed to [{add.Value}]");
                }
            }
            catch (Exception ex)
            {
                Utility.SystemLogger.Warning(ex.Message);
                Utility.SystemLogger.Info($"{Name}-->[{owner_str}]{add.DataName}({add.Address}) Changed to [{add.Value}]");
            }
        }

        protected override void PLCMemoryDatatToEQDataDTO()
        {
        }

    }
}
