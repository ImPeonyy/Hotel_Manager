namespace BookingHotel.Models
{
    public class RoomTypeImage
    {
        public int roomTypeImageID { get; set; }
        public int roomTypeDetailID { get; set; }
        public string imagePath { get; set; }

        public RoomTypeDetail RoomTypeDetail { get; set; }
    }
}
