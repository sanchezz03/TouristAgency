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
    public class ExcursionsController : Controller
    {
        private readonly TouristAgencyContext _context;

        public ExcursionsController(TouristAgencyContext context)
        {
            _context = context;
        }

        // GET: Excursions
        public async Task<IActionResult> Index()
        {
            var touristAgencyContext = _context.Excursions.Include(e => e.Agency);
            return View(await touristAgencyContext.ToListAsync());
        }

        // GET: Excursions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Excursions == null)
            {
                return NotFound();
            }

            var excursion = await _context.Excursions
                .Include(e => e.Agency)
                .FirstOrDefaultAsync(m => m.ExcursionId == id);
            if (excursion == null)
            {
                return NotFound();
            }

            return View(excursion);
        }

        // GET: Excursions/Create
        public IActionResult Create()
        {
            ViewData["AgencyId"] = new SelectList(_context.ExcursionAgencies, "AgencyId", "AgencyId");
            return View();
        }

        // POST: Excursions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExcursionId,ExcursionName,ExcursionDate,ExcursionDescription,ExcursionCost,AgencyId")] Excursion excursion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(excursion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgencyId"] = new SelectList(_context.ExcursionAgencies, "AgencyId", "AgencyId", excursion.AgencyId);
            return View(excursion);
        }

        // GET: Excursions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Excursions == null)
            {
                return NotFound();
            }

            var excursion = await _context.Excursions.FindAsync(id);
            if (excursion == null)
            {
                return NotFound();
            }
            ViewData["AgencyId"] = new SelectList(_context.ExcursionAgencies, "AgencyId", "AgencyId", excursion.AgencyId);
            return View(excursion);
        }

        // POST: Excursions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExcursionId,ExcursionName,ExcursionDate,ExcursionDescription,ExcursionCost,AgencyId")] Excursion excursion)
        {
            if (id != excursion.ExcursionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(excursion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExcursionExists(excursion.ExcursionId))
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
            ViewData["AgencyId"] = new SelectList(_context.ExcursionAgencies, "AgencyId", "AgencyId", excursion.AgencyId);
            return View(excursion);
        }

        // GET: Excursions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Excursions == null)
            {
                return NotFound();
            }

            var excursion = await _context.Excursions
                .Include(e => e.Agency)
                .FirstOrDefaultAsync(m => m.ExcursionId == id);
            if (excursion == null)
            {
                return NotFound();
            }

            return View(excursion);
        }

        // POST: Excursions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Excursions == null)
            {
                return Problem("Entity set 'TouristAgencyContext.Excursions'  is null.");
            }
            var excursion = await _context.Excursions.FindAsync(id);
            if (excursion != null)
            {
                _context.Excursions.Remove(excursion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExcursionExists(int id)
        {
          return (_context.Excursions?.Any(e => e.ExcursionId == id)).GetValueOrDefault();
        }
    }
}
