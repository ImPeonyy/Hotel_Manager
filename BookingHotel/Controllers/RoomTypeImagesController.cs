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
    public class RoomTypeImagesController : Controller
    {
        private readonly HotelContext _context;

        public RoomTypeImagesController(HotelContext context)
        {
            _context = context;
        }

        // GET: RoomTypeImages
        public async Task<IActionResult> Index()
        {
            var hotelContext = _context.roomTypeImages.Include(r => r.RoomTypeDetail);
            return View(await hotelContext.ToListAsync());
        }

        // GET: RoomTypeImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.roomTypeImages == null)
            {
                return NotFound();
            }

            var roomTypeImage = await _context.roomTypeImages
                .Include(r => r.RoomTypeDetail)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (roomTypeImage == null)
            {
                return NotFound();
            }

            return View(roomTypeImage);
        }

        // GET: RoomTypeImages/Create
        public IActionResult Create()
        {
            ViewData["roomTypeDetailID"] = new SelectList(_context.RoomTypeDetails, "roomTypeDetailID", "roomTypeDetailID");
            return View();
        }

        // POST: RoomTypeImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,roomTypeDetailID,imagePath")] RoomTypeImage roomTypeImage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomTypeImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["roomTypeDetailID"] = new SelectList(_context.RoomTypeDetails, "roomTypeDetailID", "roomTypeDetailID", roomTypeImage.roomTypeDetailID);
            return View(roomTypeImage);
        }

        // GET: RoomTypeImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.roomTypeImages == null)
            {
                return NotFound();
            }

            var roomTypeImage = await _context.roomTypeImages.FindAsync(id);
            if (roomTypeImage == null)
            {
                return NotFound();
            }
            ViewData["roomTypeDetailID"] = new SelectList(_context.RoomTypeDetails, "roomTypeDetailID", "roomTypeDetailID", roomTypeImage.roomTypeDetailID);
            return View(roomTypeImage);
        }

        // POST: RoomTypeImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,roomTypeDetailID,imagePath")] RoomTypeImage roomTypeImage)
        {
            if (id != roomTypeImage.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomTypeImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomTypeImageExists(roomTypeImage.ID))
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
            ViewData["roomTypeDetailID"] = new SelectList(_context.RoomTypeDetails, "roomTypeDetailID", "roomTypeDetailID", roomTypeImage.roomTypeDetailID);
            return View(roomTypeImage);
        }

        // GET: RoomTypeImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.roomTypeImages == null)
            {
                return NotFound();
            }

            var roomTypeImage = await _context.roomTypeImages
                .Include(r => r.RoomTypeDetail)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (roomTypeImage == null)
            {
                return NotFound();
            }

            return View(roomTypeImage);
        }

        // POST: RoomTypeImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.roomTypeImages == null)
            {
                return Problem("Entity set 'HotelContext.roomTypeImages'  is null.");
            }
            var roomTypeImage = await _context.roomTypeImages.FindAsync(id);
            if (roomTypeImage != null)
            {
                _context.roomTypeImages.Remove(roomTypeImage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomTypeImageExists(int id)
        {
          return _context.roomTypeImages.Any(e => e.ID == id);
        }
    }
}
