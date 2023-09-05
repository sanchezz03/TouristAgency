﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TouristAgency.Models;

namespace TouristAgency.Controllers
{
    public class CargoesController : Controller
    {
        private readonly TouristAgencyContext _context;

        public CargoesController(TouristAgencyContext context)
        {
            _context = context;
        }

        // GET: Cargoes
        public async Task<IActionResult> Index()
        {
            var touristAgencyContext = _context.Cargos.Include(c => c.Flight);
            return View(await touristAgencyContext.ToListAsync());
        }

        // GET: Cargoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cargos == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargos
                .Include(c => c.Flight)
                .FirstOrDefaultAsync(m => m.CargoId == id);
            if (cargo == null)
            {
                return NotFound();
            }

            return View(cargo);
        }

        // GET: Cargoes/Create
        public IActionResult Create()
        {
            ViewData["FlightId"] = new SelectList(_context.Flights, "FlightId", "FlightId");
            return View();
        }

        // POST: Cargoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CargoId,FlightId,CargoWeight,CargoType")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cargo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FlightId"] = new SelectList(_context.Flights, "FlightId", "FlightId", cargo.FlightId);
            return View(cargo);
        }

        // GET: Cargoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cargos == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargos.FindAsync(id);
            if (cargo == null)
            {
                return NotFound();
            }
            ViewData["FlightId"] = new SelectList(_context.Flights, "FlightId", "FlightId", cargo.FlightId);
            return View(cargo);
        }

        // POST: Cargoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CargoId,FlightId,CargoWeight,CargoType")] Cargo cargo)
        {
            if (id != cargo.CargoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cargo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CargoExists(cargo.CargoId))
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
            ViewData["FlightId"] = new SelectList(_context.Flights, "FlightId", "FlightId", cargo.FlightId);
            return View(cargo);
        }

        // GET: Cargoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cargos == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargos
                .Include(c => c.Flight)
                .FirstOrDefaultAsync(m => m.CargoId == id);
            if (cargo == null)
            {
                return NotFound();
            }

            return View(cargo);
        }

        // POST: Cargoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cargos == null)
            {
                return Problem("Entity set 'TouristAgencyContext.Cargos'  is null.");
            }
            var cargo = await _context.Cargos.FindAsync(id);
            if (cargo != null)
            {
                _context.Cargos.Remove(cargo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CargoExists(int id)
        {
          return (_context.Cargos?.Any(e => e.CargoId == id)).GetValueOrDefault();
        }
    }
}
