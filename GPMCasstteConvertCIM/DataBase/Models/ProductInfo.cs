using System;
using System.Collections.Generic;

namespace GPMCasstteConvertCIM.Database;

public partial class ProductInfo
{
    public string ID { get; set; } = null!;

    public string CommandID { get; set; } = null!;

    public string PartID { get; set; } = null!;

    public string LotID { get; set; } = null!;

    public string RecipeID { get; set; } = null!;

    public string LayerNo { get; set; } = null!;

    public string Frame { get; set; } = null!;

    public string Stamp { get; set; } = null!;

    public DateTime? Receive_Time { get; set; }

    public DateTime? InRackLDTime { get; set; }

    public DateTime? OvenLDTime { get; set; }

    public DateTime? OvenULDTime { get; set; }

    public DateTime? OutRackULDTime { get; set; }

    public string? OutRackOPID { get; set; }

    public int? ProcessResultOfSystem { get; set; }

    public int? ProcessResultOfOutRack { get; set; }

    public string? SerialID { get; set; }
}
