using System;
using System.Collections.Generic;

namespace GPMCasstteConvertCIM.DataBase.KGS_AGVs.Models;

public partial class PMSetting
{
    public int AGVID { get; set; }

    public int? PMCount { get; set; }

    public int? DoneTaskCount { get; set; }
}
