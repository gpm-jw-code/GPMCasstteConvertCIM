using System;
using System.Collections.Generic;

namespace GPMCasstteConvertCIM.DataBase.KGS_AGVs.Models;

public partial class TaskDto
{
    public string Name { get; set; } = null!;

    public int Status { get; set; }

    public DateTime Receive_Time { get; set; }

    public int? FromStationId { get; set; }

    public int? ToStationId { get; set; }

    public string? FromStation { get; set; }

    public string? ToStation { get; set; }

    public string? FromStationName { get; set; }

    public string? ToStationName { get; set; }

    public string ActionType { get; set; } = null!;

    public int AGVID { get; set; }

    public string CSTID { get; set; } = null!;

    public int Priority { get; set; }

    public int RepeatTime { get; set; }

    public int ExeVehicleID { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public string? TotalTime { get; set; }

    public double Distance { get; set; }

    public DateTime? AcquireTime { get; set; }

    public DateTime? DepositTime { get; set; }

    public string? AssignUserName { get; set; }

    public string? CancelUserName { get; set; }

    public int? CSTType { get; set; }

    public string? FailReason { get; set; }

    public int? FromStationPortNo { get; set; }

    public int? ToStationPortNo { get; set; }

    public int? ExeVehiclePos { get; set; }
}
