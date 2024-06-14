using System.ComponentModel.DataAnnotations;

namespace BookingHotel.Models
{
    public class Menu
    {
        public int ID { get; set; }
        public string dishName { get; set; }
        public string dishDescription { get; set; }
        public double dishPrice { get; set; }
        public string dishImage { get; set; }
    }
}
