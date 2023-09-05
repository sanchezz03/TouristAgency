using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TouristAgency.Models;

namespace TouristAgency.Controllers
{
    public class GetLuggageStatisticsController : Controller
    {
        private readonly TouristAgencyContext _context;
        public GetLuggageStatisticsController(TouristAgencyContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var query = @"SELECT * FROM GetLuggageStatistics();";

            var clients = await _context.GetLuggageStatistics.FromSqlRaw(query).ToListAsync();

            return View(clients);
        }
    }
}
