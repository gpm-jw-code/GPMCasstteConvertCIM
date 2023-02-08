using GPMCasstteConvertCIM.CIM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.Utilities
{
    public class DeviceConnectionOptions
    {
        public CIMDevices.InitialOptions PLCEQ1 { get; set; } = new CIMDevices.InitialOptions()
        {
            IpAddress = "192.168.1.133",
            Port = 5123,
            IsActive = true,
        };

        public CIMDevices.InitialOptions PLCEQ2 { get; set; } = new CIMDevices.InitialOptions()
        {
            IpAddress = "192.168.0.106",
            Port = 12345,
            IsActive = true,
        };

        public CIMDevices.SecsGemInitialOptions SECS_HOST { get; set; } = new CIMDevices.SecsGemInitialOptions()
        {
            DeviceId = 0,
            IpAddress = "127.0.0.1",
            Port = 5000,
            IsActive = false,
        };

        public CIMDevices.SecsGemInitialOptions SECS_CLIENT { get; set; } = new CIMDevices.SecsGemInitialOptions()
        {
            DeviceId = 1,
            IpAddress = "127.0.0.1",
            Port = 5001,
            IsActive = true,
        };

        public CIMDevices.InitialOptions Modbus_Server { get; set; } = new CIMDevices.InitialOptions()
        {
            IpAddress = "127.0.0.1",
            Port = 502,
            IsActive = false,
        };

    }
}
