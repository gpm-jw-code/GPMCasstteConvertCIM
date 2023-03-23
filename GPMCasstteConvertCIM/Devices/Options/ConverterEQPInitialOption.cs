using GPMCasstteConvertCIM.CasstteConverter;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.CasstteConverter.clsConverterPort;
using static GPMCasstteConvertCIM.CasstteConverter.Enums;
using static GPMCasstteConvertCIM.Devices.DevicesManager;

namespace GPMCasstteConvertCIM.Devices.Options
{
    public class ConverterEQPInitialOption : InitialOption
    {
        [JsonConverter(typeof(StringEnumConverter))]

        public CONVERTER_TYPE ConverterType { get; set; } = CONVERTER_TYPE.IN_SYS;
        public Dictionary<int, clsPortProperty> Ports { get; set; } = new Dictionary<int, clsPortProperty>();

        public ConverterEQPInitialOption()
        {

            DeviceType = CIM_DEVICE_TYPES.CASSTTE_CONVERTER;
        }

    }
}
