using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TouristAgency.Models;

namespace TouristAgency.Controllers
{
    public class HotelCategoriesController : Controller
    {
        private readonly TouristAgencyContext _context;

        public HotelCategoriesController(TouristAgencyContext context)
        {
            _context = context;
        }

        // GET: HotelCategories
        public async Task<IActionResult> Index()
        {
              return _context.HotelCategories != null ? 
                          View(await _context.HotelCategories.ToListAsync()) :
                          Problem("Entity set 'TouristAgencyContext.HotelCategories'  is null.");
        }

        // GET: HotelCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HotelCategories == null)
            {
                return NotFound();
            }

            var hotelCategory = await _context.HotelCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (hotelCategory == null)
            {
                return NotFound();
            }

            return View(hotelCategory);
        }

        // GET: HotelCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HotelCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName")] HotelCategory hotelCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotelCategory);
        }

        // GET: HotelCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HotelCategories == null)
            {
                return NotFound();
            }

            var hotelCategory = await _context.HotelCategories.FindAsync(id);
            if (hotelCategory == null)
            {
                return NotFound();
            }
            return View(hotelCategory);
        }

        // POST: HotelCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName")] HotelCategory hotelCategory)
        {
            if (id != hotelCategory.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelCategoryExists(hotelCategory.CategoryId))
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
            return View(hotelCategory);
        }

        // GET: HotelCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HotelCategories == null)
            {
                return NotFound();
            }

            var hotelCategory = await _context.HotelCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (hotelCategory == null)
            {
                return NotFound();
            }

            return View(hotelCategory);
        }

        // POST: HotelCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HotelCategories == null)
            {
                return Problem("Entity set 'TouristAgencyContext.HotelCategories'  is null.");
            }
            var hotelCategory = await _context.HotelCategories.FindAsync(id);
            if (hotelCategory != null)
            {
                _context.HotelCategories.Remove(hotelCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelCategoryExists(int id)
        {
          return (_context.HotelCategories?.Any(e => e.CategoryId == id)).GetValueOrDefault();
        }
    }
}
