using System;
using System.Collections.Generic;

namespace GPMCasstteConvertCIM.DataBase.KGS_AGVs.Models;

public partial class AGVRemoteSetting
{
    public int? AGVID { get; set; }

    public int? ChargingDelaySecTime { get; set; }

    public int? BypassCheckCargoStatus { get; set; }
}
