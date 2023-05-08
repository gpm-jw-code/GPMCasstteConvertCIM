using GPMCasstteConvertCIM.Alarm;
using GPMCasstteConvertCIM.CasstteConverter.Data;
using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.Forms;
using GPMCasstteConvertCIM.GPM_Modbus;
using GPMCasstteConvertCIM.GPM_SECS;
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
    public class clsConverterPort : IModbusHSable
    {
        public clsCasstteConverter converterParent { get; }

        public class clsPortProperty
        {
            /// <summary>
            /// (Zero-Based)
            /// </summary>
            public int PortNo { get; set; }
            public string PortID { get; set; } = "Port 1";
            internal bool InSerivce { get; set; } = false;

            public string ModbusServer_IP { get; set; } = "127.0.0.1";
            public int ModbusServer_PORT { get; set; } = 1502;

            public bool ModbusServer_Enable = true;

            internal PortUnitType PortType { get; set; } = PortUnitType.Input_Output;


        }

        public class HandShakeResult
        {
            public bool Finish;
            public string Message;
            public bool Timeout;

            public void Reset()
            {
                Finish = Timeout = false;
                Message = "";
            }
        }

        public clsPortProperty Properties = new clsPortProperty();
        public event EventHandler<clsConverterPort> ModeChangeOnRequest;
        public event EventHandler<clsConverterPort> CarrierWaitInOnRequest;
        public event EventHandler<clsConverterPort> CarrierWaitOutOnReport;
        public event EventHandler<clsConverterPort> CarrierRemovedCompletedOnReport;
        public event EventHandler<clsConverterPort> OnValidSignalActive;

        public string EqName => converterParent.Name;
        public string PortName => Properties.PortID;
        public string PortNameWithEQName => converterParent.Name + $"-[{Properties.PortID}]";

        public string portNoName => $"PORT{Properties.PortNo + 1}";

        public Dictionary<PROPERTY, string> PortCIMBitAddress
        {
            get
            {
                List<clsMemoryAddress> portAddress = converterParent.LinkBitMap.FindAll(ad => ad.EOwner == OWNER.CIM && ad.EScope.ToString() == portNoName);
                return portAddress.ToDictionary(ad => ad.EProperty, ad => ad.Address);
            }
        }

        public Dictionary<PROPERTY, string> PortCIMWordAddress
        {
            get
            {
                List<clsMemoryAddress> portAddress = converterParent.LinkWordMap.FindAll(ad => ad.EOwner == OWNER.CIM && ad.EScope.ToString() == portNoName);
                return portAddress.ToDictionary(ad => ad.EProperty, ad => ad.Address);
            }
        }

        public Dictionary<PROPERTY, string> PortEQBitAddress
        {
            get
            {
                List<clsMemoryAddress> portAddress = converterParent.LinkBitMap.FindAll(ad => ad.EOwner == OWNER.EQP && ad.EScope.ToString() == portNoName && ad.EProperty != PROPERTY.Unknown);
                return portAddress.ToDictionary(ad => ad.EProperty, ad => ad.Address);
            }
        }

        public Dictionary<PROPERTY, string> PortEQWordAddress
        {
            get
            {
                List<clsMemoryAddress> portAddress = converterParent.LinkWordMap.FindAll(ad => ad.EOwner == OWNER.EQP && ad.EScope.ToString() == portNoName);
                return portAddress.ToDictionary(ad => ad.EProperty, ad => ad.Address);
            }
        }

        public List<clsMemoryAddress> EQModbusLinkBitAddress => converterParent.LinkBitMap.FindAll(ad => ad.EOwner == OWNER.EQP && ad.EScope.ToString() == portNoName && ad.Link_Modbus_Register_Number != -1);
        public List<clsMemoryAddress> EQModbusLinkWordAddress => converterParent.LinkWordMap.FindAll(ad => ad.EOwner == OWNER.EQP && ad.EScope.ToString() == portNoName && ad.Link_Modbus_Register_Number != -1);
        public List<clsMemoryAddress> CIMModbusLinkWordAddress => converterParent.LinkWordMap.FindAll(ad => ad.EOwner == OWNER.CIM && ad.EScope.ToString() == portNoName && ad.Link_Modbus_Register_Number != -1);
        private CIMComponent.MemoryTable VirtualMemoryTable => converterParent.CIMMemOptions.memoryTable;
        public clsConverterPort()
        {
        }

        public clsConverterPort(clsPortProperty property, clsCasstteConverter converterParent)
        {
            this.Properties = property;
            this.converterParent = converterParent;

            AGVSignals = new clsHS_Status_Signals();
            AGVSignals.OnValidSignalActive += AGVSignals_OnValidSignalActive;
        }

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
                return ints.ToASCII();
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
                    if (!_PortStatusDown)
                        PortOutOfServiceReport();
                    else
                        PortInServiceReport();
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
                    _CarrierWaitINSystemRequest = value;
                    if (_CarrierWaitINSystemRequest)
                    {
                        Task.Factory.StartNew(async () =>
                        {
                            bool timeout = await CarrierWaitInReply();
                            if (timeout)
                            {
                                AlarmManager.AddAlarm(ALARM_CODES.CarrierWaitIn_HS_EQ_Timeout, PortNameWithEQName);
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


        private async Task<bool> ModeChangeRequestHandshake(PortUnitType portUnitType)
        {
            bool plc_accept = false;
            string port_type_data_address_name = PortCIMWordAddress[PROPERTY.Port_Type_Status];
            string cim_2_eq_port_mode_change_req_address_name = PortCIMBitAddress[PROPERTY.Port_Mode_Change_Request];

            string eq_2_cim_port_mode_change_accept_address_name = PortEQBitAddress[PROPERTY.Port_Mode_Change_Accept];
            string eq_2_cim_port_mode_change_refuse_address_name = PortEQBitAddress[PROPERTY.Port_Mode_Changed_Refuse];

            var plc_accept_address = converterParent.LinkBitMap.First(ad => ad.Address == eq_2_cim_port_mode_change_accept_address_name);
            var plc_refuse_address = converterParent.LinkBitMap.First(ad => ad.Address == eq_2_cim_port_mode_change_refuse_address_name);

            //write porttype data to word memory
            VirtualMemoryTable.WriteBinary(port_type_data_address_name, (int)portUnitType);
            await Task.Delay(1000);
            //On CIM Bit
            VirtualMemoryTable.WriteOneBit(cim_2_eq_port_mode_change_req_address_name, true);
            //wait EQ Bit on

            CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            bool timeout = false;
            while (!(bool)plc_accept_address.Value && !(bool)plc_refuse_address.Value)
            {
                await Task.Delay(10);
                if (cts.IsCancellationRequested)
                {
                    VirtualMemoryTable.WriteOneBit(cim_2_eq_port_mode_change_req_address_name, false);
                    VirtualMemoryTable.WriteBinary(port_type_data_address_name, 0);
                    return false;
                }
            }
            plc_accept = (bool)plc_accept_address.Value;
            VirtualMemoryTable.WriteOneBit(cim_2_eq_port_mode_change_req_address_name, false);
            cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            while ((bool)plc_accept_address.Value | (bool)plc_refuse_address.Value)
            {
                await Task.Delay(10);
                if (cts.IsCancellationRequested)
                {
                    VirtualMemoryTable.WriteBinary(port_type_data_address_name, 0);
                    return false;
                }
            }
            VirtualMemoryTable.WriteBinary(port_type_data_address_name, 0);
            return plc_accept;
        }
        private async void PortModeChangedReportHandshake()
        {
            _ = Task.Factory.StartNew(() =>
            {
                clsMemoryAddress eq_to_cim_report_adress = converterParent.LinkBitMap.First(i => i.EOwner == OWNER.EQP && i.EScope.ToString() == portNoName && i.EProperty == PROPERTY.Port_Mode_Changed_Report);
                string cim_2_eq_reply_address = PortCIMBitAddress[PROPERTY.Port_Mode_Changed_Report_Reply];
                //ON CIM BIT
                converterParent.CIMMemOptions.memoryTable.WriteOneBit(cim_2_eq_reply_address, true);
                CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
                bool timeout = false;
                //等待EQ OFF BIT
                while ((bool)eq_to_cim_report_adress.Value)
                {
                    Thread.Sleep(1);
                    if (cts.IsCancellationRequested)
                    {
                        timeout = true;//T3 Timeout
                        break;
                    }
                }
                //OFF CIM BIT
                converterParent.CIMMemOptions.memoryTable.WriteOneBit(cim_2_eq_reply_address, false);
                cts.Dispose();

            });
        }

        public bool Port_Disabled_Report { get; internal set; }
        public bool Port_Enabled_Report { get; internal set; }
        public int Port_Auto_Manual_Mode_Status { get; internal set; }
        private int _PortType = 0;
        public int PortType
        {
            get => _PortType;
            set
            {
                if (_PortType != value)
                {
                    _PortType = value;
                    if (_PortType == 0)
                        PortTypeInputReport();
                    if (_PortType == 1)
                        PortTypeOutputReport();
                    Properties.PortType = Enum.GetValues(typeof(GPM_SECS.SECSMessageHelper.PortUnitType)).Cast<GPM_SECS.SECSMessageHelper.PortUnitType>().First(etype => (int)etype == _PortType);
                }
            }
        }

        public ModbusTCPServer modbus_server { get; set; }


        public async void PortReport()
        {

        }

        public async void PortOutOfServiceReport()
        {
            var msg = new SecsMessage(6, 11)
            {
                SecsItem = Item.L(
                                Item.U4(0),//DATAID,
                                Item.U2((ushort)CEID.PortOutOfServiceReport), //CEID
                                Item.L(
                                    Item.L(
                                     Item.U2(12),//RPTID,
                                     Item.L(
                                         Item.A(Properties.PortID)
                                       )
                                     )
                                  )
                               )
            };
            var replyMsg = await DevicesManager.secs_host_for_mcs.SendAsync(msg);
            if (replyMsg == null)
            {
                AlarmManager.AddAlarm(ALARM_CODES.MCS_PORT_OUT_SERVICE_REPORT_FAIL, this.PortNameWithEQName);
            }
        }
        public async void PortInServiceReport()
        {
            _ = Task.Run(async () =>
            {
                var msg = new SecsMessage(6, 11)
                {
                    SecsItem = Item.L(
                                  Item.U4(0),//DATAID,
                                  Item.U2((ushort)CEID.PortInServiceReport), //CEID
                                  Item.L(
                                      Item.L(
                                       Item.U2(12),//RPTID,
                                       Item.L(
                                           Item.A(Properties.PortID)
                                         )
                                       )
                                    )
                                 )
                };
                var replyMsg = await DevicesManager.secs_host_for_mcs.SendAsync(msg);
                if (replyMsg == null)
                {

                    AlarmManager.AddAlarm(ALARM_CODES.MCS_PORT_IN_SERVICE_REPORT_FAIL, this.PortNameWithEQName);
                }
            });
        }
        public async void PortTypeInputReport()
        {
            _ = Task.Run(async () =>
            {
                var msg = new SecsMessage(6, 11)
                {
                    SecsItem = Item.L(
                              Item.U4(0),//DATAID,
                              Item.U2((ushort)CEID.PortTypeInputReport), //CEID
                              Item.L(
                                  Item.L(
                                   Item.U2(12),//RPTID,
                                   Item.L(
                                       Item.A(Properties.PortID)
                                     )
                                   )
                                )
                             )
                };
                var replyMsg = await DevicesManager.secs_host_for_mcs.SendAsync(msg);
            });
        }
        public async void PortTypeOutputReport()
        {
            _ = Task.Run(async () =>
            {
                var msg = new SecsMessage(6, 11)
                {
                    SecsItem = Item.L(
                              Item.U4(0),//DATAID,
                              Item.U2((ushort)CEID.PortTypeOutputReport), //CEID
                              Item.L(
                                  Item.L(
                                   Item.U2(12),//RPTID,
                                   Item.L(
                                       Item.A(Properties.PortID)
                                     )
                                   )
                                )
                             )
                };
                var replyMsg = await DevicesManager.secs_host_for_mcs.SendAsync(msg);
            });
        }
        private bool CarrierWaitIn_Reply = false;
        private bool CarrierWaitIn_Accept = false;
        public async Task<bool> WaitMCSAccpectCarrierIn(int T_timout = 20)
        {
            CarrierWaitIn_Reply = false;
            CarrierWaitIn_Accept = false;

            bool isEventReportAck = false;
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(T_timout));

            while (!isEventReportAck)
            {
                if (cancellationTokenSource.IsCancellationRequested)
                {
                    return false;
                }
                try
                {
                    var msc_reply = await DevicesManager.secs_host_for_mcs.SendAsync(EVENT_REPORT.CarrierWaitInReportMessage(WIPINFO_BCR_ID, "", ""));
                    if (msc_reply == null)
                    {
                        AlarmManager.AddAlarm(ALARM_CODES.CARRIER_WAIT_IN_BUT_MCS_DISCONNECT, PortNameWithEQName);
                        AlarmManager.AddAlarm(ALARM_CODES.MCS_CARRIER_WAITIN_REPORT_FAIL, PortNameWithEQName);
                        return false;
                    }
                    isEventReportAck = true;
                }
                catch (Exception ex)
                {

                }
                Thread.Sleep(1);
            }

            DevicesManager.secs_host_for_mcs.OnPrimaryMessageRecieve += Secs_client_OnPrimaryMessageRecieve;

            cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(T_timout));
            while (!CarrierWaitIn_Reply)
            {
                try
                {
                    await Task.Delay(1, cancellationTokenSource.Token);
                }
                catch (TaskCanceledException ex)
                {
                    //表示timeout
                    break;
                }
            }
            DevicesManager.secs_host_for_mcs.OnPrimaryMessageRecieve -= Secs_client_OnPrimaryMessageRecieve;
            return CarrierWaitIn_Accept && CarrierWaitIn_Reply;
        }
        public async Task CarrierRemovedCompletedReply()
        {
            var carrier_removed_com_reply_address = PortCIMBitAddress[PROPERTY.Carrier_Removed_Completed_Report_Reply];

            //上報MCS
            _ = Task.Factory.StartNew(async () =>
            {
                try
                {
                    var response = await DevicesManager.secs_host_for_mcs.SendAsync(EVENT_REPORT.CarrierRemovedCompletedReportMessage(WIPINFO_BCR_ID, "", ""));
                    if (response == null)
                        AlarmManager.AddWarning(ALARM_CODES.MCS_CARRIER_REMOVED_COMPLETED_REPORT_FAIL, PortNameWithEQName);
                }
                catch (Exception ex)
                {
                    AlarmManager.AddWarning(ALARM_CODES.MCS_CARRIER_REMOVED_COMPLETED_REPORT_FAIL, PortNameWithEQName);
                }

            });

            converterParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_removed_com_reply_address, true);
            CancellationTokenSource cst = new CancellationTokenSource(TimeSpan.FromSeconds(5000));
            while (CarrierRemovedCompletedReport)
            {
                if (cst.IsCancellationRequested)
                {
                    AlarmManager.AddWarning(ALARM_CODES.CarrierRemovedCompolete_HS_EQ_Timeout, PortNameWithEQName);
                    break;
                }
                await Task.Delay(1);
            }
            converterParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_removed_com_reply_address, false);
        }
        public async Task CarrierWaitOutReply()
        {

            var carrier_wait_out_reply_address = PortCIMBitAddress[PROPERTY.Carrier_WawitOut_System_Reply];
            converterParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_out_reply_address, true);
            CancellationTokenSource cst = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            while (CarrierWaitOUTSystemRequest)
            {
                if (cst.IsCancellationRequested)
                {
                    AlarmManager.AddWarning(ALARM_CODES.CarrierWaitOut_HS_EQ_Timeout, PortNameWithEQName);
                    break;
                }
                await Task.Delay(1);
            }
            converterParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_out_reply_address, false);

            try
            {
                var response = await DevicesManager.secs_host_for_mcs.SendAsync(EVENT_REPORT.CarrierWaitOutReportMessage(WIPINFO_BCR_ID, "", ""));
                if (response == null)
                    AlarmManager.AddWarning(ALARM_CODES.MCS_CARRIER_WAITOUT_REPORT_FAIL, PortNameWithEQName);
            }
            catch (Exception ex)
            {
                AlarmManager.AddWarning(ALARM_CODES.MCS_CARRIER_WAITOUT_REPORT_FAIL, PortNameWithEQName);
            }

        }
        public HandShakeResult CarrierWaitOutHSResult = new HandShakeResult();
        public async Task<bool> CarrierWaitInReply(int T_timeout = 5000)
        {
            //送訊息給SECS HOST 
            bool mcs_accpet = await WaitMCSAccpectCarrierIn();
            //寫結果
            CarrierWaitOutHSResult.Reset();
            bool timeout = false;
            PROPERTY wait_in_ = mcs_accpet ? PROPERTY.Carrier_WaitIn_System_Accept : PROPERTY.Carrier_WaitIn_System_Refuse;
            var carrier_wait_in_result_flag_address = PortCIMBitAddress[wait_in_];
            var carrier_wait_in_reply_address = PortCIMBitAddress[PROPERTY.Carrier_WaitIn_System_Reply];

            converterParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_result_flag_address, true);
            converterParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_reply_address, true);

            Stopwatch sw = Stopwatch.StartNew();
            while (CarrierWaitINSystemRequest)
            {
                if (sw.ElapsedMilliseconds > T_timeout)
                {
                    timeout = true;
                    break;
                }
                await Task.Delay(1);
            }

            converterParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_reply_address, false);
            converterParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_result_flag_address, false);

            return timeout;

        }
        private void Secs_client_OnPrimaryMessageRecieve(object? sender, PrimaryMessageWrapper messagePrimary)
        {
            Task.Factory.StartNew(() =>
            {
                var mcs_msg = messagePrimary.PrimaryMessage;
                bool IsRCMD = mcs_msg.TryGetRCMDAction_S2F49(out RCMD RCMD, out Item parameterGroups);
                if (IsRCMD && RCMD == SECSMessageHelper.RCMD.TRANSFER)
                {
                    CarrierWaitIn_Reply = true;
                    CarrierWaitIn_Accept = true;
                }
                if (IsRCMD && RCMD == SECSMessageHelper.RCMD.NOTRANSFER)
                {
                    CarrierWaitIn_Reply = true;
                    CarrierWaitIn_Accept = false;

                    AlarmManager.AddWarning(ALARM_CODES.CARRIER_WAIT_IN_BUT_MCS_REJECT, PortNameWithEQName);
                }
            });
        }

        public bool BuildModbusTCPServer(frmModbusTCPServer ui)
        {
            try
            {
                modbus_server = new ModbusTCPServer();
                modbus_server.CoilsOnChanged += Modbus_server_CoilsOnChanged;
                modbus_server.linkedCasstteConverter = converterParent;
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
                List<CasstteConverter.Data.clsMemoryAddress> CIMLinkAddress = converterParent.LinkBitMap.FindAll(ad => ad.EOwner == OWNER.CIM && ad.EScope.ToString() == portNoName && ad.Link_Modbus_Register_Number != -1);
                foreach (var item in CIMLinkAddress)
                {
                    int register_num = item.Link_Modbus_Register_Number;
                    var localCoilsAry = modbus_server.coils.localArray;
                    bool state = localCoilsAry[register_num + 1];
                    converterParent.CIMMemOptions.memoryTable.WriteOneBit(item.Address, state);
                }

            });
        }

        virtual public void SyncRegisterData()
        {
            Task.Run(async () =>
            {
                while (true)
                {

                    foreach (var item in EQModbusLinkBitAddress)
                    {
                        bool bolState = converterParent.EQPMemOptions.memoryTable.ReadOneBit(item.Address);
                        modbus_server.discreteInputs.localArray[item.Link_Modbus_Register_Number] = bolState;
                    }

                    foreach (var item in EQModbusLinkWordAddress)
                    {
                        int value = converterParent.EQPMemOptions.memoryTable.ReadBinary(item.Address);
                        modbus_server.holdingRegisters.localArray[item.Link_Modbus_Register_Number] = (short)value;
                    }


                    foreach (var item in CIMModbusLinkWordAddress)
                    {
                        int value = converterParent.CIMMemOptions.memoryTable.ReadBinary(item.Address);
                        modbus_server.holdingRegisters.localArray[item.Link_Modbus_Register_Number] = (short)value;
                    }

                    await Task.Delay(10);
                }

            });
        }

        internal async Task<bool> Mode_Change_RequestAsync(PortUnitType portUnitType)
        {
            return await ModeChangeRequestHandshake(portUnitType);
        }
    }
}
