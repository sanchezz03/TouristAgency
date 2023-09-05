using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TouristAgency.Models;

namespace TouristAgency.Controllers
{
    public class GetExpensesIncomesForPeriodController : Controller
    {
        private readonly TouristAgencyContext _context;
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;
        public GetExpensesIncomesForPeriodController(TouristAgencyContext context)
        {
            _context = context;
            _startDate = new DateTime(2023, 1, 1);
            _endDate = new DateTime(2023, 11, 30);
        }

        // GET: CountOfDrivers
        public async Task<IActionResult> Index()
        {
            var parameters = new[]
            {
                new SqlParameter("@startDate", _startDate),
                new SqlParameter("@endDate", _endDate)
            };

            var query = @"SELECT * 
FROM FinancialInfo.GetExpensesIncomesForPeriod (@startDate, @endDate);";

            var clients = await _context.GetExpensesIncomesForPeriods.FromSqlRaw(query, parameters).ToListAsync();

            return View(clients);
        }
    }
}
