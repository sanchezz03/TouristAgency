using System;
using System.Collections.Generic;

namespace TouristAgency.Models;

public partial class Luggage
{
    public int LuggageId { get; set; }

    public decimal? LuggageWeight { get; set; }

    public string? LuggageType { get; set; }

    public virtual ICollection<Tourist> Tourists { get; set; } = new List<Tourist>();
}
