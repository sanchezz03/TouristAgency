namespace TouristAgency.Models
{
    public class GetLuggageStatistics
    {
        public string luggage_type { get; set; }
        public int luggage_count { get; set; }
        public decimal relative_share { get; set; }
    }
}
