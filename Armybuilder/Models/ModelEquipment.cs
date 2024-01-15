using System;
using System.Collections.Generic;

namespace ArmyBuilder.Models;

public partial class ModelEquipment
{
    public long EquipmentsEquipmentId { get; set; }

    public long ModelModelId { get; set; }

    public virtual Equipment EquipmentsEquipment { get; set; } = null!;

    public virtual Model ModelModel { get; set; } = null!;
}
