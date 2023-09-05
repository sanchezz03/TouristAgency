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
    public class PopularExcursionsController : Controller
    {
        private readonly TouristAgencyContext _context;

        public PopularExcursionsController(TouristAgencyContext context)
        {
            _context = context;
        }

        // GET: PopularExcursions
        public async Task<IActionResult> Index()
        {
              return _context.PopularExcursions != null ? 
                          View(await _context.PopularExcursions.ToListAsync()) :
                          Problem("Entity set 'TouristAgencyContext.PopularExcursions'  is null.");
        }

        // GET: PopularExcursions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PopularExcursions == null)
            {
                return NotFound();
            }

            var popularExcursion = await _context.PopularExcursions
                .FirstOrDefaultAsync(m => m.ExcursionId == id);
            if (popularExcursion == null)
            {
                return NotFound();
            }

            return View(popularExcursion);
        }

        // GET: PopularExcursions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PopularExcursions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExcursionId,ExcursionRating")] PopularExcursion popularExcursion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(popularExcursion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(popularExcursion);
        }

        // GET: PopularExcursions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PopularExcursions == null)
            {
                return NotFound();
            }

            var popularExcursion = await _context.PopularExcursions.FindAsync(id);
            if (popularExcursion == null)
            {
                return NotFound();
            }
            return View(popularExcursion);
        }

        // POST: PopularExcursions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExcursionId,ExcursionRating")] PopularExcursion popularExcursion)
        {
            if (id != popularExcursion.ExcursionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(popularExcursion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PopularExcursionExists(popularExcursion.ExcursionId))
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
            return View(popularExcursion);
        }

        // GET: PopularExcursions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PopularExcursions == null)
            {
                return NotFound();
            }

            var popularExcursion = await _context.PopularExcursions
                .FirstOrDefaultAsync(m => m.ExcursionId == id);
            if (popularExcursion == null)
            {
                return NotFound();
            }

            return View(popularExcursion);
        }

        // POST: PopularExcursions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PopularExcursions == null)
            {
                return Problem("Entity set 'TouristAgencyContext.PopularExcursions'  is null.");
            }
            var popularExcursion = await _context.PopularExcursions.FindAsync(id);
            if (popularExcursion != null)
            {
                _context.PopularExcursions.Remove(popularExcursion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PopularExcursionExists(int id)
        {
          return (_context.PopularExcursions?.Any(e => e.ExcursionId == id)).GetValueOrDefault();
        }
    }
}
