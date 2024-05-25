using BookingHotel.Data;
using BookingHotel.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Security.Claims;

namespace BookingHotel.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HotelContext _context;

        public HomeController(ILogger<HomeController> logger, HotelContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        //public IActionResult Index()
        //{
        //    var roomTypes = _context.RoomTypes.ToList();
        //    if (roomTypes.Any()) // Kiểm tra xem roomTypes có giá trị không
        //    {
        //        var roomTypeList = new SelectList(roomTypes, "roomTypeID", "roomTypeName");
        //        ViewBag.RoomTypes = roomTypeList;
        //    }

           
        //    return View();
           
        //}
        public IActionResult Index()
        {
            var roomTypes = _context.RoomTypes.ToList();
            var roomTypeViewModels = roomTypes.Select(rt => new RoomTypeViewModel
            {
                Value = rt.roomTypeID,
                Text = rt.roomTypeName,
                RoomLeft = rt.roomLeft
            }).ToList();

            ViewBag.RoomTypeViewModels = roomTypeViewModels;
            var roomTypesDeital = _context.RoomTypeDetails.ToList();
            if (roomTypesDeital.Any())
            {
                var guestCount = new SelectList(roomTypesDeital, "maxPeople", "maxPeople");
                ViewBag.RoomTypeDetails = guestCount;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Booking(Request model)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var username = HttpContext.User.Identity.Name;
                if (username != null)
                {
                    var user = _context.Accounts.FirstOrDefault(u => u.username == username);
                    //var roomType = _context.RoomTypes.FirstOrDefault(r => r.roomTypeID == model.roomType)?.roomTypeName;
                    // accountIdValue chứa giá trị accountID
                    // Thêm logic để lưu yêu cầu vào cơ sở dữ liệu
                    var request = new Request
                    {
                        accountID = user.accountID,
                        dateCheckIn = model.dateCheckIn,
                        dateCheckOut = model.dateCheckOut,
                        guestCount = model.guestCount,
                        roomTypeID = model.roomTypeID,
                        message = model.message,
                        status = "Waiting"
                    };

                    _context.Requests.Add(request);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Xử lý khi không thể lấy được accountID
                    return RedirectToAction("Login", "Account");
                }
            }
            else
            {
                // Xử lý khi người dùng chưa đăng nhập
                return RedirectToAction("Login", "Account");
            }
        }





        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult OurRooms()
        {
            return View();
        }
        public IActionResult RoomDetail()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult BlogDeital()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}