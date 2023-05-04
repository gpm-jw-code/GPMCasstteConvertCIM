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
                ConverterType = CasstteConverter.Enums.CONVERTER_TYPE.IN_SYS,
                Ports = new Dictionary<int, CasstteConverter.clsConverterPort.clsPortProperty>()
                {
                    { 0 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 0,
                           PortID = "3F_AGVC02_PORT_1_1",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1501,
                              PortType = GPM_SECS.SECSMessageHelper.PortUnitType.Input_Output

                    }
                    }
                }
            },
            new ConverterEQPInitialOption
            {
                IpAddress = "192.168.0.106",
                Port = 5123,
                IsActive = true,
                DeviceId=1,
                ConverterType = CasstteConverter.Enums.CONVERTER_TYPE.SYS_2_SYS,
                 Ports = new Dictionary<int, CasstteConverter.clsConverterPort.clsPortProperty>()
                {
                    { 0 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 0,
                           PortID = "3F_AGVC02_PORT_2_1",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1502,
                              PortType = GPM_SECS.SECSMessageHelper.PortUnitType.Input

                    }},
                    { 1 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 1,
                           PortID = "3F_AGVC02_PORT_2_2",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1503,
                              PortType = GPM_SECS.SECSMessageHelper.PortUnitType.Output

                    }}
                }
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
