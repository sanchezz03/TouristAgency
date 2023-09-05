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
    public class ExpensesIncomesController : Controller
    {
        private readonly TouristAgencyContext _context;

        public ExpensesIncomesController(TouristAgencyContext context)
        {
            _context = context;
        }

        // GET: ExpensesIncomes
        public async Task<IActionResult> Index()
        {
              return _context.ExpensesIncomes != null ? 
                          View(await _context.ExpensesIncomes.ToListAsync()) :
                          Problem("Entity set 'TouristAgencyContext.ExpensesIncomes'  is null.");
        }

        // GET: ExpensesIncomes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExpensesIncomes == null)
            {
                return NotFound();
            }

            var expensesIncome = await _context.ExpensesIncomes
                .FirstOrDefaultAsync(m => m.RecordId == id);
            if (expensesIncome == null)
            {
                return NotFound();
            }

            return View(expensesIncome);
        }

        // GET: ExpensesIncomes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExpensesIncomes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecordId,ServiceName,TransactionDate,Amount,ExpenseIncomeType")] ExpensesIncome expensesIncome)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expensesIncome);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expensesIncome);
        }

        // GET: ExpensesIncomes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExpensesIncomes == null)
            {
                return NotFound();
            }

            var expensesIncome = await _context.ExpensesIncomes.FindAsync(id);
            if (expensesIncome == null)
            {
                return NotFound();
            }
            return View(expensesIncome);
        }

        // POST: ExpensesIncomes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecordId,ServiceName,TransactionDate,Amount,ExpenseIncomeType")] ExpensesIncome expensesIncome)
        {
            if (id != expensesIncome.RecordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expensesIncome);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpensesIncomeExists(expensesIncome.RecordId))
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
            return View(expensesIncome);
        }

        // GET: ExpensesIncomes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExpensesIncomes == null)
            {
                return NotFound();
            }

            var expensesIncome = await _context.ExpensesIncomes
                .FirstOrDefaultAsync(m => m.RecordId == id);
            if (expensesIncome == null)
            {
                return NotFound();
            }

            return View(expensesIncome);
        }

        // POST: ExpensesIncomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExpensesIncomes == null)
            {
                return Problem("Entity set 'TouristAgencyContext.ExpensesIncomes'  is null.");
            }
            var expensesIncome = await _context.ExpensesIncomes.FindAsync(id);
            if (expensesIncome != null)
            {
                _context.ExpensesIncomes.Remove(expensesIncome);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpensesIncomeExists(int id)
        {
          return (_context.ExpensesIncomes?.Any(e => e.RecordId == id)).GetValueOrDefault();
        }
    }
}
