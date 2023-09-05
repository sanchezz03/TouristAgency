using System;
using System.Collections.Generic;

namespace TouristAgency.Models;

public partial class TouristCategory
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Tourist> Tourists { get; set; } = new List<Tourist>();
}
