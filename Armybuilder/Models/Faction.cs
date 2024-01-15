using System;
using System.Collections.Generic;

namespace ArmyBuilder.Models;

public partial class Faction
{
    public long FactionId { get; set; }

    public string? FactionName { get; set; }

    public virtual ICollection<Army> Armies { get; set; } = new List<Army>();

    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();
}
