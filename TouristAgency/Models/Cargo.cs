using System;
using System.Collections.Generic;

namespace TouristAgency.Models;

public partial class Cargo
{
    public int CargoId { get; set; }

    public int? FlightId { get; set; }

    public decimal? CargoWeight { get; set; }

    public string? CargoType { get; set; }

    public virtual Flight? Flight { get; set; }
}
