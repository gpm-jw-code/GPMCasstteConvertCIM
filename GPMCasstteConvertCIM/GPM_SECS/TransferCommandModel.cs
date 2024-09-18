using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.GPM_SECS
{
    public class TransferCommandModel
    {
        public DateTime Time { get; set; } = DateTime.MinValue;
        public string SourceID { get; set; } = "";
        public string DestinationID { get; set; } = "";
        public string CarrierID { get; set; } = "";
        public int Prority { get; set; } = 50;

    }
}
