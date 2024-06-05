using System.ComponentModel.DataAnnotations;

namespace BookingHotel.Models
{
    public class AccountViewModels
    {
        public class RegisterViewModel
        {
            //[Required(ErrorMessage = "Tên người dùng là trường bắt buộc.")]
            public string Username { get; set; }

            //[Required(ErrorMessage = "Mật khẩu là trường bắt buộc.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            //[Required(ErrorMessage = "Xác nhận mật khẩu là trường bắt buộc.")]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Mật khẩu và xác nhận mật khẩu không khớp.")]
            public string ConfirmPassword { get; set; }

            //[Required(ErrorMessage = "Họ và tên là trường bắt buộc.")]
            public string Name { get; set; }

            //[Required(ErrorMessage = "Số điện thoại là trường bắt buộc.")]
            [RegularExpression(@"^(0|\+84)(\d{9,10})$", ErrorMessage = "Số điện thoại không hợp lệ.")]
            public string PhoneNumber { get; set; }
        }

        public class LoginViewModel
        {
            [Required(ErrorMessage = "Tên người dùng là trường bắt buộc.")]
            public string Username { get; set; }

            [Required(ErrorMessage = "Mật khẩu là trường bắt buộc.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
        public class UserProfileViewModel
        {
            public string Username { get; set; }
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public List<Request> Requests { get; set; }
        }
    }
}
