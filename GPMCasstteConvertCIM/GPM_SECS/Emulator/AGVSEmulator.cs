using Secs4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.GPM_SECS.SECSMessageHelper;

namespace GPMCasstteConvertCIM.GPM_SECS.Emulator
{
    internal class AGVSEmulator : ISECSEmulator
    {
        public SECSBase secsIF { get; set; } = new SECSBase();

        public AGVSEmulator()
        {
            secsIF.ConnectionChanged += SecsConnectionChanged;
            secsIF.OnPrimaryMessageRecieve += Secs_host_OnPrimaryMessageRecieve;
        }



        public void SecsConnectionChanged(ConnectionState _ConnectionState)
        {
            //throw new NotImplementedException();
        }

        public void Secs_host_OnPrimaryMessageRecieve(object? sender, PrimaryMessageWrapper _PrimaryMessageWrapper)
        {
            Task.Factory.StartNew(async () =>
            {
                var primarymsg = _PrimaryMessageWrapper.PrimaryMessage;
                await _PrimaryMessageWrapper.TryReplyAsync(EVENT_REPORT.EventReportAcknowledgeMessage(ACKC6.Accpeted));
            });
        }

        public void Active(SecsGemOptions _options)
        {
            secsIF.Active(_options, null);
        }
    }
}
