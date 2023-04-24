using GPMCasstteConvertCIM.CasstteConverter;
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
        internal static List<CasstteConverter.clsCasstteConverter> casstteConverters = new List<CasstteConverter.clsCasstteConverter>();


        internal static List<GPM_Modbus.ModbusTCPServer> modbus_servers = new List<GPM_Modbus.ModbusTCPServer>();

        internal static event EventHandler<ConnectionStateChangeArgs> DeviceConnectionStateOnChanged;


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

            ////Secs host(CIM_AGVS)
            ///
            secs_host_for_mcs = new SECSBase("Host_For_MCS");
            secs_host_for_mcs.ConnectionChanged += SECS_E_ConnectionChangeHandle;
            secs_host_for_mcs.OnPrimaryMessageRecieve += MCSMessageHandler.PrimaryMessageOnReceivedAsync; ;
            secs_host_for_mcs.Active(DevicesConnectionsOpts.SECS_HOST.ToSecsGenOptions(), DevicesConnectionsOpts.SECS_HOST.logRichTextBox, DevicesConnectionsOpts.SECS_HOST.dgvSendBufferTable, DevicesConnectionsOpts.SECS_HOST.dgvRevBufferTable);

            ////Secs client(CIM_MCS)
            secs_client_for_agvs = new SECSBase("Client_For_AGVS");
            secs_client_for_agvs.ConnectionChanged += SECS_H_ConnectionChangeHandle;
            secs_client_for_agvs.OnPrimaryMessageRecieve += AGVSMessageHandler.PrimaryMessageOnReceivedAsync;
            secs_client_for_agvs.Active(DevicesConnectionsOpts.SECS_CLIENT.ToSecsGenOptions(), DevicesConnectionsOpts.SECS_CLIENT.logRichTextBox, DevicesConnectionsOpts.SECS_CLIENT.dgvSendBufferTable, DevicesConnectionsOpts.SECS_CLIENT.dgvRevBufferTable);

            ////轉換架1
            ///
            foreach (Options.ConverterEQPInitialOption item in DevicesConnectionsOpts.PLCEQS)
            {
                try
                {
                    var EQ = new CasstteConverter.clsCasstteConverter(item.DeviceId, item.Name, (UscCasstteConverter)item.mainUI, item.ConverterType, item.Ports);
                    EQ.ConnectionStateChanged += CasstteConverter_ConnectionStateChanged;
                    EQ.ActiveAsync(item.ToMCIFOptions());
                    casstteConverters.Add(EQ);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


            //foreach (var item in DevicesConnectionsOpts.Modbus_Servers)
            //{
            //    var modbus_server = new GPM_Modbus.ModbusTCPServer();
            //    modbus_server.Active(item, casstteConverters.First(cc => cc.index == item.DeviceId));
            //    modbus_servers.Add(modbus_server);
            //}
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
                string deviceConnectionCofigsFile = Path.Combine(Utility.configsFolder, "DevicesConnections.json");
                if (File.Exists(deviceConnectionCofigsFile))
                {
                    DevicesConnectionsOpts = JsonConvert.DeserializeObject<DeviceConnectionOptions>(File.ReadAllText(deviceConnectionCofigsFile));
                }
                File.WriteAllText(deviceConnectionCofigsFile, JsonConvert.SerializeObject(DevicesConnectionsOpts, Formatting.Indented));

                //check
                eqplc_config_error = DevicesConnectionsOpts.PLCEQS.Any(eqp => (eqp.ConverterType == Enums.CONVERTER_TYPE.IN_SYS && eqp.Ports.Count != 1) | (eqp.ConverterType == Enums.CONVERTER_TYPE.SYS_2_SYS && eqp.Ports.Count != 2));
                if (eqplc_config_error)
                {
                    errorMsg = "轉換架類型與Port數量不匹配";
                }
            }
            catch (Exception ex)
            {
                config_error = true;
                errorMsg = ex.Message;
            }

        }

        internal static List<clsConverterPort> GetAllPorts()
        {
            return casstteConverters.SelectMany(cst => cst.EQPData.PortDatas).ToList();
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
