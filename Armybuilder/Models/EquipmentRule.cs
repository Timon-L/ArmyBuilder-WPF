using System;
using System.Collections.Generic;

namespace ArmyBuilder.Models;

public partial class EquipmentRule
{
    public long EquipmentEquipmentId { get; set; }

    public long RulesRuleId { get; set; }

    public virtual Equipment EquipmentEquipment { get; set; } = null!;

    public virtual Rule RulesRule { get; set; } = null!;
}
