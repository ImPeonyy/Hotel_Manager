namespace BookingHotel.Models
{
    public class Room
    {
        public int roomID { get; set; }
        public string roomName { get; set; }
        public int roomTypeID { get; set; }
        public string status { get; set; }

        public RoomType RoomType { get; set; }
        public ICollection<Enrollment> Enrollment { get; set; }
    }
}
