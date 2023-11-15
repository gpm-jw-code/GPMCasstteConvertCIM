using System;
using System.Collections.Generic;

namespace GPMCasstteConvertCIM.Database;

public partial class AGVRemoteSetting
{
    public int? AGVID { get; set; }

    public int? ChargingDelaySecTime { get; set; }

    public int? BypassCheckCargoStatus { get; set; }
}
