using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static GPMCasstteConvertCIM.Devices.DevicesManager;

namespace GPMCasstteConvertCIM.Devices
{
    public class InitialOption
    {
        public InitialOption()
        {

        }
        public InitialOption(CIM_DEVICE_TYPES DeviceType)
        {
            this.DeviceType = DeviceType;
        }

        internal RichTextBox logRichTextBox;

        internal object mainUI;
        public string Name { get; set; } = "";
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public ushort DeviceId { get; set; }
        public bool IsActive { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public CIM_DEVICE_TYPES DeviceType { get; set; }
    }
}
