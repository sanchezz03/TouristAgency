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
    public class LuggagesController : Controller
    {
        private readonly TouristAgencyContext _context;

        public LuggagesController(TouristAgencyContext context)
        {
            _context = context;
        }

        // GET: Luggages
        public async Task<IActionResult> Index()
        {
              return _context.Luggage != null ? 
                          View(await _context.Luggage.ToListAsync()) :
                          Problem("Entity set 'TouristAgencyContext.Luggage'  is null.");
        }

        // GET: Luggages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Luggage == null)
            {
                return NotFound();
            }

            var luggage = await _context.Luggage
                .FirstOrDefaultAsync(m => m.LuggageId == id);
            if (luggage == null)
            {
                return NotFound();
            }

            return View(luggage);
        }

        // GET: Luggages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Luggages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LuggageId,LuggageWeight,LuggageType")] Luggage luggage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(luggage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(luggage);
        }

        // GET: Luggages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Luggage == null)
            {
                return NotFound();
            }

            var luggage = await _context.Luggage.FindAsync(id);
            if (luggage == null)
            {
                return NotFound();
            }
            return View(luggage);
        }

        // POST: Luggages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LuggageId,LuggageWeight,LuggageType")] Luggage luggage)
        {
            if (id != luggage.LuggageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(luggage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LuggageExists(luggage.LuggageId))
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
            return View(luggage);
        }

        // GET: Luggages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Luggage == null)
            {
                return NotFound();
            }

            var luggage = await _context.Luggage
                .FirstOrDefaultAsync(m => m.LuggageId == id);
            if (luggage == null)
            {
                return NotFound();
            }

            return View(luggage);
        }

        // POST: Luggages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Luggage == null)
            {
                return Problem("Entity set 'TouristAgencyContext.Luggage'  is null.");
            }
            var luggage = await _context.Luggage.FindAsync(id);
            if (luggage != null)
            {
                _context.Luggage.Remove(luggage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LuggageExists(int id)
        {
          return (_context.Luggage?.Any(e => e.LuggageId == id)).GetValueOrDefault();
        }
    }
}
