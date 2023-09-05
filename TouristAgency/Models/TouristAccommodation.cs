using System;
using System.Collections.Generic;

namespace TouristAgency.Models;

public partial class TouristAccommodation
{
    public DateTime? CheckInDate { get; set; }

    public DateTime? CheckOutDate { get; set; }

    public int? HotelId { get; set; }

    public int? TouristId { get; set; }

    public virtual Hotel? Hotel { get; set; }

    public virtual Tourist? Tourist { get; set; }
}
