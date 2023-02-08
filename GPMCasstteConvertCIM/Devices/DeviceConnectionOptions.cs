using GPMCasstteConvertCIM.Devices.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.Devices.DevicesManager;

namespace GPMCasstteConvertCIM.Devices
{
    public class DeviceConnectionOptions
    {
        public ConverterEQPInitialOption[] PLCEQS { get; set; } = new ConverterEQPInitialOption[]
        {
            new ConverterEQPInitialOption
            {
                IpAddress = "192.168.1.133",
                Port = 5123,
                IsActive = true,
                 DeviceId=0,
                  ConverterType = CasstteConverter.Enums.CONVERTER_TYPE.IN_SYS
            },
            new ConverterEQPInitialOption
            {
                IpAddress = "192.168.0.106",
                Port = 5123,
                IsActive = true,
                 DeviceId=1,
                  ConverterType = CasstteConverter.Enums.CONVERTER_TYPE.SYS_2_SYS
            },
        };


        public SecsGemInitialOption SECS_HOST { get; set; } = new SecsGemInitialOption()
        {
            DeviceId = 0,
            IpAddress = "127.0.0.1",
            Port = 5000,
            IsActive = false,
            DeviceType = CIM_DEVICE_TYPES.SECS_HOST
        };

        public SecsGemInitialOption SECS_CLIENT { get; set; } = new SecsGemInitialOption()
        {
            DeviceId = 1,
            IpAddress = "127.0.0.1",
            Port = 5001,
            IsActive = true,
            DeviceType = CIM_DEVICE_TYPES.SECS_CLIENT
        };

        public InitialOption[] Modbus_Servers { get; set; } = new InitialOption[]
        {
            new InitialOption()
            {
                IpAddress = "127.0.0.1",
                Port = 502,
                IsActive = false,
                DeviceType = CIM_DEVICE_TYPES.MODBUS_TCP_Server,
                 DeviceId=0,
            },
            new InitialOption()
            {
                IpAddress = "127.0.0.1",
                Port = 1502,
                IsActive = false,
                DeviceType = CIM_DEVICE_TYPES.MODBUS_TCP_Server,
                DeviceId=1
            },
        };

    }
}
