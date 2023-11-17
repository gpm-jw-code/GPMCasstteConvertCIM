using System;
using System.Collections.Generic;

namespace GPMCasstteConvertCIM.DataBase.KGS_AGVs.Models;

public partial class TrafficTask
{
    public int AGVID { get; set; }

    public string StartPos { get; set; } = null!;

    public string TargetPos { get; set; } = null!;

    public string FullPath { get; set; } = null!;

    public double Weight { get; set; }

    public string ShortPath { get; set; } = null!;

    public string InvolvePoint { get; set; } = null!;

    public string BookingPath { get; set; } = null!;

    public string CrossPoint { get; set; } = null!;

    public int CrossAGVID { get; set; }
}
