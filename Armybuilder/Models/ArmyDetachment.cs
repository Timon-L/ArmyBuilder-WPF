using System;
using System.Collections.Generic;

namespace ArmyBuilder.Models;

public partial class ArmyDetachment
{
    public long ArmyId { get; set; }

    public long DetachmentsDetachmentId { get; set; }

    public virtual Army Army { get; set; } = null!;

    public virtual Detachment DetachmentsDetachment { get; set; } = null!;
}
