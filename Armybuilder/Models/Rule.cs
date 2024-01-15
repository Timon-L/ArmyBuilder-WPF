using System;
using System.Collections.Generic;

namespace ArmyBuilder.Models;

public partial class Rule
{
    public long RuleId { get; set; }

    public string? RuleDescription { get; set; }

    public string? RuleName { get; set; }
}
