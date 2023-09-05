using System;
using System.Collections.Generic;

namespace TouristAgency.Models;

public partial class Hotel
{
    public int HotelId { get; set; }

    public string? HotelName { get; set; }

    public string? HotelAddress { get; set; }

    public int? HotelCategoryId { get; set; }

    public virtual ICollection<HotelAccommodation> HotelAccommodations { get; set; } = new List<HotelAccommodation>();

    public virtual HotelCategory? HotelCategory { get; set; }
}
