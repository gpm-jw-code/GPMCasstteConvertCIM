using System;
using System.Collections.Generic;

namespace GPMCasstteConvertCIM.DataBase.KGS_AGVs.Models;

public partial class UserLoginLog
{
    public string UserName { get; set; } = null!;

    public DateTime DateTime { get; set; }

    public string Operation { get; set; } = null!;
}
