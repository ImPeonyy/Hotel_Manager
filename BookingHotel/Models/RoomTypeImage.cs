using System.ComponentModel.DataAnnotations;

namespace BookingHotel.Models
{
    public class RoomTypeImage
    {
        public int roomTypeImageID { get; set; }
        [Display(Name = "Room Type")]
        public int roomTypeDetailID { get; set; }
        [Display(Name = "Image")]
        public string imagePath { get; set; }

        public RoomTypeDetail RoomTypeDetail { get; set; }
    }
}
