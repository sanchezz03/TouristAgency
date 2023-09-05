namespace TouristAgency.Models
{
    public class GetOccupiedRoomsByHotelAndPeriod
    {
        public int hotel_id { get; set; }
        public string hotel_name { get; set; }
        public string hotel_address { get; set; }
        public int occupied_rooms { get; set; }
    }
}
