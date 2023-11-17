using System;
using System.Collections.Generic;

namespace GPMCasstteConvertCIM.DataBase.KGS_AGVs.Models;

public partial class UserInfo
{
    public string UserName { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string UserGroup { get; set; } = null!;

    public int LogoutTime { get; set; }

    public string? Description { get; set; }

    public DateTime? CreateTime { get; set; }
}
