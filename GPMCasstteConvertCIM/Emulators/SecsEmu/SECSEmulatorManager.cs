using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.Emulators.SecsEmu
{
    internal class SECSEmulatorManager
    {
        internal static AGVSEmulator agvsmulator = new AGVSEmulator();
        internal static MCSEmulator mcsEmulator = new MCSEmulator();

        internal static void Start()
        {
            //agvsmulator.Active(new Secs4Net.SecsGemOptions
            //{
            //    DeviceId = 0,
            //    IpAddress = "127.0.0.1",
            //    Port = 5000,
            //    IsActive = true,
            //});

            mcsEmulator.Active(new Secs4Net.SecsGemOptions
            {
                DeviceId = 1,
                IpAddress = "127.0.0.1",
                Port = 5001,
                IsActive = false,
            });
        }

    }
}
