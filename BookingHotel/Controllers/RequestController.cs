using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BookingHotel.Models;
using BookingHotel.Data;
using Microsoft.EntityFrameworkCore;

namespace BookingHotel.Controllers
{
    public class RequestController : Controller
    {
        private readonly HotelContext _context;

        public RequestController(HotelContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString, string sortOrder,string statusFilter, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["DateSort"] = String.IsNullOrEmpty(sortOrder) ? "dateCheckIn_desc" : "";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            
            ViewData["CurrentFilter"] = searchString;
            ViewData["StatusFilter"] = statusFilter;
            IQueryable<Request> requests = _context.Requests.Include(r => r.Account).Include(a => a.RoomType);
            
            if (!String.IsNullOrEmpty(searchString))
            {
                requests = requests.Where(s => s.Account.phoneNumber.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(statusFilter))
            {
                requests = requests.Where(s => s.status == statusFilter);
            }
            
            switch (sortOrder)
            {
                case "dateCheckIn_desc":
                    requests = requests.OrderByDescending(r => r.dateCheckIn);
                    break;
                default:
                    requests = requests.OrderBy(r => r.dateCheckIn);
                    break;
            }

            int pageSize = 5;
            var paginatedRequests = await PaginatedList<Request>.CreateAsync(requests.AsNoTracking(), pageNumber ?? 1, pageSize);
            return View(paginatedRequests);
        }

        // Action method để hiển thị chi tiết yêu cầu
        public IActionResult Details(int id)
        {
            var request = _context.Requests.Include(r => r.Account).Include(r => r.RoomType).FirstOrDefault(r => r.requestID == id);
            if (request == null)
            {
                return NotFound();
            }
            return View(request);
        }

        // Action method để duyệt yêu cầu
        public IActionResult Approve(int id)
        { 
            var request = _context.Requests.FirstOrDefault(r => r.requestID == id);
            var accountid = request.accountID;

            var roomType = request.roomTypeID;

            var room = _context.Rooms.FirstOrDefault(r => r.roomTypeID == roomType && r.RoomType.roomLeft > 0);

            var rt = _context.RoomTypes.FirstOrDefault(r => r.roomTypeID == roomType);
            rt.roomLeft--;
            var enrollment = new Enrollment
            {
                accountID = accountid,
                roomID = room.roomID,
                dateOfReceipt = DateTime.Now,

            };
            
            _context.Enrollments.Add(enrollment);
            request.status = "Apply";

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        // Action method để hủy yêu cầu
        public IActionResult Cancel(int id)
        {
            var request = _context.Requests.FirstOrDefault(r => r.requestID == id);
            if (request == null)
            {
                return NotFound();
            }

            request.status = "Cancelled";
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
