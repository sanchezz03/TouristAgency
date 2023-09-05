using System;
using System.Collections.Generic;

namespace TouristAgency.Models;

public partial class FinancialReport
{
    public int ReportId { get; set; }

    public DateTime? ReportDate { get; set; }

    public string? GroupName { get; set; }

    public string? CategoryName { get; set; }

    public decimal? TotalIncome { get; set; }

    public decimal? TotalExpenses { get; set; }

    public decimal? NetProfit { get; set; }
}
