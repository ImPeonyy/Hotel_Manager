using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookingHotel.Data;
using BookingHotel.Models;
using System.Diagnostics;
using BookingHotel.Models.RoomViewModels;
using Microsoft.Data.SqlClient;

namespace BookingHotel.Controllers
{
    public class RoomsController : Controller
    {
        private readonly HotelContext _context;

        public RoomsController(HotelContext context)
        {
            _context = context;
        }

        // GET: Rooms
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["RoomTypeSortParm"] = String.IsNullOrEmpty(sortOrder) ? "roomType_desc" : "";
            ViewData["StatusSortParm"] = String.IsNullOrEmpty(sortOrder) ? "status_desc" : "status";
            ViewData["CurrentFilter"] = searchString;

            var rooms = from r in _context.Rooms select r;

            if (!String.IsNullOrEmpty(searchString))
            {
                rooms = rooms.Where(s => s.roomName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "roomType_desc":
                    rooms = rooms.OrderByDescending(r => r.roomTypeID);
                    break;
                case "status_desc":
                    rooms = rooms.OrderByDescending(r => r.status);
                    break;
                case "status":
                    rooms = rooms.OrderBy(r => r.status);
                    break;
                default:
                    rooms = rooms.OrderBy(r => r.roomName);
                    break;
            }

            return View(await rooms
            .Include(r => r.RoomType)
            .AsNoTracking().ToListAsync());
            //return View(await _context.Rooms.ToListAsync());
        }

        //GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }
            var code = _context.Rooms.Where(r => r.roomID == id)
                        .Select(r => r.roomTypeID).ToList();

            var room = await _context.Rooms
                .Include(r => r.RoomType)
                    .ThenInclude(rt => rt.RoomTypeDetail)
                .Include(r => r.Enrollment)
                    .ThenInclude(a => a.Account)
                        .ThenInclude(rq => rq.Requests)
                    .AsNoTracking()
                .FirstOrDefaultAsync(r => r.roomID == id);

            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Rooms == null)
        //    {
        //        return NotFound();
        //    }

        //    var viewModel = new RoomDetailData();
        //    viewModel.Rooms =  await _context.Rooms
        //        .Include(r => r.RoomType)
        //        .Include(r => r.Enrollment)
        //            .ThenInclude(r => r.Account)
        //        .Include(r => r.Enrollment)
        //            .ThenInclude(r => r.Account)   
        //        .AsNoTracking()
        //        .OrderBy(r => r.roomName)
        //        .ToListAsync();

        //    if (viewModel == null)
        //    {
        //        return NotFound();
        //    }



        //    return View(viewModel);
        //}

        // GET: Rooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("roomID,roomName,roomTypeID,guest")] Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("roomID,roomName,roomTypeID,guest")] Room room)
        {
            if (id != room.roomID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.roomID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .FirstOrDefaultAsync(m => m.roomID == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rooms == null)
            {
                return Problem("Entity set 'HotelContext.Rooms'  is null.");
            }
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
          return _context.Rooms.Any(e => e.roomID == id);
        }
    }
}
