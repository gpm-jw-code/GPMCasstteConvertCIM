using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.CasstteConverter.Enums;
using static GPMCasstteConvertCIM.Devices.DevicesManager;

namespace GPMCasstteConvertCIM.Devices.Options
{
    public class ConverterEQPInitialOption : InitialOption
    {
        [JsonConverter(typeof(StringEnumConverter))]

        public CONVERTER_TYPE ConverterType { get; set; } = CONVERTER_TYPE.IN_SYS;


        public ConverterEQPInitialOption()
        {

            DeviceType = CIM_DEVICE_TYPES.CASSTTE_CONVERTER;
        }

    }
}
