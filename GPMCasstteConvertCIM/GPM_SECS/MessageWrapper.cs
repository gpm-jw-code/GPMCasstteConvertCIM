using Secs4Net;
using Secs4Net.Sml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.GPM_SECS
{
    public class MessageWrapper : PrimaryMessageWrapper
    {
        public MessageWrapper(SecsMessage primaryMessage, SecsMessage secondaryMessage) : base(primaryMessage, secondaryMessage)
        {
        }

        public  string PrimaryMessageSML
        {
            get
            {
                if (PrimaryMessage == null)
                    return "null";
                return base.PrimaryMessage?.ToSml();
            }
        }

        public  string SecondaryMessageSML
        {
            get
            {
                if (SecondaryMessage == null)
                    return "null";
                return base.SecondaryMessage?.ToSml();
            }
        }
    }
}
