using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GPMCasstteConvertCIM.DataBase.KGS_AGVs.Models;

public partial class ExecutingTask
{
    [Key]
    public string Name { get; set; }

    public int Status { get; set; }

    public DateTime Receive_Time { get; set; }

    public int? FromStationId { get; set; }

    public int? ToStationId { get; set; }

    public string? FromStation { get; set; }

    public string? ToStation { get; set; }

    public string? FromStationName { get; set; }

    public string? ToStationName { get; set; }

    public string ActionType { get; set; } = "Move"!;

    public int AGVID { get; set; }

    public string CSTID { get; set; } = "";

    public int Priority { get; set; } = 5;

    public int RepeatTime { get; set; }

    public int ExeVehicleID { get; set; }

    public DateTime? StartTime { get; set; }

    public double Distance { get; set; }

    public DateTime? AcquireTime { get; set; }

    public DateTime? DepositTime { get; set; }

    public string? AssignUserName { get; set; } = "USER";

    public int? CSTType { get; set; } = 0;

    public int? FromStationPortNo { get; set; } = 1;

    public int? ToStationPortNo { get; set; } = 1;

    public int? ExeVehiclePos { get; set; } = 0;
}
