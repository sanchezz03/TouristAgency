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
    public class ExcursionAgenciesController : Controller
    {
        private readonly TouristAgencyContext _context;

        public ExcursionAgenciesController(TouristAgencyContext context)
        {
            _context = context;
        }

        // GET: ExcursionAgencies
        public async Task<IActionResult> Index()
        {
              return _context.ExcursionAgencies != null ? 
                          View(await _context.ExcursionAgencies.ToListAsync()) :
                          Problem("Entity set 'TouristAgencyContext.ExcursionAgencies'  is null.");
        }

        // GET: ExcursionAgencies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExcursionAgencies == null)
            {
                return NotFound();
            }

            var excursionAgency = await _context.ExcursionAgencies
                .FirstOrDefaultAsync(m => m.AgencyId == id);
            if (excursionAgency == null)
            {
                return NotFound();
            }

            return View(excursionAgency);
        }

        // GET: ExcursionAgencies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExcursionAgencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AgencyId,AgencyName,AgencyAddress,AgencyPhoneNumber")] ExcursionAgency excursionAgency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(excursionAgency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(excursionAgency);
        }

        // GET: ExcursionAgencies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExcursionAgencies == null)
            {
                return NotFound();
            }

            var excursionAgency = await _context.ExcursionAgencies.FindAsync(id);
            if (excursionAgency == null)
            {
                return NotFound();
            }
            return View(excursionAgency);
        }

        // POST: ExcursionAgencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AgencyId,AgencyName,AgencyAddress,AgencyPhoneNumber")] ExcursionAgency excursionAgency)
        {
            if (id != excursionAgency.AgencyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(excursionAgency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExcursionAgencyExists(excursionAgency.AgencyId))
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
            return View(excursionAgency);
        }

        // GET: ExcursionAgencies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExcursionAgencies == null)
            {
                return NotFound();
            }

            var excursionAgency = await _context.ExcursionAgencies
                .FirstOrDefaultAsync(m => m.AgencyId == id);
            if (excursionAgency == null)
            {
                return NotFound();
            }

            return View(excursionAgency);
        }

        // POST: ExcursionAgencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExcursionAgencies == null)
            {
                return Problem("Entity set 'TouristAgencyContext.ExcursionAgencies'  is null.");
            }
            var excursionAgency = await _context.ExcursionAgencies.FindAsync(id);
            if (excursionAgency != null)
            {
                _context.ExcursionAgencies.Remove(excursionAgency);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExcursionAgencyExists(int id)
        {
          return (_context.ExcursionAgencies?.Any(e => e.AgencyId == id)).GetValueOrDefault();
        }
    }
}
