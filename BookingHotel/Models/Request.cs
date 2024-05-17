namespace BookingHotel.Models
{
    public class Request
    {
        public int requestID { get; set; }
        public int accountID { get; set; }
        public DateTime dateCheckIn { get; set; }
        public DateTime dateCheckOut { get; set; }
        public int guestCount { get; set; }
        public string roomType { get; set; }
        public string message { get; set; }
        public string status { get; set; }

        public Account Account { get; set; }
    }
}
