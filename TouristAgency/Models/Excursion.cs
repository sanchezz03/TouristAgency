using System;
using System.Collections.Generic;

namespace TouristAgency.Models;

public partial class Excursion
{
    public int ExcursionId { get; set; }

    public string? ExcursionName { get; set; }

    public DateTime? ExcursionDate { get; set; }

    public string? ExcursionDescription { get; set; }

    public decimal? ExcursionCost { get; set; }

    public int? AgencyId { get; set; }

    public virtual ExcursionAgency? Agency { get; set; }

    public virtual ICollection<Tourist> Tourists { get; set; } = new List<Tourist>();
}
