using System;
using System.Collections.Generic;

namespace GPMCasstteConvertCIM.DataBase.KGS_AGVs.Models;

public partial class MeasureInfo
{
    public string CommandID { get; set; } = null!;

    public DateTime? Receive_Time { get; set; }

    public string? Bay { get; set; }

    public string? Points { get; set; }

    public int? InPoint { get; set; }

    public int? OutPoint { get; set; }
}
