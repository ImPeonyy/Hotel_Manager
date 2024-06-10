using System.ComponentModel.DataAnnotations;

namespace BookingHotel.Models
{
    public class Account
    {
        public int accountID {  get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string role { get; set; }

        public ICollection<Request> Requests { get; set; }
        public ICollection<Enrollment> Enrollment { get; set; }

    }
}
