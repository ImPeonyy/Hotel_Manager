namespace BookingHotel.Models
{
    public class RoomTypeDetail
    {
        public int roomTypeDetailID { get; set; }
        public int roomTypeID { get; set; }
        public string description { get; set; }
        public int maxPeople { get; set; }
        public string view { get; set; }
        public string size { get; set; }
        public string bed { get; set; }


        public RoomType RoomType { get; set; }
        public Service Service { get; set; }
        public ICollection<RoomTypeDetailImage> Images { get; set; }
    }
}
