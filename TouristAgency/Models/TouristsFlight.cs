using System;
using System.Collections.Generic;

namespace TouristAgency.Models;

public partial class TouristsFlight
{
    public int TouristFlightId { get; set; }

    public int? FlightId { get; set; }

    public int? TouristId { get; set; }

    public virtual Flight? Flight { get; set; }

    public virtual Tourist? Tourist { get; set; }
}
