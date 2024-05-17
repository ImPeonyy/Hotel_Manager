namespace BookingHotel.Models
{
    public class RoomTypeDetailImage
    {
        public int roomTypeDetailImageID { get; set; }
        public int roomTypeDetailID { get; set; }
        public string imagePath { get; set; }

        public RoomTypeDetail RoomTypeDetail { get; set; }
    }
}
