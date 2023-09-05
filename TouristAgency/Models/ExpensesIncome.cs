using System;
using System.Collections.Generic;

namespace TouristAgency.Models;

public partial class ExpensesIncome
{
    public int RecordId { get; set; }

    public string? ServiceName { get; set; }

    public DateTime? TransactionDate { get; set; }

    public decimal? Amount { get; set; }

    public string? ExpenseIncomeType { get; set; }
}
