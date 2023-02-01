using GPMCasstteConvertCIM.GPM_SECS;
using GPMCasstteConvertCIM.UI_UserControls;
using Secs4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.CIM
{
    public class CIMDevices
    {
        public enum CIM_DEVICE_TYPES
        {
            SECS_HOST,
            SECS_CLIENT,
            CASSTTE_CONVERTER,
            MODBUS_TCP_Server
        }

        internal static SECSBase secs_host = new SECSBase();
        /// <summary>
        /// 與MCS連線的SECS CLIENT
        /// </summary>
        internal static SECSBase secs_client = new SECSBase();
        /// <summary>
        /// 轉換架1
        /// </summary>
        internal static CasstteConverter.clsCasstteConverter casstteConverter_1;
        /// <summary>
        /// 轉換架2
        /// </summary>
        internal static CasstteConverter.clsCasstteConverter casstteConverter_2;


        internal static GPM_Modbus.ModbusTCPServer modbus_server = new GPM_Modbus.ModbusTCPServer();

        internal static event EventHandler<ConnectionStateChangeArgs> DeviceConnectionStateOnChanged;

        internal static void Connect(InitialOptions secs_host_opt, InitialOptions secs_client_opt,
             InitialOptions casstteConverter1_opt, InitialOptions casstteConverter2_opt, InitialOptions modbusTcpServer_opt)
        {
            secs_host = new SECSBase();
            secs_client = new SECSBase();

            casstteConverter_1 = new CasstteConverter.clsCasstteConverter(0, (UscCasstteConverter)casstteConverter1_opt.mainUI)
            {
                simulation_mode = false
            };
            casstteConverter_2 = new CasstteConverter.clsCasstteConverter(1, (UscCasstteConverter)casstteConverter2_opt.mainUI);

            secs_host.ConnectionChanged += SECS_H_ConnectionChangeHandle;
            secs_client.ConnectionChanged += SECS_E_ConnectionChangeHandle;
            secs_host.OnPrimaryMessageRecieve += Secs_host_OnPrimaryMessageRecieve;
            secs_client.OnPrimaryMessageRecieve += MCSMessageHandler.MCSPrimaryMessageOnReceivedAsync;

            casstteConverter_1.ConnectionStateChanged += CasstteConverter_ConnectionStateChanged;

            //casstteConverter_2.ConnectionStateChanged += CasstteConverter_ConnectionStateChanged;

            secs_host.Active(secs_host_opt.ToSecsGenOptions(), secs_host_opt.logRichTextBox);
            secs_client.Active(secs_client_opt.ToSecsGenOptions(), secs_client_opt.logRichTextBox);

            casstteConverter_1.ActiveAsync(casstteConverter1_opt.ToMCIFOptions());
            //casstteConverter_2.ActiveAsync(casstteConverter2_opt.ToMCIFOptions());

            modbus_server.Active(modbusTcpServer_opt, casstteConverter_1);


        }


        private static void SECS_AGVS_SIM_ConnectionChangeHandle(ConnectionState obj)
        {

        }
        private static void SECS_MCS_SIM_ConnectionChangeHandle(ConnectionState obj)
        {

        }

        private static void Secs_host_OnPrimaryMessageRecieve(object? sender, PrimaryMessageWrapper _primaryMessageWrapper)
        {
        }

        private static void CasstteConverter_ConnectionStateChanged(object? sender, Common.CONNECTION_STATE connectionState)
        {
            Utility.SystemLogger.Log($"Converter Connecstion State Change:{connectionState}", connectionState != Common.CONNECTION_STATE.CONNECTED ? LoggerBase.LOG_LEVEL.WARNING : LoggerBase.LOG_LEVEL.INFO);
            DeviceConnectionStateOnChanged?.Invoke(sender, new ConnectionStateChangeArgs(sender, CIM_DEVICE_TYPES.CASSTTE_CONVERTER, connectionState));
            //uscConnectionStates1.Converter_ConnectionChange(e);
        }

        private static void SECS_E_ConnectionChangeHandle(Secs4Net.ConnectionState connectionState)
        {
            var _connectionState = connectionState.ToCommonConnectionState();
            Utility.SystemLogger.Log($"SECS_TO_MCS Connecstion State Change:{connectionState}", _connectionState != Common.CONNECTION_STATE.CONNECTED ? LoggerBase.LOG_LEVEL.WARNING : LoggerBase.LOG_LEVEL.INFO);
            DeviceConnectionStateOnChanged?.Invoke(secs_client, new ConnectionStateChangeArgs(secs_client, CIM_DEVICE_TYPES.SECS_CLIENT, _connectionState));
            //uscConnectionStates1.SECS_E_ConnectionChange(obj);
        }

        private static void SECS_H_ConnectionChangeHandle(Secs4Net.ConnectionState connectionState)
        {
            var _connectionState = connectionState.ToCommonConnectionState();
            Utility.SystemLogger.Log($"SECS_TO_AGVS Connection State Change:{connectionState}", _connectionState != Common.CONNECTION_STATE.CONNECTED ? LoggerBase.LOG_LEVEL.WARNING : LoggerBase.LOG_LEVEL.INFO);
            DeviceConnectionStateOnChanged?.Invoke(secs_host, new ConnectionStateChangeArgs(secs_host, CIM_DEVICE_TYPES.SECS_HOST, _connectionState));
            //uscConnectionStates1.SECS_H_ConnectionChange(e);
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

        public class InitialOptions
        {
            public InitialOptions()
            {

            }
            public InitialOptions(CIM_DEVICE_TYPES DeviceType)
            {
                this.DeviceType = DeviceType;
            }

            internal RichTextBox logRichTextBox;
            internal object mainUI;
            public string IpAddress { get; set; }
            public int Port { get; set; }
            public ushort DeviceId { get; set; }
            public bool IsActive { get; set; }

            public CIM_DEVICE_TYPES DeviceType { get; set; }
        }
    }
}
