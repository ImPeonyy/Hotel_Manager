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
            var request = _context.Requests.Include(r => r.Account)
                .ThenInclude(r => r.Enrollment)
                .ThenInclude(e => e.Room)
                .Include(r => r.RoomType).FirstOrDefault(r => r.requestID == id);
            if (request == null)
            {
                return NotFound();
            }
            return View(request);
        }
        public IActionResult Approve(int id)
        {
            // Lấy thông tin request và danh sách phòng thỏa mãn điều kiện
            var request = _context.Requests.Include(r => r.RoomType).FirstOrDefault(r => r.requestID == id);
            if (request == null)
            {
                return NotFound();
            }

            var availableRooms = _context.Rooms
                .Where(r => r.roomTypeID == request.roomTypeID && r.status == "Empty")
                .ToList();

            // Tạo View Model để truyền dữ liệu ra View
            var viewModel = new ApproveViewModel
            {
                Request = request,
                AvailableRooms = availableRooms
            };

            return View(viewModel);
        }

        // Action method để duyệt yêu cầu
        [HttpPost]
        public IActionResult ConfirmApprove(int requestId, int roomId)
        {
            // Lấy request và room dựa trên ID
            var request = _context.Requests.FirstOrDefault(r => r.requestID == requestId);
            var room = _context.Rooms.FirstOrDefault(r => r.roomID == roomId);

            if (request == null || room == null)
            {
                return NotFound(); 
            }

            // Tạo và lưu Enrollment 
            var enrollment = new Enrollment
            {
                accountID = request.accountID,
                roomID = roomId,
                dateOfReceipt = DateTime.Now
            };

            _context.Enrollments.Add(enrollment);

            // Cập nhật trạng thái request và phòng
            request.status = "Apply";
            room.status = "Occupied";

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
            var roomType = _context.RoomTypes.FirstOrDefault(rt => rt.roomTypeID == request.roomTypeID);
            if (roomType != null)
            {              
                roomType.roomLeft += 1;
            }


            request.status = "Cancelled";
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
