using System;
using System.Collections.Generic;

namespace ArmyBuilder.Models;

public partial class User
{
    public long UserId { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Username { get; set; }

    public byte[]? Roles { get; set; }

    public virtual ICollection<Army> Armies { get; set; } = new List<Army>();
}
