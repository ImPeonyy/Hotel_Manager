using System.ComponentModel.DataAnnotations;

namespace BookingHotel.Models
{
    public class RoomType
    {
        public int roomTypeID { get; set; }
        public string roomTypeName { get; set; }
        public int roomLeft { get; set; }

        public ICollection<Room> Rooms { get; set; }
        public RoomTypeDetail RoomTypeDetail { get; set; }
    }
}
