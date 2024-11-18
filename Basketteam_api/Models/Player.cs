using System;
using System.Collections.Generic;

namespace Basketteam_api.Models;

public partial class Player
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Height { get; set; }

    public int Weight { get; set; }

    public DateTime CreatedTime { get; set; }

    public virtual ICollection<Matchdatum> Matchdata { get; set; } = new List<Matchdatum>();
}
