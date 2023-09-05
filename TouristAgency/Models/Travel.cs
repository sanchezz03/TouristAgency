using System;
using System.Collections.Generic;

namespace TouristAgency.Models;

public partial class Travel
{
    public int TravelId { get; set; }

    public DateTime? TravelStartDate { get; set; }

    public DateTime? TravelEndDate { get; set; }

    public int? CountryId { get; set; }

    public int? TouristId { get; set; }

    public virtual Country? Country { get; set; }

    public virtual Tourist? Tourist { get; set; }
}
