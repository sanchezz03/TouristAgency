using System;
using System.Collections.Generic;

namespace TouristAgency.Models;

public partial class ExcursionAgency
{
    public int AgencyId { get; set; }

    public string? AgencyName { get; set; }

    public string? AgencyAddress { get; set; }

    public string? AgencyPhoneNumber { get; set; }

    public virtual ICollection<Excursion> Excursions { get; set; } = new List<Excursion>();
}
