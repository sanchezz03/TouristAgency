using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TouristAgency.Models;

namespace TouristAgency.Controllers
{
    public class GetCargoStatisticsController : Controller
    {
        private readonly TouristAgencyContext _context;
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;
        public GetCargoStatisticsController(TouristAgencyContext context)
        {
            _context = context;
            _startDate = new DateTime(2023, 8, 1);
            _endDate = new DateTime(2023, 8, 31);
        }

       
        public async Task<IActionResult> Index()
        {
            var parameters = new[]
            {
                new SqlParameter("@startDate", _startDate),
                new SqlParameter("@endDate", _endDate)
            };

            var query = @"SELECT * FROM dbo.GetCargoStatistics(@startDate, @endDate);";

            var clients = await _context.GetCargoStatistics.FromSqlRaw(query, parameters).ToListAsync();

            return View(clients);
        }
    }
}
