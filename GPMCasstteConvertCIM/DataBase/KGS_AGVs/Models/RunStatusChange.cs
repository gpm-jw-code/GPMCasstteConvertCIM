using System;
using System.Collections.Generic;

namespace GPMCasstteConvertCIM.DataBase.KGS_AGVs.Models;

public partial class RunStatusChange
{
    public DateTime ChangeTime { get; set; }

    public int AGVID { get; set; }

    public int AGVMainStatus { get; set; }
}
