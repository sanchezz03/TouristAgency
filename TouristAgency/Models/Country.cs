using System;
using System.Collections.Generic;

namespace TouristAgency.Models;

public partial class Country
{
    public int CountryId { get; set; }

    public string? CountryName { get; set; }

    public virtual ICollection<Travel> Travels { get; set; } = new List<Travel>();
}
