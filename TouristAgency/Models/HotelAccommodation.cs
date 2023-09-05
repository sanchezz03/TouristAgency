using System;
using System.Collections.Generic;

namespace TouristAgency.Models;

public partial class HotelAccommodation
{
    public int RoomNumber { get; set; }

    public string? RoomType { get; set; }

    public decimal? RoomPrice { get; set; }

    public DateTime? CheckInDate { get; set; }

    public DateTime? CheckOutDate { get; set; }

    public int? TouristId { get; set; }

    public int? HotelId { get; set; }

    public virtual Hotel? Hotel { get; set; }

    public virtual Tourist? Tourist { get; set; }
}
