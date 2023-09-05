using System;
using System.Collections.Generic;

namespace TouristAgency.Models;

public partial class Tourist
{
    public int TouristId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? CountryOfResidence { get; set; }

    public string? PassportNumber { get; set; }

    public int? TouristCategoryId { get; set; }

    public virtual ICollection<HotelAccommodation> HotelAccommodations { get; set; } = new List<HotelAccommodation>();

    public virtual TouristCategory? TouristCategory { get; set; }

    public virtual ICollection<TouristsFlight> TouristsFlights { get; set; } = new List<TouristsFlight>();

    public virtual ICollection<Travel> Travels { get; set; } = new List<Travel>();

    public virtual ICollection<Excursion> Excursions { get; set; } = new List<Excursion>();

    public virtual ICollection<Luggage> Luggage { get; set; } = new List<Luggage>();
}
