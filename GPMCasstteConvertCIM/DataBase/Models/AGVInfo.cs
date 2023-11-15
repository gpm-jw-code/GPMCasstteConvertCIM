using System;
using System.Collections.Generic;

namespace GPMCasstteConvertCIM.Database;

public partial class AGVInfo
{
    public int AGVID { get; set; }

    public string AGVName { get; set; } = null!;

    public int AGVMainStatus { get; set; }

    public int AGVSubStatus { get; set; }

    public int AGVMode { get; set; }

    public int? CurrentPos { get; set; }

    public string? DoTaskName { get; set; }

    public string? CSTID { get; set; }

    public double? Battery { get; set; }

    public double? Battery2 { get; set; }

    public int? AlarmCode { get; set; }

    public string? AlarmDescription { get; set; }

    public string? E82VehicleState { get; set; }

    public int? ForkHeight { get; set; }

    public int? ProcessResult { get; set; }
}
