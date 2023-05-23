using GPMCasstteConvertCIM.Alarm;
using GPMCasstteConvertCIM.CasstteConverter.Data;
using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.Forms;
using GPMCasstteConvertCIM.GPM_Modbus;
using GPMCasstteConvertCIM.GPM_SECS;
using GPMCasstteConvertCIM.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Secs4Net;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Windows.Forms.Design;
using static GPMCasstteConvertCIM.CasstteConverter.Data.clsAGVSData;
using static GPMCasstteConvertCIM.CasstteConverter.Data.clsMemoryAddress;
using static GPMCasstteConvertCIM.CasstteConverter.Enums;
using static GPMCasstteConvertCIM.GPM_Modbus.ModbusServerBase;
using static GPMCasstteConvertCIM.GPM_SECS.SECSMessageHelper;
using Item = Secs4Net.Item;

namespace GPMCasstteConvertCIM.CasstteConverter
{
    public partial class clsConverterPort : IModbusHSable
    {
        public clsConverterPort()
        {
        }

        public clsConverterPort(clsPortProperty property, clsCasstteConverter converterParent)
        {
            this.Properties = property;
            this.EQParent = converterParent;

            AGVSignals = new clsHS_Status_Signals();
            AGVSignals.OnValidSignalActive += AGVSignals_OnValidSignalActive;
        }

        public clsCasstteConverter EQParent { get; }

        public clsPortProperty Properties = new clsPortProperty();
        public event EventHandler<clsConverterPort> ModeChangeOnRequest;
        public event EventHandler<clsConverterPort> CarrierWaitInOnRequest;
        public event EventHandler<clsConverterPort> CarrierWaitOutOnReport;
        public event EventHandler<clsConverterPort> CarrierRemovedCompletedOnReport;
        public event EventHandler<clsConverterPort> OnValidSignalActive;
        public string PortNameWithEQName => EQParent.Name + $"-[{Properties.PortID}]";

        public string portNoName => $"PORT{Properties.PortNo + 1}";

        public Dictionary<PROPERTY, string> PortCIMBitAddress
        {
            get
            {
                List<clsMemoryAddress> portAddress = EQParent.LinkBitMap.FindAll(ad => ad.EOwner == OWNER.CIM && ad.EScope.ToString() == portNoName);
                return portAddress.ToDictionary(ad => ad.EProperty, ad => ad.Address);
            }
        }

        public Dictionary<PROPERTY, string> PortCIMWordAddress
        {
            get
            {
                List<clsMemoryAddress> portAddress = EQParent.LinkWordMap.FindAll(ad => ad.EOwner == OWNER.CIM && ad.EScope.ToString() == portNoName);
                return portAddress.ToDictionary(ad => ad.EProperty, ad => ad.Address);
            }
        }

        public Dictionary<PROPERTY, string> PortEQBitAddress
        {
            get
            {
                List<clsMemoryAddress> portAddress = EQParent.LinkBitMap.FindAll(ad => ad.EOwner == OWNER.EQP && ad.EScope.ToString() == portNoName && ad.EProperty != PROPERTY.Unknown);
                return portAddress.ToDictionary(ad => ad.EProperty, ad => ad.Address);
            }
        }

        public Dictionary<PROPERTY, string> PortEQWordAddress
        {
            get
            {
                List<clsMemoryAddress> portAddress = EQParent.LinkWordMap.FindAll(ad => ad.EOwner == OWNER.EQP && ad.EScope.ToString() == portNoName);
                return portAddress.ToDictionary(ad => ad.EProperty, ad => ad.Address);
            }
        }

        public List<clsMemoryAddress> EQModbusLinkBitAddress => EQParent.LinkBitMap.FindAll(ad => ad.EOwner == OWNER.EQP && ad.EScope.ToString() == portNoName && ad.Link_Modbus_Register_Number != -1);
        public List<clsMemoryAddress> EQModbusLinkWordAddress => EQParent.LinkWordMap.FindAll(ad => ad.EOwner == OWNER.EQP && ad.EScope.ToString() == portNoName && ad.Link_Modbus_Register_Number != -1);
        public List<clsMemoryAddress> CIMModbusLinkWordAddress => EQParent.LinkWordMap.FindAll(ad => ad.EOwner == OWNER.CIM && ad.EScope.ToString() == portNoName && ad.Link_Modbus_Register_Number != -1);
        private CIMComponent.MemoryTable VirtualMemoryTable => EQParent.CIMMemOptions.memoryTable;


        public void ModbusServerActive()
        {
            if (Properties.ModbusServer_Enable)
            {
                BuildModbusTCPServer(new frmModbusTCPServer());
                SyncRegisterData();
            }
        }

        private void AGVSignals_OnValidSignalActive(object? sender, EventArgs e)
        {
            OnValidSignalActive?.Invoke(this, this);
        }

        internal bool IsLoadHSRunning
        {
            get
            {
                return AGVSignals.AnySignalON() && L_REQ;
            }
        }
        internal bool IsUnloadHSRunning
        {
            get
            {
                return AGVSignals.AnySignalON() && U_REQ;
            }
        }

        public clsHS_Status_Signals AGVSignals { get; set; }

        public bool ReadyStatus { get; set; } = false;
        public bool LoadRequest { get; set; } = false;
        public bool UnloadRequest { get; set; } = false;
        public bool PortExist { get; set; } = false;
        public bool EQP_Status_Run { get; set; } = false;
        public bool EQP_Status_Idle { get; set; } = false;
        public bool EQP_Status_Down { get; set; } = false;
        public bool L_REQ { get; set; } = false;
        public bool U_REQ { get; set; } = false;
        public bool EQ_READY { get; set; } = false;
        public bool UP_READY { get; set; } = false;
        public bool LOW_READY { get; set; } = false;
        public bool Manual_Load_Complete { get; set; } = false;
        public bool Manual_UnLoad_Complete { get; set; } = false;


        public int PortModeStatus { get; set; }

        public int AGVSConnectStatus { get; set; }

        public int RackModeRequest { get; set; }
        public int PortModeRequest { get; set; }

        public int WIPInfo_BCR_ID_1 { get; set; }
        public int WIPInfo_BCR_ID_2 { get; set; }
        public int WIPInfo_BCR_ID_3 { get; set; }
        public int WIPInfo_BCR_ID_4 { get; set; }
        public int WIPInfo_BCR_ID_5 { get; set; }
        public int WIPInfo_BCR_ID_6 { get; set; }
        public int WIPInfo_BCR_ID_7 { get; set; }
        public int WIPInfo_BCR_ID_8 { get; set; }
        public int WIPInfo_BCR_ID_9 { get; set; }
        public int WIPInfo_BCR_ID_10 { get; set; }

        public DateTime CarrierInstallTime { get; private set; } = DateTime.Now;
        public AUTO_MANUAL_MODE EPortAutoStatus
        {
            get
            {
                try
                {
                    return Enum.GetValues(typeof(AUTO_MANUAL_MODE)).Cast<AUTO_MANUAL_MODE>().First(en => Port_Auto_Manual_Mode_Status == (int)en);

                }
                catch (Exception)
                {
                    return AUTO_MANUAL_MODE.Unknown;
                }
            }
        }

        public string WIPINFO_BCR_ID
        {
            get
            {
                List<int> ints = new List<int>() {
                 WIPInfo_BCR_ID_1,
                 WIPInfo_BCR_ID_2,
                 WIPInfo_BCR_ID_3,
                 WIPInfo_BCR_ID_4,
                 WIPInfo_BCR_ID_5,
                 WIPInfo_BCR_ID_6,
                 WIPInfo_BCR_ID_7,
                 WIPInfo_BCR_ID_8,
                 WIPInfo_BCR_ID_9,
                 WIPInfo_BCR_ID_10
                };
                string id = ints.FindAll(i => i != 0).ToASCII();
                return id;
            }
        }

        public bool EQ_BUSY { get; internal set; }
        private bool _PortStatusDown = false;
        public bool PortStatusDown
        {
            get => _PortStatusDown;
            set
            {
                if (_PortStatusDown != value)
                {
                    _PortStatusDown = value;
                    if (_PortStatusDown)
                        PortInServiceReport();
                    else
                        PortOutOfServiceReport();
                    Properties.InSerivce = _PortStatusDown;
                }
            }
        }
        public bool LD_UP_POS { get; internal set; }
        public bool LD_DOWN_POS { get; internal set; }
        public bool DoorOpened { get; internal set; }
        public bool TB_DOWN_POS { get; internal set; }


        private bool _CarrierWaitINSystemRequest;
        public bool CarrierWaitINSystemRequest
        {
            get => _CarrierWaitINSystemRequest;
            internal set
            {
                if (value != _CarrierWaitINSystemRequest)
                {
                    CarrierInstallTime = DateTime.Now;
                    _CarrierWaitINSystemRequest = value;
                    if (_CarrierWaitINSystemRequest)
                    {
                        Task.Factory.StartNew(async () =>
                        {
                            Utilities.Utility.SystemLogger.Info($"Carrier Wait In HS Start");

                            bool timeout = await CarrierWaitInReply();
                            if (timeout)
                            {
                                AlarmManager.AddAlarm(ALARM_CODES.CarrierWaitIn_HS_EQ_Timeout, PortNameWithEQName);
                            }
                            else
                            {
                                Utilities.Utility.SystemLogger.Info($"Carrier Wait In HS Finish");
                            }
                        });
                    }
                }
            }
        }
        private bool _CarrierWaitOUTSystemRequest;
        public bool CarrierWaitOUTSystemRequest
        {
            get => _CarrierWaitOUTSystemRequest;
            internal set
            {
                if (value != _CarrierWaitOUTSystemRequest)
                {
                    _CarrierWaitOUTSystemRequest = value;
                    if (_CarrierWaitOUTSystemRequest)
                    {
                        CarrierWaitOutReply();
                    }
                }
            }
        }

        private bool _CarrierRemovedCompletedReport;
        public bool CarrierRemovedCompletedReport
        {
            get => _CarrierRemovedCompletedReport;
            internal set
            {
                if (value != _CarrierRemovedCompletedReport)
                {
                    _CarrierRemovedCompletedReport = value;
                    if (_CarrierRemovedCompletedReport)
                    {
                        CarrierRemovedCompletedReply();

                    }
                }
            }
        }
        public bool Port_Mode_Change_Accept { get; internal set; }
        public bool Port_Mode_Changed_Refuse { get; internal set; }
        public bool _Port_Mode_Changed_Report = false;
        public bool Port_Mode_Changed_Report
        {
            get => _Port_Mode_Changed_Report;
            set
            {
                if (_Port_Mode_Changed_Report != value)
                {
                    _Port_Mode_Changed_Report = value;
                    if (_Port_Mode_Changed_Report)
                    {
                        PortModeChangedReportHandshake();
                    }
                }
            }
        }



        public bool Port_Disabled_Report { get; internal set; }
        public bool Port_Enabled_Report { get; internal set; }
        public int Port_Auto_Manual_Mode_Status { get; internal set; }
        private int _PortType = 0;
        /// <summary>
        /// 0: INput , 1: Output , 2: In-Output
        /// </summary>
        public int PortType
        {
            get => _PortType;
            set
            {
                if (_PortType != value)
                {
                    Task.Factory.StartNew(() =>
                    {
                        try
                        {
                            if (value == 0)
                                PortTypeInputReport();
                            if (value == 1)
                                PortTypeOutputReport();
                        }
                        catch (Exception ex)
                        {
                            Utility.SystemLogger.Error("Error Occur when Port Type Changed and Report To MCS", ex);
                        }
                    });
                }
                _PortType = value;

            }
        }
        internal PortUnitType EPortType => Enum.GetValues(typeof(PortUnitType)).Cast<PortUnitType>().First(etype => (int)etype == _PortType);

        public ModbusTCPServer modbus_server { get; set; }

        public bool BuildModbusTCPServer(frmModbusTCPServer ui)
        {
            try
            {
                modbus_server = new ModbusTCPServer();
                modbus_server.CoilsOnChanged += Modbus_server_CoilsOnChanged;
                modbus_server.linkedCasstteConverter = EQParent;
                ui.ModbusTCPServer = modbus_server;
                modbus_server.Active(Properties.ModbusServer_IP, Properties.ModbusServer_PORT, ui);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Modbus_server_CoilsOnChanged(object? sender, ModbusProtocol e)
        {
            ///要把Coil Data同步到PLC Memory 
            Task.Factory.StartNew(() =>
            {
                string portNoName = $"PORT{Properties.PortNo + 1}";
                List<CasstteConverter.Data.clsMemoryAddress> CIMLinkAddress = EQParent.LinkBitMap.FindAll(ad => ad.EOwner == OWNER.CIM && ad.EScope.ToString() == portNoName && ad.Link_Modbus_Register_Number != -1);
                foreach (var item in CIMLinkAddress)
                {
                    int register_num = item.Link_Modbus_Register_Number;
                    var localCoilsAry = modbus_server.coils.localArray;
                    bool state = localCoilsAry[register_num + 1];
                    EQParent.CIMMemOptions.memoryTable.WriteOneBit(item.Address, state);
                }

            });
        }

        public void SyncRegisterData()
        {
            Task.Run(async () =>
            {
                while (true)
                {

                    foreach (var item in EQModbusLinkBitAddress)
                    {
                        bool bolState = EQParent.EQPMemOptions.memoryTable.ReadOneBit(item.Address);
                        modbus_server.discreteInputs.localArray[item.Link_Modbus_Register_Number] = bolState;
                    }

                    foreach (var item in EQModbusLinkWordAddress)
                    {
                        int value = EQParent.EQPMemOptions.memoryTable.ReadBinary(item.Address);
                        modbus_server.holdingRegisters.localArray[item.Link_Modbus_Register_Number] = (short)value;
                    }


                    foreach (var item in CIMModbusLinkWordAddress)
                    {
                        int value = EQParent.CIMMemOptions.memoryTable.ReadBinary(item.Address);
                        modbus_server.holdingRegisters.localArray[item.Link_Modbus_Register_Number] = (short)value;
                    }

                    await Task.Delay(10);
                }

            });
        }

    }
}
