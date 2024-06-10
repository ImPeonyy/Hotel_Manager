using System.ComponentModel.DataAnnotations;

namespace BookingHotel.Models
{
    public class AccountViewModels
    {
            [StringLength(30, MinimumLength = 6, ErrorMessage = "Invalid length")]
            [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Invalid Username .")]
            public string Username { get; set; }

            [StringLength(30, MinimumLength = 6, ErrorMessage = "Invalid length")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [StringLength(30, MinimumLength = 6, ErrorMessage = "Invalid length")]
            [DataType(DataType.Password)]
            public string ConfirmPassword { get; set; }

            public string Name { get; set; }

            [RegularExpression(@"^(0|\+84)(\d{9,10})$", ErrorMessage = "Invalid phone number")]
            public string PhoneNumber { get; set; }
            public List<Request> Requests { get; set; }
    }
}
