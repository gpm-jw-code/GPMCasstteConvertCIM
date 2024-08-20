using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.Cclink_IE_Sturcture;
using GPMCasstteConvertCIM.Forms;
using GPMCasstteConvertCIM.GPM_SECS;
using GPMCasstteConvertCIM.GPM_SECS.SecsMessageHandle;
using GPMCasstteConvertCIM.UI_UserControls;
using GPMCasstteConvertCIM.Utilities;
using GPMCasstteConvertCIM.WebServer;
using GPMCasstteConvertCIM.WebServer.Models;
using Newtonsoft.Json;
using Secs4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.Devices
{
    public partial class DevicesManager
    {
        public enum CIM_DEVICE_TYPES
        {
            SECS_HOST,
            SECS_CLIENT,
            CASSTTE_CONVERTER,
            MODBUS_TCP_Server
        }

        internal static DeviceConnectionOptions DevicesConnectionsOpts = new DeviceConnectionOptions();

        /// <summary>
        /// 與MCS連線的SECS HOST
        /// </summary>
        internal static SECSBase secs_host_for_mcs;
        /// <summary>
        /// 與AGVSS連線的SECS CLIENT
        /// </summary>
        internal static SECSBase secs_client_for_agvs;

        internal static SECSBase secs_for_mcs_test = new SECSBase("mcs_test");

        /// <summary>
        /// 轉換架1
        /// </summary>
        internal static List<clsCasstteConverter> casstteConverters = new List<CasstteConverter.clsCasstteConverter>();


        internal static List<GPM_Modbus.ModbusTCPServer> modbus_servers = new List<GPM_Modbus.ModbusTCPServer>();

        internal static event EventHandler<ConnectionStateChangeArgs> DeviceConnectionStateOnChanged;

        public static clsCCLinkIE_Master cclink_master;

        public static UscEQStatus EqStatusUI { get; internal set; }
        private static LoggerBase SysLog => Utility.SystemLogger;

        private static string DeviceConnectionConfigName
        {
            get
            {
                switch (Utility.SysConfigs.Project)
                {
                    case Utilities.SysConfigs.clsSystemConfigs.PROJECT.U003:
                        return "DevicesConnections.json";
                    case Utilities.SysConfigs.clsSystemConfigs.PROJECT.U007:
                        return "DevicesConnections-U007.json";
                    case Utilities.SysConfigs.clsSystemConfigs.PROJECT.YM_2F_AOI:
                        return "DevicesConnections-YM_2F_AOI.json";
                    default:
                        return "DevicesConnections.json";
                }
            }
        }

        internal static void Connect()
        {

            secs_for_mcs_test.OnPrimaryMessageRecieve += MCSMessageHandler.PrimaryMessageOnReceivedAsync;
            secs_for_mcs_test.ConnectionChanged += new Action<ConnectionState>((state) => { });
            secs_for_mcs_test.Active(new SecsGemOptions()
            {
                DeviceId = 1,
                Port = 9000,
                IsActive = false,
                IpAddress = "127.0.0.1",

            });

            try
            {
                ////Secs host(CIM_AGVS)
                secs_host_for_mcs = new SECSBase("MCS");
                secs_host_for_mcs.ConnectionChanged += SECS_E_ConnectionChangeHandle;
                secs_host_for_mcs.OnPrimaryMessageRecieve += MCSMessageHandler.PrimaryMessageOnReceivedAsync; ;
                secs_host_for_mcs.Active(DevicesConnectionsOpts.SECS_HOST.ToSecsGenOptions(), DevicesConnectionsOpts.SECS_HOST.logRichTextBox, DevicesConnectionsOpts.SECS_HOST.dgvSendBufferTable, DevicesConnectionsOpts.SECS_HOST.dgvRevBufferTable);
            }
            catch (Exception ex)
            {

            }
            try
            {
                AGVSMessageHandler.DefineSecsMsgWatchDog(Utility.SysConfigs.AGVSSecsWatchDog);
                ////Secs client(CIM_MCS)
                secs_client_for_agvs = new SECSBase("AGVS");
                secs_client_for_agvs.ConnectionChanged += SECS_H_ConnectionChangeHandle;
                secs_client_for_agvs.OnPrimaryMessageRecieve += AGVSMessageHandler.PrimaryMessageOnReceivedAsync;
                secs_client_for_agvs.Active(DevicesConnectionsOpts.SECS_CLIENT.ToSecsGenOptions(), DevicesConnectionsOpts.SECS_CLIENT.logRichTextBox, DevicesConnectionsOpts.SECS_CLIENT.dgvSendBufferTable, DevicesConnectionsOpts.SECS_CLIENT.dgvRevBufferTable);
            }
            catch (Exception ex)
            {

            }

            if (Utility.SysConfigs.Project == Utilities.SysConfigs.clsSystemConfigs.PROJECT.U007 ||
                Utility.SysConfigs.Project == Utilities.SysConfigs.clsSystemConfigs.PROJECT.YM_2F_AOI)
            {

                if (Utility.SysConfigs.Project == Utilities.SysConfigs.clsSystemConfigs.PROJECT.U007)
                    cclink_master = new clsCCLinkIE_Master("CCLINK_MASTER", EqStatusUI);
                else if (Utility.SysConfigs.Project == Utilities.SysConfigs.clsSystemConfigs.PROJECT.YM_2F_AOI)
                {
                    cclink_master = new clsCCLinkID_Master_YM2FAOI("CCLINK_MASTER", EqStatusUI);
                }

                cclink_master.ActiveAsync(new McInterfaceOptions { });

                foreach (Options.ConverterEQPInitialOption item in DevicesConnectionsOpts.PLCEQS)
                {
                    try
                    {
                        clsCCLinkIE_Station EQ = new clsCCLinkIE_Station(item.Eq_Name, item.Ports, cclink_master, item.Name);
                        //clsCasstteConverter EQ = new CasstteConverter.clsCasstteConverter(item.Name, (UscCasstteConverter)item.mainUI, item.ConverterType, item.Ports);
                        EQ.ConnectionStateChanged += CasstteConverter_ConnectionStateChanged;
                        EQ.ActiveAsync(item.ToMCIFOptions());
                        casstteConverters.Add(EQ);
                        cclink_master.Stations.Add(EQ);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                cclink_master.mainGUI.BindData(cclink_master.AllEqPortList);
            }
            else
            {
                foreach (Options.ConverterEQPInitialOption option in DevicesConnectionsOpts.PLCEQS)
                {
                    try
                    {
                        var EQ = new clsCasstteConverter(option);
                        EQ.ConnectionStateChanged += CasstteConverter_ConnectionStateChanged;
                        EQ.ActiveAsync(option.ToMCIFOptions());
                        casstteConverters.Add(EQ);
                        Task.Factory.StartNew(() =>
                        {
                            Utility.SystemLogger.Warning($"Wait EQ-{EQ.Name} PLC Data Updated and Port Install Status Will initialize");
                            while (!EQ.IsPLCDataUpdated)
                            {
                                Thread.Sleep(1);
                            }
                            EQ.InitPortStatus();
                        });

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

        }
        public static void SaveDeviceConnectionOpts()
        {
            string deviceConnectionCofigsFile = Path.Combine(Utility.configsFolder, DeviceConnectionConfigName);
            File.WriteAllText(deviceConnectionCofigsFile, JsonConvert.SerializeObject(DevicesConnectionsOpts, Formatting.Indented));
        }
        private static void CasstteConverter_ConnectionStateChanged(object? sender, Common.CONNECTION_STATE connectionState)
        {
            //Utility.SystemLogger.Log($"Converter Connecstion State Change:{connectionState}", connectionState != Common.CONNECTION_STATE.CONNECTED ? LoggerBase.LOG_LEVEL.WARNING : LoggerBase.LOG_LEVEL.INFO);
            DeviceConnectionStateOnChanged?.Invoke(sender, new ConnectionStateChangeArgs(sender, CIM_DEVICE_TYPES.CASSTTE_CONVERTER, connectionState));
            //uscConnectionStates1.Converter_ConnectionChange(e);
        }

        private static void SECS_E_ConnectionChangeHandle(ConnectionState connectionState)
        {
            var _connectionState = connectionState.ToCommonConnectionState();
            Utility.SystemLogger.Log($"SECS_TO_MCS Connecstion State Change:{connectionState}", _connectionState != Common.CONNECTION_STATE.CONNECTED ? LoggerBase.LOG_LEVEL.WARNING : LoggerBase.LOG_LEVEL.INFO);
            DeviceConnectionStateOnChanged?.Invoke(secs_client_for_agvs, new ConnectionStateChangeArgs(secs_client_for_agvs, CIM_DEVICE_TYPES.SECS_CLIENT, _connectionState));

            if (connectionState == ConnectionState.Selected)
            {
                //
                Task.Run(async () =>
                {
                    await Task.Delay(1000);
                    SysLog.Info($"Start Report Port States To MCS When Connected!");
                    foreach (clsConverterPort port in GetAllPorts())
                    {
                        if (port.Port_Enabled_Report)
                            port.SecsEventReport(CEID.PortInServiceReport);
                        else
                            port.SecsEventReport(CEID.PortOutOfServiceReport);

                        if (port.PortType == 0)
                            port.SecsEventReport(CEID.PortTypeInputReport);
                        else if (port.PortType == 1)
                            port.SecsEventReport(CEID.PortTypeOutputReport);
                    }
                    SysLog.Info($"Report Port States To MCS Done");

                });
            }
            //uscConnectionStates1.SECS_E_ConnectionChange(obj);
        }

        private static void SECS_H_ConnectionChangeHandle(ConnectionState connectionState)
        {
            var _connectionState = connectionState.ToCommonConnectionState();
            Utility.SystemLogger.Log($"SECS_TO_AGVS Connection State Change:{connectionState}", _connectionState != Common.CONNECTION_STATE.CONNECTED ? LoggerBase.LOG_LEVEL.WARNING : LoggerBase.LOG_LEVEL.INFO);
            DeviceConnectionStateOnChanged?.Invoke(secs_host_for_mcs, new ConnectionStateChangeArgs(secs_host_for_mcs, CIM_DEVICE_TYPES.SECS_HOST, _connectionState));
            //uscConnectionStates1.SECS_H_ConnectionChange(e);
        }

        public static void LoadDeviceConnectionOpts(out bool config_error, out bool eqplc_config_error, out string errorMsg)
        {
            errorMsg = "";
            config_error = eqplc_config_error = false;

            Directory.CreateDirectory(Utility.configsFolder);
            try
            {
                string deviceConnectionCofigsFile = Path.Combine(Utility.configsFolder, DeviceConnectionConfigName);
                if (File.Exists(deviceConnectionCofigsFile))
                {
                    DevicesConnectionsOpts = JsonConvert.DeserializeObject<DeviceConnectionOptions>(File.ReadAllText(deviceConnectionCofigsFile));
                }
                File.WriteAllText(deviceConnectionCofigsFile, JsonConvert.SerializeObject(DevicesConnectionsOpts, Formatting.Indented));

            }
            catch (Exception ex)
            {
                config_error = true;
                errorMsg = ex.Message;
            }

        }

        internal static List<clsConverterPort> GetAllPorts()
        {
            return casstteConverters.SelectMany(cst => cst.PortDatas).ToList();
        }
        internal static clsConverterPort GetPortByPortID(string port_id)
        {
            return GetAllPorts().FirstOrDefault(port => port.Properties.PortID == port_id);
        }
        internal static bool TryModifyEQName(clsCasstteConverter casstteConverter, string newName, out string error_message)
        {
            error_message = "";
            try
            {
                var eq_options = DevicesConnectionsOpts.PLCEQS.FirstOrDefault(opt => opt == casstteConverter.Options);
                if (eq_options != null)
                {
                    eq_options.Name = newName;
                    SaveDeviceConnectionOpts();
                    return true;
                }
                else
                {
                    error_message = "找不到符合的設備參數";
                    return false;
                }
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
                return false;
            }
        }
        internal static void SetPortsIOSignalSource(Enums.IO_MODE iO_MODE)
        {
            foreach (var port in GetAllPorts())
            {
                port.IOSignalMode = iO_MODE;
            }
        }
        internal static clsResponse EqIOModeChangeHandle(string eqName, Enums.IO_MODE mode)
        {
            var port = GetAllPorts().FirstOrDefault(port => port.PortName == eqName);

            if (port == null)
                return new clsResponse(5, $"{eqName} is not exist");

            port.IOSignalMode = mode;

            return new clsResponse(0);
        }
        internal static clsResponse PortLDULDStatusChangeHandle(List<clsEQLDULDSimulationControl> control)
        {
            if (!Utility.IsHotRunMode)
                return new clsResponse(41, "Only Support in Hot Run Mode");

            foreach (var item in control)
            {
                var port = GetAllPorts().FirstOrDefault(p => p.Properties.TagNumberInAGVS == item.TagNumber);
                if (port != null)
                {
                    port.IOSignalMode = Enums.IO_MODE.FromCIMSimulation;
                    port.LDULD_Status_Simulation = item.Status;
                }
                else
                {
                    return new clsResponse(444, $"No Port's tag number equal {item.TagNumber}");
                }
            }

            return new clsResponse(0);
        }

        internal static clsResponse PortTypeChangeHandler(int tagID, int portType)
        {

            int matchTagCnt = GetAllPorts().Count(port => port.Properties.TagNumberInAGVS == tagID);
            if (matchTagCnt > 1)
            {
                var portNames = GetAllPorts().Where(p => p.Properties.TagNumberInAGVS == tagID).Select(p => p.PortName);
                return new clsResponse(500, $"CIM系統中有多的設備Port Tag設定都為[{tagID}],請確認CIM設備配置({string.Join(",", portNames)})");
            }
            int matchTag2Cnt = GetAllPorts().Count(port => port.Properties.TagNumberInAGVS_Secondary == tagID);
            if (matchTag2Cnt > 1)
            {
                var portNames = GetAllPorts().Where(p => p.Properties.TagNumberInAGVS_Secondary == tagID).Select(p => p.PortName);
                return new clsResponse(500, $"CIM系統中有多的設備Port Tag設定都為[{tagID}],請確認CIM設備配置({string.Join(",", portNames)})");
            }

            clsConverterPort? port = GetAllPorts().FirstOrDefault(port => port.Properties.TagNumberInAGVS == tagID || port.Properties.TagNumberInAGVS_Secondary == tagID);
            if (port == null)
                return new clsResponse(404, $"找不到Tag設定為[{tagID}]的設備Port");
            PortUnitType punitype = PortUnitType.Input;
            if (portType == 0)
                punitype = PortUnitType.Input;
            else if (portType == 1)
                punitype = PortUnitType.Output;
            else
            {
                return new clsResponse(401, "Port Type 僅允許 [0]或[1] 設定");
            }
            bool result = port.ModeChangeRequestHandshake(punitype, requester_name: "AGVS", no_change_if_current_type_is_req: false)
                               .GetAwaiter().GetResult();
            if (result)
                return new clsResponse(200);
            else
                return new clsResponse(500, $"{port.PortName} Port Type Change Fail.");
        }
        internal class ConnectionStateChangeArgs : EventArgs
        {
            internal ConnectionStateChangeArgs(object sender, CIM_DEVICE_TYPES device_type, Common.CONNECTION_STATE connection_state)
            {
                Sender = sender;
                Device_Type = device_type;
                Connection_State = connection_state;
            }

            public object Sender { get; }
            public CIM_DEVICE_TYPES Device_Type { get; }
            public Common.CONNECTION_STATE Connection_State { get; }
        }
    }
}
