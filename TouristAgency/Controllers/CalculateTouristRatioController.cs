using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TouristAgency.Models;

namespace TouristAgency.Controllers
{
    public class CalculateTouristRatioController : Controller
    {
        private readonly TouristAgencyContext _context;
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;
        public CalculateTouristRatioController(TouristAgencyContext context)
        {
            _context = context;
            _startDate = new DateTime(2023, 8, 15);
            _endDate = new DateTime(2023, 8, 30);
        }


        public async Task<IActionResult> Index()
        {
            var parameters = new[]
            {
                new SqlParameter("@startDate", _startDate),
                new SqlParameter("@endDate", _endDate)
            };

            var query = @"SELECT * FROM dbo.CalculateTouristRatio(@startDate, @endDate);";

            var clients = await _context.CalculateTouristRatios.FromSqlRaw(query, parameters).ToListAsync();

            return View(clients);
        }
    }
}
