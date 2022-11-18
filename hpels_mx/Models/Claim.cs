using System;
using System.Collections.Generic;

namespace hpels_mx.Models;

public partial class Claim
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public bool Status { get; set; }

    public DateTime Date { get; set; }

    public int VehicleId { get; set; }

    public virtual Vehicle Vehicle { get; set; } = null!;
}
