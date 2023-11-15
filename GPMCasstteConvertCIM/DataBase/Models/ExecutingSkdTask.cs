using System;
using System.Collections.Generic;

namespace GPMCasstteConvertCIM.Database;

public partial class ExecutingSkdTask
{
    public string CommandID { get; set; } = null!;

    public string? Bay { get; set; }

    public int? Status { get; set; }

    public DateTime? Schedule_Time { get; set; }

    public int? AGVID { get; set; }

    public string? MeasurePoints { get; set; }

    public string? PatrolPoints { get; set; }

    public string? FinishedPoints { get; set; }

    public double? Progress { get; set; }

    public DateTime? StartTime { get; set; }
}
