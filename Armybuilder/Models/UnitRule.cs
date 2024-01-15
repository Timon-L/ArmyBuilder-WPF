using System;
using System.Collections.Generic;

namespace ArmyBuilder.Models;

public partial class UnitRule
{
    public long RulesRuleId { get; set; }

    public long UnitUnitId { get; set; }

    public virtual Rule RulesRule { get; set; } = null!;

    public virtual Unit UnitUnit { get; set; } = null!;
}
