using System;
using System.Collections.Generic;

namespace ArmyBuilder.Models;

public partial class UnitCost
{
    public int? ModelCount { get; set; }

    public int? PointCost { get; set; }

    public long? FkUnitCostId { get; set; }

    public long UnitCostId { get; set; }

    public virtual Unit? FkUnitCost { get; set; }
}
