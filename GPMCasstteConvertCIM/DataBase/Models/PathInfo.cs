using System;
using System.Collections.Generic;

namespace GPMCasstteConvertCIM.Database;

public partial class PathInfo
{
    public DateTime ChangeTime { get; set; }

    public int AGVID { get; set; }

    public int? Location { get; set; }
}
