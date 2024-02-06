using CIMComponent;
using GPMCasstteConvertCIM.Alarm;
using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.CasstteConverter.Data;
using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.GPM_Modbus;
using GPMCasstteConvertCIM.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.CasstteConverter.Data.clsMemoryAddress;
using static GPMCasstteConvertCIM.CasstteConverter.Enums;

namespace GPMCasstteConvertCIM.Cclink_IE_Sturcture
{
    internal class clsCCLinkIE_Station : clsCasstteConverter
    {
        public override List<clsConverterPort> PortDatas { get => base.PortDatas; set => base.PortDatas = value; }
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

        public clsCCLinkIE_Station(EQ_NAMES Eq_Name, Dictionary<int, clsConverterPort.clsPortProperty> portProperties, clsCCLinkIE_Master cclink_master)
        {
            this.cclink_master = cclink_master;
            this.Eq_Name = Eq_Name;
            Name = Eq_Name.ToString();
            EQPData = new clsEQPData();
            this.plcInterface = PLC_CONN_INTERFACE.MX;
            LoadPLCMapData();
            this._IOLogger = new clsIOLOgger(null, Utility.SysConfigs.Log.SyslogFolder, $"IO/{cclink_master.Name}");
            for (int i = 0; i < portProperties.Count; i++)
            {
                var portProp = portProperties[i];
                var stationPort = new clsStationPort(portProp, this)
                {
                    LinkBitMap = this.LinkBitMap,
                    LinkWordMap = this.LinkWordMap,
                    EQParent = this
                };
                PortDatas.Add(stationPort);
            }
            //this.mainGUI = mainGUI;
            //this.mainGUI.casstteConverter = this;
            PortModbusServersActive();
            // EQPInterfaceClockMonitor();

            if (Eq_Name == EQ_NAMES.TS_1 | Eq_Name == EQ_NAMES.TS_2_1 | Eq_Name == EQ_NAMES.TS_2_2 | Eq_Name == EQ_NAMES.TS_3)
                CIMInterfaceClockUpdate();

            DataSyncTask();
        }

        protected override void CIMInterfaceClockUpdate()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(TimeSpan.FromSeconds(4));

                    var interfaceClockAddress = cclink_master.LinkWordMap.FirstOrDefault(w => w.EOwner == clsMemoryAddress.OWNER.CIM && w.EProperty == PROPERTY.Interface_Clock);
                    if (interfaceClockAddress != null)
                    {
                        int clock = (int)interfaceClockAddress.Value;
                        int newClock = clock + 1;
                        newClock = newClock == 256 ? 0 : newClock;
                        cclink_master.CIMMemOptions.memoryTable.WriteBinary(interfaceClockAddress.Address, newClock);
                    }

                }

            });
        }

        protected override void LoadPLCMapData()
        {
            LinkBitMap = cclink_master.LinkBitMap.FindAll(add => add.EQ_Name == this.Eq_Name);
            LinkWordMap = cclink_master.LinkWordMap.FindAll(add => add.EQ_Name == this.Eq_Name);
        }
        protected override async void PortModbusServersActive()
        {
            foreach (var item in PortDatas)
            {
                item.ModbusServerActive();
            }
        }

        protected override async Task SyncMemData()
        {
            PLCMemoryDatatToEQDataDTO();
        }
        protected override void PLCMemoryDatatToEQDataDTO()
        {
            //PORTS
            if (Eq_Name == EQ_NAMES.TS_1 | Eq_Name == EQ_NAMES.TS_2_1 | Eq_Name == EQ_NAMES.TS_2_2 | Eq_Name == EQ_NAMES.TS_3)
            {
                base.LinkBitMap = this.LinkBitMap;
                base.LinkWordMap = this.LinkWordMap;
                base.PLCMemoryDatatToEQDataDTO();
                return;
            }
            List<EQ_SCOPE> port_scopes = new List<EQ_SCOPE>();
            for (int i = 0; i < PortDatas.Count; i++)
            {
                string port_scope_string = $"PORT{i + 1}";
                port_scopes.Add(Enum.GetValues(typeof(EQ_SCOPE)).Cast<EQ_SCOPE>().First(s => s.ToString() == port_scope_string));
            }

            for (int i = 0; i < port_scopes.Count; i++)
            {
                EQ_SCOPE port = port_scopes[i];

                //EQP Bit data
                PortDatas[i].LoadRequest = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Load_Request).Value;
                PortDatas[i].UnloadRequest = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Unload_Request).Value;
                PortDatas[i].PortExist = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Exist).Value;
                bool port_status_down = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Status_Down).Value;
                PortDatas[i].LD_UP_POS = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.LD_UP_POS).Value;
                PortDatas[i].LD_DOWN_POS = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.LD_DOWN_POS).Value;
                PortDatas[i].PortStatusDown = port_status_down;

            }

        }

    }


    public class clsStationPort : clsConverterPort
    {
        internal List<clsMemoryAddress> LinkBitMap { get; set; }
        internal List<clsMemoryAddress> LinkWordMap { get; set; }
        public override MemoryTable CIMMemoryTable
        {
            get
            {
                return DevicesManager.cclink_master.CIMMemOptions.memoryTable;
            }
        }
        public clsStationPort(clsPortProperty property, clsCasstteConverter converterParent) : base(property, converterParent)
        {

        }

        protected override void WriteAGVHandshakeStatusToPLC(clsAGVHandshakeState agv_hs_status)
        {
            try
            {
                DevicesManager.cclink_master.CIMMemOptions.memoryTable.WriteOneBit(PortCIMBitAddress[PROPERTY.VALID], agv_hs_status.AGV_VALID);
                DevicesManager.cclink_master.CIMMemOptions.memoryTable.WriteOneBit(PortCIMBitAddress[PROPERTY.TR_REQ], agv_hs_status.AGV_TR_REQ);
                DevicesManager.cclink_master.CIMMemOptions.memoryTable.WriteOneBit(PortCIMBitAddress[PROPERTY.BUSY], agv_hs_status.AGV_BUSY);
                DevicesManager.cclink_master.CIMMemOptions.memoryTable.WriteOneBit(PortCIMBitAddress[PROPERTY.AGV_READY], agv_hs_status.AGV_READY);
                DevicesManager.cclink_master.CIMMemOptions.memoryTable.WriteOneBit(PortCIMBitAddress[PROPERTY.COMPT], agv_hs_status.AGV_COMPT);
            }
            catch (Exception ex)
            {
                Utility.SystemLogger.Error(ex.Message, ex);
            }


        }
        protected override void SyncAGVSCoilsDataWorker()
        {
            string portNoName = $"PORT{Properties.PortNo + 1}";
            List<CasstteConverter.Data.clsMemoryAddress> CIMLinkAddress = DevicesManager.cclink_master.LinkBitMap.FindAll(ad => ad.EQ_Name == ((clsCCLinkIE_Station)EQParent).Eq_Name && ad.EOwner == OWNER.CIM && ad.EScope.ToString() == portNoName && ad.Link_Modbus_Register_Number != -1);
            foreach (var item in CIMLinkAddress)
            {
                try
                {
                    int register_num = item.Link_Modbus_Register_Number;
                    var localCoilsAry = modbus_server.coils.localArray;
                    bool state = localCoilsAry[register_num + 1];
                    AGVHandshakeIO(item, state);
                    DevicesManager.cclink_master.CIMMemOptions.memoryTable.WriteOneBit(item.Address, state);
                }
                catch (Exception ex)
                {
                    Utility.SystemLogger.Error(ex.Message, ex, false);
                }
            }
        }

        public override void SyncModbusDataWorker()
        {
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    await Task.Delay(10);
                    try
                    {

                        if (DevicesManager.cclink_master.EQPMemOptions == null)
                            continue;
                        SyncAGVSInputsWorker();
                        SyncEQHoldingRegistersWorker();
                        SyncAGVSCoilsDataWorker();
                    }
                    catch (Exception ex)
                    {
                        AlarmManager.AddAlarm(ALARM_CODES.CODE_ERROR, "clsStationPort", false);
                    }
                }
            });

            Thread _thread = new Thread(() => {
                CheckDiscardInputWriteResultBackgroundWorker();
            });
            _thread.IsBackground = true;
            _thread.Start();
        }

        protected override void SyncEQHoldingRegistersWorker()
        {
            var wordMap = LinkWordMap.FindAll(ad => ad.EScope.ToString() == this.portNoName && ad.EOwner == OWNER.EQP);
            foreach (clsMemoryAddress item in wordMap)
            {
                if (item.Link_Modbus_Register_Number != -1)
                {
                    int value = DevicesManager.cclink_master.EQPMemOptions.memoryTable.ReadBinary(item.Address);
                    modbus_server.holdingRegisters.localArray[item.Link_Modbus_Register_Number] = (short)value;
                }
            }
        }

        protected override void SyncAGVSInputsWorker()
        {
            var bitMap = LinkBitMap.FindAll(ad => ad.EScope.ToString() == this.portNoName && ad.EOwner == OWNER.EQP);
            foreach (clsMemoryAddress item in bitMap)
            {
                if (item.Link_Modbus_Register_Number != -1)
                {
                    bool bolState = IsIOSimulating ? (bool)item.ControlValue : DevicesManager.cclink_master.EQPMemOptions.memoryTable.ReadOneBit(item.Address);

                    if (Utility.SysConfigs.EQLoadUnload_RequestSimulation && this.Properties.LoadUnlloadStateSimulation)
                    {
                        if (item.EProperty == Enums.PROPERTY.Load_Request | item.EProperty == Enums.PROPERTY.Unload_Request)
                            bolState = true;
                    }
                    modbus_server.discreteInputs.localArray[item.Link_Modbus_Register_Number] = bolState;
                }
            }
        }
    }

}

