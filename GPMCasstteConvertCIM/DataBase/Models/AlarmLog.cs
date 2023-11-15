using System;
using System.Collections.Generic;

namespace GPMCasstteConvertCIM.Database;

public partial class AlarmLog
{
    public DateTime OccuredDate { get; set; }

    public DateTime? FinishDate { get; set; }

    public string Location { get; set; } = null!;

    public int AlarmCode { get; set; }

    public string? Description { get; set; }

    public int? Duration { get; set; }

    public int AGVID { get; set; }

    public string? TaskName { get; set; }

    public string? Owner { get; set; }

    public int? Category { get; set; }

    public int? AlarmLevel { get; set; }

    public string? OPID { get; set; }
}
