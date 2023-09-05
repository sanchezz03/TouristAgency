namespace TouristAgency.Models
{
    public class GetFinancialReportForGroupAndCategory
    {
        public int report_id { get; set; }
        public DateTime report_date { get; set; }
        public string group_name { get; set; }
        public string category_name { get; set; }
        public decimal total_income { get; set; }
        public decimal total_expenses { get; set; }
        public decimal net_profit { get; set; }
    }
}
