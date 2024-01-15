using System;
using System.Collections.Generic;

namespace ArmyBuilder.Models;

public partial class DetachmentRule
{
    public long DetachmentDetachmentId { get; set; }

    public long RulesRuleId { get; set; }

    public virtual Detachment DetachmentDetachment { get; set; } = null!;

    public virtual Rule RulesRule { get; set; } = null!;
}
