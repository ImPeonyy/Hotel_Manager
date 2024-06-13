using System.ComponentModel.DataAnnotations;

namespace BookingHotel.Models
{
    public class RoomType
    {
        public int roomTypeID { get; set; }
        [Display(Name = "Name")]
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Invalid length")]
        public string roomTypeName { get; set; }
        [Display(Name = "Room left")]
        public int roomLeft { get; set; }

        public ICollection<Room> Rooms { get; set; }
        public RoomTypeDetail RoomTypeDetail { get; set; }
    }
}
