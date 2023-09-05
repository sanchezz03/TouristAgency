namespace TouristAgency.Models
{
    public class GetHotelAccommodations
    {
        public int room_number { get; set; }
        public string room_type { get; set; }
        public decimal room_price { get; set; }
        public DateTime check_in_date { get; set; }
        public DateTime check_out_date { get; set; }
        public int tourist_id { get; set; }
        public int hotel_id { get; set; }
        public string hotel_name { get; set; }
        public string category_name { get; set; }
    }
}
