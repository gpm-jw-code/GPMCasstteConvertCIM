using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.CasstteConverter.Data;
using GPMCasstteConvertCIM.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.CasstteConverter.Enums;

namespace GPMCasstteConvertCIM.Cclink_IE_Sturcture
{
    internal class clsCCLinkIE_Station : clsCasstteConverter
    {
        internal clsCCLinkIE_Master cclink_master;
        public EQ_NAMES Eq_Name { get; set; } = EQ_NAMES.Unkown;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="InterfaceOptions"></param>
        /// <returns></returns>
        internal override async Task<bool> ActiveAsync(McInterfaceOptions InterfaceOptions)
        {
            connectionState = Utilities.Common.CONNECTION_STATE.CONNECTING;
            await Task.Delay(1000);
            connectionState = Utilities.Common.CONNECTION_STATE.CONNECTED;
            return true;
        }

        public clsCCLinkIE_Station(EQ_NAMES Eq_Name, UI_UserControls.UscCasstteConverter mainUI, CONVERTER_TYPE converterType, Dictionary<int, clsConverterPort.clsPortProperty> portProperties,clsCCLinkIE_Master cclink_master) 
        {
            this.cclink_master = cclink_master;
            this.Eq_Name = Eq_Name;
            EQPData = new clsEQPData(portProperties, this);
            this.plcInterface =  PLC_CONN_INTERFACE.MX;
            LoadPLCMapData();
            //this.mainGUI = mainGUI;
            //this.mainGUI.casstteConverter = this;
            PortModbusServersActive();
            EQPInterfaceClockMonitor();
            CIMInterfaceClockUpdate();
            PLCMemorySyncTask();
            DataSyncTask();
        }
        public override void LoadPLCMapData()
        {
            LinkBitMap = cclink_master.LinkBitMap.FindAll(add=>add.EQ_Name==this.Eq_Name);
            LinkWordMap = cclink_master.LinkWordMap.FindAll(add=>add.EQ_Name==this.Eq_Name);

            //string eqp_bitStartAddress = LinkBitMap.First(i => i.EOwner == clsMemoryAddress.OWNER.EQP).Address;
            //string eqp_bitEndAddress = LinkBitMap.Last(i => i.EOwner == clsMemoryAddress.OWNER.EQP).Address;
            //string eqp_wordStartAddress = LinkWordMap.First(i => i.EOwner == clsMemoryAddress.OWNER.EQP).Address;
            //string eqp_wordEndAddress = LinkWordMap.Last(i => i.EOwner == clsMemoryAddress.OWNER.EQP).Address;

            //string cim_bitStartAddress = LinkBitMap.First(i => i.EOwner == clsMemoryAddress.OWNER.CIM).Address;
            //string cim_bitEndAddress = LinkBitMap.Last(i => i.EOwner == clsMemoryAddress.OWNER.CIM).Address;
            //string cim_wordStartAddress = LinkWordMap.First(i => i.EOwner == clsMemoryAddress.OWNER.CIM).Address;
            //string cim_wordEndAddress = LinkWordMap.Last(i => i.EOwner == clsMemoryAddress.OWNER.CIM).Address;


            //EQPMemOptions = new clsMemoryGroupOptions(eqp_bitStartAddress, eqp_bitEndAddress, eqp_wordStartAddress, eqp_wordEndAddress);
            //CIMMemOptions = new clsMemoryGroupOptions(cim_bitStartAddress, cim_bitEndAddress, cim_wordStartAddress, cim_wordEndAddress);


        }
        protected override async Task PLCMemorySyncTask()
        {
            _ = Task.Run(async () =>
            {
                //while (true)
                //{
                //    Thread.Sleep(10);
                //}
            });
        }

        protected override void SyncMemData()
        {
            PLCMemoryDatatToEQDataDTO();
        }
        protected override void PLCMemoryDatatToEQDataDTO()
        {
            //PORTS

            List<EQ_SCOPE> port_scopes = new List<EQ_SCOPE>();
            for (int i = 0; i < EQPData.PortDatas.Count; i++)
            {
                string port_scope_string = $"PORT{i + 1}";
                port_scopes.Add(Enum.GetValues(typeof(EQ_SCOPE)).Cast<EQ_SCOPE>().First(s => s.ToString() == port_scope_string));
            }

            for (int i = 0; i < port_scopes.Count; i++)
            {
                EQ_SCOPE port = port_scopes[i];

                //EQP Bit data
                EQPData.PortDatas[i].LoadRequest = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Load_Request).Value;
                EQPData.PortDatas[i].UnloadRequest = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Unload_Request).Value;
                EQPData.PortDatas[i].PortExist = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Exist).Value;
                bool port_status_down = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Status_Down).Value;
                EQPData.PortDatas[i].LD_UP_POS = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.LD_UP_POS).Value;
                EQPData.PortDatas[i].LD_DOWN_POS = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.LD_DOWN_POS).Value;
                EQPData.PortDatas[i].PortStatusDown = port_status_down;

            }

        }

    }
}
