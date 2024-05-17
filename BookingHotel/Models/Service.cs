namespace BookingHotel.Models
{
    public class Service
    {
        public int serviceID { get; set; }
        public string general { get; set; }
        public string bathroom { get; set; }
        public string other {  get; set; }
        public int roomTypeDetailID { get; set; }

        public RoomTypeDetail RoomTypeDetail { get; set; } 
    }
}
