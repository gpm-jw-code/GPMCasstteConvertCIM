using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMWatchDogMonitor.CIM_Model
{
    public class ConnectionOptionsConfig
    {
        public List<Equipment> PLCEQS { get; set; }
        public SecsHost SECS_HOST { get; set; }
        public SecsClient SECS_CLIENT { get; set; }
        public List<ModbusServer> Modbus_Servers { get; set; }

    }
    public class Equipment
    {
        public string Eq_Name { get; set; }
        public string ConverterType { get; set; }
        public Dictionary<string, Port> Ports { get; set; }
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public int DeviceId { get; set; }
        public bool IsActive { get; set; }
        public string DeviceType { get; set; }
    }

    public class Port
    {
        public bool ModbusServer_Enable { get; set; }
        public bool AGVHandshakeModbusGatewayActive { get; set; }
        public int PortNo { get; set; }
        public string PortID { get; set; }
        public string ModbusServer_IP { get; set; }
        public int ModbusServer_PORT { get; set; }
        public int AGVHandshakeModbus_PORT { get; set; }
        public bool CarrierWaitInOutReport_Enable { get; set; }
        public bool LoadUnlloadStateSimulation { get; set; }
        public bool SecsReport { get; set; }
        public int TagNumberInAGVS { get; set; }
        public string PreviousOnPortID { get; set; }
        public bool IsInstalled { get; set; }
        public DateTime CarrierInstallTime { get; set; }
        public bool CarrierWaitInNeedWaitingS2F41OrS2F49 { get; set; }
        public bool AutoChangeToOUTPUTWhenAGVLoadedInOFFLineMode { get; set; }
        public bool RemoveCarrierMCSReportOnlyInOUTPUTMODE { get; set; }
        public bool NeverReportCarrierRemove { get; set; }
        public int WaitS2F49CmdTimeoutSec { get; set; }
        public bool CarrierWaitOutWhenAGVSRefuseMCSMission { get; set; }
    }

    public class SecsHost
    {
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public int DeviceId { get; set; }
        public bool IsActive { get; set; }
        public string DeviceType { get; set; }
    }

    public class SecsClient
    {
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public int DeviceId { get; set; }
        public bool IsActive { get; set; }
        public string DeviceType { get; set; }
    }

    public class ModbusServer
    {
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public int DeviceId { get; set; }
        public bool IsActive { get; set; }
        public string DeviceType { get; set; }
    }
}
