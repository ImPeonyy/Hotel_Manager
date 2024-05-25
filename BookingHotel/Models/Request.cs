using System.ComponentModel.DataAnnotations;

namespace BookingHotel.Models
{
    public class Request
    {
        public int requestID { get; set; }
        public int accountID { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dateCheckIn { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dateCheckOut { get; set; }
        public int guestCount { get; set; }
        public int roomTypeID { get; set; }
        public string message { get; set; }
        public string status { get; set; }

        public Account Account { get; set; }
        public RoomType RoomType { get; set; }
    }
}
