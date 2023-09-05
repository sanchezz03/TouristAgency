using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TouristAgency.Models;

namespace TouristAgency.Controllers
{
    public class GetTouristCountByCountryAndPeriodController : Controller
    {
        private readonly TouristAgencyContext _context;
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;
        public GetTouristCountByCountryAndPeriodController(TouristAgencyContext context)
        {
            _context = context;
            _startDate = new DateTime(2023, 3, 1);
            _endDate = new DateTime(2023, 3, 31);
        }

        // GET: CountOfDrivers
        public async Task<IActionResult> Index(int country_id = 1)
        {
            var parameters = new[]
            {
                new SqlParameter("@CountryID", country_id),
                new SqlParameter("@StartDate", _startDate),
                new SqlParameter("@EndDate", _endDate)
            };

            var query = @"EXEC GetTouristCountByCountryAndPeriod @CountryID, @StartDate, @EndDate;";

            var clients = await _context.GetTouristCountByCountryAndPeriods.FromSqlRaw(query, parameters).ToListAsync();

            return View(clients);
        }
    }
}
