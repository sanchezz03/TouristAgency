using System;
using System.Collections.Generic;

namespace TouristAgency.Models;

public partial class HotelCategory
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
}
