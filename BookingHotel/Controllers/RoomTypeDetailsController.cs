using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookingHotel.Data;
using BookingHotel.Models;

namespace BookingHotel.Controllers
{
    public class RoomTypeDetailsController : Controller
    {
        private readonly HotelContext _context;

        public RoomTypeDetailsController(HotelContext context)
        {
            _context = context;
        }

        // GET: RoomTypeDetails
        public async Task<IActionResult> Index()
        {
            var hotelContext = _context.RoomTypeDetails.Include(r => r.RoomType);
            return View(await hotelContext.ToListAsync());
        }

        // GET: RoomTypeDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RoomTypeDetails == null)
            {
                return NotFound();
            }

            var roomTypeDetail = await _context.RoomTypeDetails
                .Include(r => r.RoomType)
                .FirstOrDefaultAsync(m => m.roomTypeDetailID == id);
            if (roomTypeDetail == null)
            {
                return NotFound();
            }

            return View(roomTypeDetail);
        }

        // GET: RoomTypeDetails/Create
        public IActionResult Create()
        {
            ViewData["roomTypeID"] = new SelectList(_context.RoomTypes, "roomTypeID", "roomTypeID");
            return View();
        }

        // POST: RoomTypeDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("roomTypeDetailID,roomTypeID,description,maxPeople,view,size,bed")] RoomTypeDetail roomTypeDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomTypeDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["roomTypeID"] = new SelectList(_context.RoomTypes, "roomTypeID", "roomTypeID", roomTypeDetail.roomTypeID);
            return View(roomTypeDetail);
        }

        // GET: RoomTypeDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RoomTypeDetails == null)
            {
                return NotFound();
            }

            var roomTypeDetail = await _context.RoomTypeDetails.FindAsync(id);
            if (roomTypeDetail == null)
            {
                return NotFound();
            }
            ViewData["roomTypeID"] = new SelectList(_context.RoomTypes, "roomTypeID", "roomTypeID", roomTypeDetail.roomTypeID);
            return View(roomTypeDetail);
        }

        // POST: RoomTypeDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("roomTypeDetailID,roomTypeID,description,maxPeople,view,size,bed")] RoomTypeDetail roomTypeDetail)
        {
            if (id != roomTypeDetail.roomTypeDetailID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomTypeDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomTypeDetailExists(roomTypeDetail.roomTypeDetailID))
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
            ViewData["roomTypeID"] = new SelectList(_context.RoomTypes, "roomTypeID", "roomTypeID", roomTypeDetail.roomTypeID);
            return View(roomTypeDetail);
        }

        // GET: RoomTypeDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RoomTypeDetails == null)
            {
                return NotFound();
            }

            var roomTypeDetail = await _context.RoomTypeDetails
                .Include(r => r.RoomType)
                .FirstOrDefaultAsync(m => m.roomTypeDetailID == id);
            if (roomTypeDetail == null)
            {
                return NotFound();
            }

            return View(roomTypeDetail);
        }

        // POST: RoomTypeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RoomTypeDetails == null)
            {
                return Problem("Entity set 'HotelContext.RoomTypeDetails'  is null.");
            }
            var roomTypeDetail = await _context.RoomTypeDetails.FindAsync(id);
            if (roomTypeDetail != null)
            {
                _context.RoomTypeDetails.Remove(roomTypeDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomTypeDetailExists(int id)
        {
          return _context.RoomTypeDetails.Any(e => e.roomTypeDetailID == id);
        }
    }
}
