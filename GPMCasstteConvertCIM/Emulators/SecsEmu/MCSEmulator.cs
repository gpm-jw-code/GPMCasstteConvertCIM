using GPMCasstteConvertCIM.GPM_SECS;
using Secs4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.GPM_SECS.SECSMessageHelper;

namespace GPMCasstteConvertCIM.Emulators.SecsEmu
{
    internal class MCSEmulator : ISECSEmulator
    {
        public SECSBase secsIF { get; set; } = new SECSBase("HOST_MCS_Emulator");

        public MCSEmulator()
        {
            secsIF.ConnectionChanged += SecsConnectionChanged;
            secsIF.OnPrimaryMessageRecieve += Secs_host_OnPrimaryMessageRecieve;
        }

        public void Secs_host_OnPrimaryMessageRecieve(object? sender, PrimaryMessageWrapper _PrimaryMessageWrapper)
        {
            Task.Factory.StartNew(async () =>
            {
                SecsMessage primarymsg = _PrimaryMessageWrapper.PrimaryMessage;

                var echoMsg = new SecsMessage(primarymsg.S, (byte)(primarymsg.F + 1), false)
                {
                    Name = primarymsg.Name,
                    SecsItem = primarymsg.SecsItem,
                };

                bool reply_success = await _PrimaryMessageWrapper.TryReplyAsync(echoMsg);
            });
        }

        public void SecsConnectionChanged(ConnectionState _ConnectionState)
        {
            //throw new NotImplementedException();
        }

        public void Active(SecsGemOptions _options)
        {
            secsIF.Active(_options);
        }
    }
}
