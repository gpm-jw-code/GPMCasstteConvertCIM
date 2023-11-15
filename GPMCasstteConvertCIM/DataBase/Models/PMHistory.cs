using System;
using System.Collections.Generic;

namespace GPMCasstteConvertCIM.Database;

public partial class PMHistory
{
    public int AGVID { get; set; }

    public DateTime PMDate { get; set; }

    public string? UserName { get; set; }

    public string? Comment { get; set; }
}
