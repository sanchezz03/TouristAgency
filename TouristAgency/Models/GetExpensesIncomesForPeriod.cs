namespace TouristAgency.Models
{
    public class GetExpensesIncomesForPeriod
    {
        public int record_id { get; set; }
        public string service_name { get; set; }
        public DateTime transaction_date { get; set; }
        public decimal amount { get; set; }
        public string expense_income_type { get; set; }
    }
}
