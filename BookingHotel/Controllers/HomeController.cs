using BookingHotel.Data;
using BookingHotel.Models;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.EntityFrameworkCore;

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

        public IActionResult Index()
        {
            var roomTypes = _context.RoomTypes.Include(rt => rt.RoomTypeDetail).ToList();
            var roomTypeViewModels = roomTypes.Select(rt => new ViewModels.RoomTypeViewModel
            {
                Value = rt.roomTypeID,
                Text = rt.roomTypeName,
                RoomLeft = rt.roomLeft,
                MaxPeople = rt.RoomTypeDetail?.maxPeople ?? 0 
            }).ToList();
            ViewBag.RoomTypeViewModels = roomTypeViewModels;
            return View();
        }
        [HttpPost]
        public IActionResult Booking(Request model)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var username = HttpContext.User.Identity.Name;

                    if (model.dateCheckIn > model.dateCheckOut || model.dateCheckIn < DateTime.Now)
                    {
                        TempData["ErrorMesssage"] = "Please select a valid date";
                        return RedirectToAction("Index", "Home");
                    }
                    var user = _context.Accounts.FirstOrDefault(u => u.username == username);
                    var roomType = _context.RoomTypes.FirstOrDefault(rt => rt.roomTypeID == model.roomTypeID);

                    if (roomType != null && roomType.roomLeft > 0)
                    {
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
                        roomType.roomLeft -= 1;

                        _context.SaveChanges();

                        TempData["SuccessMessage"] = "Booking successful. Please keep an eye on your phone, staff will contact you as soon as possible.";
                    }
                    else
                    {
                        TempData["ErrorMesssage"] = "No rooms available for the selected type.";
                    }
                    return RedirectToAction("Index", "Home");    
            }
            else
            {
                return RedirectToAction("Login", "Account");    
            }
            
        }






        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> OurRooms()
        {
            var roomTypes = _context.RoomTypes
            .Include(r => r.RoomTypeDetail)
            .AsNoTracking();
            return View(await roomTypes.ToListAsync());
        }
        public async Task<IActionResult> RoomDetail(int? id)
        {

            if (id == null || _context.RoomTypes == null)
            {
                return NotFound();
            }

            var roomTypes = await _context.RoomTypes
            .Include(r => r.RoomTypeDetail)
            .AsNoTracking()
            .FirstOrDefaultAsync(rt => rt.roomTypeID == id);
            return View(roomTypes);

            if (roomTypes == null)
            {
                return NotFound();
            }

            return View(roomTypes);
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