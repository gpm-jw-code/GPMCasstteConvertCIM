using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.Cclink_IE_Sturcture;
using GPMCasstteConvertCIM.Forms;
using GPMCasstteConvertCIM.GPM_SECS;
using GPMCasstteConvertCIM.GPM_SECS.SecsMessageHandle;
using GPMCasstteConvertCIM.UI_UserControls;
using GPMCasstteConvertCIM.Utilities;
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

        private static string DeviceConnectionConfigName => Utility.SysConfigs.Project == Utilities.SysConfigs.clsSystemConfigs.PROJECT.U003 ? "DevicesConnections.json" : "DevicesConnections-U007.json";

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
                ///
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

                ////Secs client(CIM_MCS)
                secs_client_for_agvs = new SECSBase("AGVS");
                secs_client_for_agvs.ConnectionChanged += SECS_H_ConnectionChangeHandle;
                secs_client_for_agvs.OnPrimaryMessageRecieve += AGVSMessageHandler.PrimaryMessageOnReceivedAsync;
                secs_client_for_agvs.Active(DevicesConnectionsOpts.SECS_CLIENT.ToSecsGenOptions(), DevicesConnectionsOpts.SECS_CLIENT.logRichTextBox, DevicesConnectionsOpts.SECS_CLIENT.dgvSendBufferTable, DevicesConnectionsOpts.SECS_CLIENT.dgvRevBufferTable);
            }
            catch (Exception ex)
            {

            }

            if (Utility.SysConfigs.Project == Utilities.SysConfigs.clsSystemConfigs.PROJECT.U007)
            {
                cclink_master = new clsCCLinkIE_Master("CCLINK_MASTER", EqStatusUI);
                cclink_master.ActiveAsync(new McInterfaceOptions { });

                foreach (Options.ConverterEQPInitialOption item in DevicesConnectionsOpts.PLCEQS)
                {
                    try
                    {
                        clsCCLinkIE_Station EQ = new clsCCLinkIE_Station(item.Eq_Name, item.Ports, cclink_master);
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

                foreach (Options.ConverterEQPInitialOption item in DevicesConnectionsOpts.PLCEQS)
                {
                    try
                    {
                        var EQ = new clsCasstteConverter(item.DeviceId, item.Name, (UscCasstteConverter)item.mainUI, item.ConverterType, item.Ports);
                        EQ.ConnectionStateChanged += CasstteConverter_ConnectionStateChanged;
                        EQ.ActiveAsync(item.ToMCIFOptions());
                        casstteConverters.Add(EQ);
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
            string deviceConnectionCofigsFile = Path.Combine(Utility.configsFolder, "DevicesConnections.json");
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
                        if (port.PortStatusDown)
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
