using BookingHotel.Models;

namespace BookingHotel.Models.RoomViewModels
{
    public class RoomTypeData
    {
        public IEnumerable<RoomType> RoomTypes { get; set; }
        public IEnumerable<RoomTypeDetail> RoomTypeDetails { get; set; }
        public IEnumerable<RoomTypeImage> RoomTypeImages { get; set; }
    }
}
