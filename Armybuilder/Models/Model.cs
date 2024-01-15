using System;
using System.Collections.Generic;

namespace ArmyBuilder.Models;

public partial class Model
{
    public int? Leadership { get; set; }

    public int? Movement { get; set; }

    public int? ObjectiveControl { get; set; }

    public int? Save { get; set; }

    public int? Toughness { get; set; }

    public int? Wound { get; set; }

    public long? FkModelId { get; set; }

    public long ModelId { get; set; }

    public string? ModelName { get; set; }

    public virtual Unit? FkModel { get; set; }
}
