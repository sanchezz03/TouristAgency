using System;
using System.Collections.Generic;

namespace TouristAgency.Models;

public partial class Flight
{
    public int FlightId { get; set; }

    public string? FlightNumber { get; set; }

    public DateTime? DepartureDate { get; set; }

    public DateTime? ArrivalDate { get; set; }

    public string? AircraftType { get; set; }

    public virtual ICollection<Cargo> Cargos { get; set; } = new List<Cargo>();

    public virtual ICollection<TouristsFlight> TouristsFlights { get; set; } = new List<TouristsFlight>();
}
