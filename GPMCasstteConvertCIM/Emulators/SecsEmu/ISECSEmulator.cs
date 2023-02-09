using GPMCasstteConvertCIM.GPM_SECS;
using Secs4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.Emulators.SecsEmu
{
    internal interface ISECSEmulator
    {
        SECSBase secsIF { get; set; }
        void SecsConnectionChanged(ConnectionState _ConnectionState);
        void Secs_host_OnPrimaryMessageRecieve(object? sender, PrimaryMessageWrapper _PrimaryMessageWrapper);
        void Active(SecsGemOptions _options);
    }
}
