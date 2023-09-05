using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TouristAgency.Models;

namespace TouristAgency.Controllers
{
    public class GetTotalTouristsWithExcursionsByPeriodController : Controller
    {
        private readonly TouristAgencyContext _context;
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;
        public GetTotalTouristsWithExcursionsByPeriodController(TouristAgencyContext context)
        {
            _context = context;
            _startDate = new DateTime(2023, 8, 15);
            _endDate = new DateTime(2023, 8, 31);
        }

        // GET: CountOfDrivers
        public async Task<IActionResult> Index()
        {
            var parameters = new[]
            {
                new SqlParameter("@StartDate", _startDate),
                new SqlParameter("@EndDate", _endDate)
            };

            var query = @"GetTotalTouristsWithExcursionsByPeriod @StartDate, @EndDate;";

            var clients = await _context.GetTotalTouristsWithExcursionsByPeriods.FromSqlRaw(query, parameters).ToListAsync();

            return View(clients);
        }
    }
}
