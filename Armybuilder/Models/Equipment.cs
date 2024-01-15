using System;
using System.Collections.Generic;

namespace ArmyBuilder.Models;

public partial class Equipment
{
    public int? PointCost { get; set; }

    public long EquipmentId { get; set; }

    public string? ArmourPenetration { get; set; }

    public string? Attacks { get; set; }

    public string? BallisticSkill { get; set; }

    public string? Damage { get; set; }

    public string? EquipmentName { get; set; }

    public string? Keywords { get; set; }

    public string? Range { get; set; }

    public string? Strength { get; set; }
}
