using System.ComponentModel.DataAnnotations;

namespace BookingHotel.Models
{
    public class RoomTypeDetail
    {
        public int roomTypeDetailID { get; set; }
        [Display(Name = "Room Type")]
        public int roomTypeID { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Occupancy")]
        public int maxPeople { get; set; }
        [Display(Name = "View")]
        public string view { get; set; }
        [Display(Name = "Size")]
        public string size { get; set; }
        [Display(Name = "Bed")]
        public string bed { get; set; }


        public RoomType RoomType { get; set; }
        public Service Service { get; set; }
        public ICollection<RoomTypeImage> Images { get; set; }
    }
}
