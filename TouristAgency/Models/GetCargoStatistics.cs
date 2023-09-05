namespace TouristAgency.Models
{
    public class GetCargoStatistics
    {
        public int num_flights { get; set; }
        public int num_cargo_flights { get; set; }
        public int num_cargo_passenger_flights { get; set; }
        public decimal total_cargo_weight { get; set; }
        public decimal total_cargo_weight_cargo_flights { get; set; }
        public decimal total_cargo_weight_cargo_passenger_flights { get; set; }
        public int num_cargo_items { get; set; }
    }
}
