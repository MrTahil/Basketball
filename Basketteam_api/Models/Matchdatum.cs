using System;
using System.Collections.Generic;

namespace Basketteam_api.Models;

public partial class Matchdatum
{
    public string Id { get; set; } = null!;

    public DateTime In { get; set; }

    public DateTime Out { get; set; }

    public int Try { get; set; }

    public int Goal { get; set; }

    public int Fault { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime UpdatedTime { get; set; }

    public string PlayerId { get; set; } = null!;

    public virtual Player Player { get; set; } = null!;
}
