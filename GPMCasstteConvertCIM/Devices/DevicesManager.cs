using GPMCasstteConvertCIM.CIM;
using GPMCasstteConvertCIM.CIM.SecsMessageHandle;
using GPMCasstteConvertCIM.Forms;
using GPMCasstteConvertCIM.GPM_SECS;
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

        internal static SECSBase secs_host;
        /// <summary>
        /// 與MCS連線的SECS CLIENT
        /// </summary>
        internal static SECSBase secs_client;
        /// <summary>
        /// 轉換架1
        /// </summary>
        internal static List<CasstteConverter.clsCasstteConverter> casstteConverters = new List<CasstteConverter.clsCasstteConverter>();


        internal static List<GPM_Modbus.ModbusTCPServer> modbus_servers = new List<GPM_Modbus.ModbusTCPServer>();

        internal static event EventHandler<ConnectionStateChangeArgs> DeviceConnectionStateOnChanged;


        internal static void Connect()
        {
            ////Secs host(CIM_AGVS)
            secs_host = new SECSBase("Host_For_AGVS");
            secs_host.ConnectionChanged += SECS_H_ConnectionChangeHandle;
            secs_host.OnPrimaryMessageRecieve += AGVSMessageHandler.PrimaryMessageOnReceivedAsync;
            secs_host.Active(DevicesConnectionsOpts.SECS_HOST.ToSecsGenOptions(), DevicesConnectionsOpts.SECS_HOST.logRichTextBox, DevicesConnectionsOpts.SECS_HOST.dgvSendBufferTable, DevicesConnectionsOpts.SECS_HOST.dgvRevBufferTable);

            ////Secs client(CIM_MCS)
            secs_client = new SECSBase("Client_For_MCS");
            secs_client.ConnectionChanged += SECS_E_ConnectionChangeHandle;
            secs_client.OnPrimaryMessageRecieve += MCSMessageHandler.PrimaryMessageOnReceivedAsync;
            secs_client.Active(DevicesConnectionsOpts.SECS_CLIENT.ToSecsGenOptions(), DevicesConnectionsOpts.SECS_CLIENT.logRichTextBox, DevicesConnectionsOpts.SECS_CLIENT.dgvSendBufferTable, DevicesConnectionsOpts.SECS_CLIENT.dgvRevBufferTable);

            ////轉換架1
            ///
            foreach (var item in DevicesConnectionsOpts.PLCEQS)
            {
                var EQ = new CasstteConverter.clsCasstteConverter(item.DeviceId, (UscCasstteConverter)item.mainUI, item.ConverterType);
                EQ.ConnectionStateChanged += CasstteConverter_ConnectionStateChanged;
                EQ.ActiveAsync(item.ToMCIFOptions());
                EQ.modbusServerGUI = (frmModbusTCPServer)DevicesConnectionsOpts.Modbus_Servers.First(mobus_op => mobus_op.DeviceId == item.DeviceId).mainUI;
                casstteConverters.Add(EQ);
            }


            foreach (var item in DevicesConnectionsOpts.Modbus_Servers)
            {
                var modbus_server = new GPM_Modbus.ModbusTCPServer();
                modbus_server.Active(item, casstteConverters.First(cc => cc.index == item.DeviceId));
                modbus_servers.Add(modbus_server);
            }
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
            DeviceConnectionStateOnChanged?.Invoke(secs_client, new ConnectionStateChangeArgs(secs_client, CIM_DEVICE_TYPES.SECS_CLIENT, _connectionState));
            //uscConnectionStates1.SECS_E_ConnectionChange(obj);
        }

        private static void SECS_H_ConnectionChangeHandle(ConnectionState connectionState)
        {
            var _connectionState = connectionState.ToCommonConnectionState();
            Utility.SystemLogger.Log($"SECS_TO_AGVS Connection State Change:{connectionState}", _connectionState != Common.CONNECTION_STATE.CONNECTED ? LoggerBase.LOG_LEVEL.WARNING : LoggerBase.LOG_LEVEL.INFO);
            DeviceConnectionStateOnChanged?.Invoke(secs_host, new ConnectionStateChangeArgs(secs_host, CIM_DEVICE_TYPES.SECS_HOST, _connectionState));
            //uscConnectionStates1.SECS_H_ConnectionChange(e);
        }

        public static void LoadDeviceConnectionOpts()
        {
            Directory.CreateDirectory(Utility.configsFolder);

            string deviceConnectionCofigsFile = Path.Combine(Utility.configsFolder, "DevicesConnections.json");
            if (File.Exists(deviceConnectionCofigsFile))
            {
                DevicesConnectionsOpts = JsonConvert.DeserializeObject<DeviceConnectionOptions>(File.ReadAllText(deviceConnectionCofigsFile));
            }
            File.WriteAllText(deviceConnectionCofigsFile, JsonConvert.SerializeObject(DevicesConnectionsOpts, Formatting.Indented));
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
