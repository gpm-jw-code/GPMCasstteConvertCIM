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
                IsActive = true,
                Name = "STK",
                Eq_Name = CasstteConverter.Enums.EQ_NAMES.STK,
                ConverterType = CasstteConverter.Enums.CONVERTER_TYPE.SYS_2_SYS,
                Ports = new Dictionary<int, CasstteConverter.clsConverterPort.clsPortProperty>()
                {
                    { 0 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 0,
                           PortID = "STK_LoadPort",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1501,
                        }
                    },
                    { 1 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 1,
                           PortID = "STK_UnloadPort",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1502,

                        }
                    }
                }
            },
            new ConverterEQPInitialOption
            {
                IsActive = true,
                Name = "QV",
                Eq_Name = CasstteConverter.Enums.EQ_NAMES.QV,
                ConverterType = CasstteConverter.Enums.CONVERTER_TYPE.SYS_2_SYS,
                Ports = new Dictionary<int, CasstteConverter.clsConverterPort.clsPortProperty>()
                {
                    { 0 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 0,
                           PortID = "QV_LoadPort",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1503,
                        }
                    },
                    { 1 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 1,
                           PortID = "QV_UnloadPort",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1504,

                        }
                    }
                }
            },
            new ConverterEQPInitialOption
            {
                IsActive = true,
                Name = "AOI_1",
                Eq_Name = CasstteConverter.Enums.EQ_NAMES.AOI_1,
                ConverterType = CasstteConverter.Enums.CONVERTER_TYPE.SYS_2_SYS,
                Ports = new Dictionary<int, CasstteConverter.clsConverterPort.clsPortProperty>()
                {
                    { 0 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 0,
                           PortID = "AOI_1_LoadPort",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1505,
                        }
                    },
                    { 1 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 1,
                           PortID = "AOI_1_UnloadPort",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1506,

                        }
                    }
                }
            },
            new ConverterEQPInitialOption
            {
                IsActive = true,
                Name = "AOI_2",
                Eq_Name = CasstteConverter.Enums.EQ_NAMES.AOI_2,
                ConverterType = CasstteConverter.Enums.CONVERTER_TYPE.SYS_2_SYS,
                Ports = new Dictionary<int, CasstteConverter.clsConverterPort.clsPortProperty>()
                {
                    { 0 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 0,
                           PortID = "AOI_2_LoadPort",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1507,
                        }
                    },
                    { 1 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 1,
                           PortID = "AOI_2_UnloadPort",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1508,

                        }
                    }
                }
            },
            new ConverterEQPInitialOption
            {
                IsActive = true,
                Name = "AOI_3",
                Eq_Name = CasstteConverter.Enums.EQ_NAMES.AOI_3,
                ConverterType = CasstteConverter.Enums.CONVERTER_TYPE.SYS_2_SYS,
                Ports = new Dictionary<int, CasstteConverter.clsConverterPort.clsPortProperty>()
                {
                    { 0 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 0,
                           PortID = "AOI_3_LoadPort",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1509,
                        }
                    },
                    { 1 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 1,
                           PortID = "AOI_3_UnloadPort",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1510,

                        }
                    }
                }
            },
            new ConverterEQPInitialOption
            {
                IsActive = true,
                Name = "AOI_4",
                Eq_Name = CasstteConverter.Enums.EQ_NAMES.AOI_4,
                ConverterType = CasstteConverter.Enums.CONVERTER_TYPE.SYS_2_SYS,
                Ports = new Dictionary<int, CasstteConverter.clsConverterPort.clsPortProperty>()
                {
                    { 0 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 0,
                           PortID = "AOI_4_LoadPort",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1511,
                        }
                    },
                    { 1 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 1,
                           PortID = "AOI_4_UnloadPort",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1512,

                        }
                    }
                }
            },

            new ConverterEQPInitialOption
            {
                IsActive = true,
                Name = "AOS_1",
                Eq_Name = CasstteConverter.Enums.EQ_NAMES.AOS_1,
                ConverterType = CasstteConverter.Enums.CONVERTER_TYPE.SYS_2_SYS,
                Ports = new Dictionary<int, CasstteConverter.clsConverterPort.clsPortProperty>()
                {
                    { 0 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 0,
                           PortID = "AOS_1_LoadPort",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1513,
                        }
                    },
                    { 1 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 1,
                           PortID = "AOS_1_UnloadPort",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1514,

                        }
                    }
                }
            },
            new ConverterEQPInitialOption
            {
                IsActive = true,
                Name = "AOS_2",
                Eq_Name = CasstteConverter.Enums.EQ_NAMES.AOS_2,
                ConverterType = CasstteConverter.Enums.CONVERTER_TYPE.SYS_2_SYS,
                Ports = new Dictionary<int, CasstteConverter.clsConverterPort.clsPortProperty>()
                {
                    { 0 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 0,
                           PortID = "AOS_2_LoadPort",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1515,
                        }
                    },
                    { 1 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 1,
                           PortID = "AOS_2_UnloadPort",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1516,

                        }
                    }
                }
            },
            new ConverterEQPInitialOption
            {
                IsActive = true,
                Name = "AOS_3",
                Eq_Name = CasstteConverter.Enums.EQ_NAMES.AOS_3,
                ConverterType = CasstteConverter.Enums.CONVERTER_TYPE.SYS_2_SYS,
                Ports = new Dictionary<int, CasstteConverter.clsConverterPort.clsPortProperty>()
                {
                    { 0 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 0,
                           PortID = "AOS_3_LoadPort",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1517,
                        }
                    },
                    { 1 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 1,
                           PortID = "AOS_3_UnloadPort",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1518,

                        }
                    }
                }
            },
            new ConverterEQPInitialOption
            {
                IsActive = true,
                Name = "AOS_4",
                Eq_Name = CasstteConverter.Enums.EQ_NAMES.AOS_4,
                ConverterType = CasstteConverter.Enums.CONVERTER_TYPE.SYS_2_SYS,
                Ports = new Dictionary<int, CasstteConverter.clsConverterPort.clsPortProperty>()
                {
                    { 0 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 0,
                           PortID = "AOS_4_LoadPort",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1519,
                        }
                    },
                    { 1 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 1,
                           PortID = "AOS_4_UnloadPort",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1520,

                        }
                    }
                }
            },
            new ConverterEQPInitialOption
            {
                IsActive = true,
                Name = "TS_1",
                Eq_Name = CasstteConverter.Enums.EQ_NAMES.TS_1,
                ConverterType = CasstteConverter.Enums.CONVERTER_TYPE.SYS_2_SYS,
                Ports = new Dictionary<int, CasstteConverter.clsConverterPort.clsPortProperty>()
                {
                    { 0 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 0,
                           PortID = "TS_1_Port",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1521,
                        }
                    }
                }
            },
            new ConverterEQPInitialOption
            {
                IsActive = true,
                Name = "TS_2_1",
                Eq_Name = CasstteConverter.Enums.EQ_NAMES.TS_2_1,
                ConverterType = CasstteConverter.Enums.CONVERTER_TYPE.SYS_2_SYS,
                Ports = new Dictionary<int, CasstteConverter.clsConverterPort.clsPortProperty>()
                {
                    { 0 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 0,
                           PortID = "TS_2_1_In_Sys_Port",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1522,
                        }
                    }
                }
            },
            new ConverterEQPInitialOption
            {
                IsActive = true,
                Name = "TS_2_2",
                Eq_Name = CasstteConverter.Enums.EQ_NAMES.TS_2_2,
                ConverterType = CasstteConverter.Enums.CONVERTER_TYPE.SYS_2_SYS,
                Ports = new Dictionary<int, CasstteConverter.clsConverterPort.clsPortProperty>()
                {
                    { 0 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 0,
                           PortID = "TS_2_2_In_Sys_Port",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1522,
                        }
                    }
                }
            },
            new ConverterEQPInitialOption
            {
                IsActive = true,
                Name = "TS_3",
                Eq_Name = CasstteConverter.Enums.EQ_NAMES.TS_3,
                ConverterType = CasstteConverter.Enums.CONVERTER_TYPE.SYS_2_SYS,
                Ports = new Dictionary<int, CasstteConverter.clsConverterPort.clsPortProperty>()
                {
                    { 0 , new CasstteConverter.clsConverterPort.clsPortProperty(){
                         ModbusServer_Enable = true,
                          PortNo= 0,
                           PortID = "TS_3_Port",
                            ModbusServer_IP="127.0.0.1",
                             ModbusServer_PORT = 1524,
                        }
                    }
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
