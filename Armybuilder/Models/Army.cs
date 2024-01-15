using System;
using System.Collections.Generic;

namespace ArmyBuilder.Models;

public partial class Army
{
    public long? FkFactionId { get; set; }

    public long? FkUserId { get; set; }

    public long Id { get; set; }

    public string? ArmyName { get; set; }

    public virtual Faction? FkFaction { get; set; }

    public virtual User? FkUser { get; set; }
}
