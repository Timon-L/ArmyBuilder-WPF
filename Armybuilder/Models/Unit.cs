using System;
using System.Collections.Generic;

namespace ArmyBuilder.Models;

public partial class Unit
{
    public long? FkFactionId { get; set; }

    public long UnitId { get; set; }

    public string? UnitName { get; set; }

    public string? UnitRole { get; set; }

    public virtual ICollection<DetachmentUnit> DetachmentUnits { get; set; } = new List<DetachmentUnit>();

    public virtual Faction? FkFaction { get; set; }

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();

    public virtual ICollection<UnitCost> UnitCosts { get; set; } = new List<UnitCost>();
}
