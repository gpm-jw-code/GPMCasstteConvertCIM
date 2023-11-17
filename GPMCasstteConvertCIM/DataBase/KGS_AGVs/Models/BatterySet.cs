using System;
using System.Collections.Generic;

namespace GPMCasstteConvertCIM.DataBase.KGS_AGVs.Models;

public partial class BatterySet
{
    public int AGVID { get; set; }

    public int? UpperBound { get; set; }

    public int LowerBound { get; set; }

    public double? CheckVoltage { get; set; }

    public int? VoltageDiff { get; set; }

    public int? RecommBound { get; set; }

    public int? DelayChargeByMin { get; set; }
}
