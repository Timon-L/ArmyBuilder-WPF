using System;
using System.Collections.Generic;

namespace ArmyBuilder.Models;

public partial class DetachmentUnit
{
    public int Quantity { get; set; }

    public long? DetachmentId { get; set; }

    public long Id { get; set; }

    public long? UnitId { get; set; }

    public virtual Detachment? Detachment { get; set; }

    public virtual Unit? Unit { get; set; }
}
