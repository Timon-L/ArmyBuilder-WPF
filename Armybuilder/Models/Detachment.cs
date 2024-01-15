using System;
using System.Collections.Generic;

namespace ArmyBuilder.Models;

public partial class Detachment
{
    public long DetachmentId { get; set; }

    public string? DetachmentName { get; set; }

    public virtual ICollection<DetachmentUnit> DetachmentUnits { get; set; } = new List<DetachmentUnit>();
}
