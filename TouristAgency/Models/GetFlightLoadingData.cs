namespace TouristAgency.Models
{
    public class GetFlightLoadingData
    {
        public string flight_number { get; set; }
        public DateTime departure_date { get; set; }
        public DateTime arrival_date { get; set; }
        public int number_of_seats { get; set; }
        public decimal total_luggage_weight { get; set; }
        public decimal total_volumetric_weight { get; set; }
    }
}
