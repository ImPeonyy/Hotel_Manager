using BookingHotel.Data;
using BookingHotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BookingHotel.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly HotelContext _context;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(HotelContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
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