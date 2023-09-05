using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TouristAgency.Models;

namespace TouristAgency.Controllers
{
    public class GetOccupiedRoomsByHotelAndPeriodController : Controller
    {
        private readonly TouristAgencyContext _context;
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;
        public GetOccupiedRoomsByHotelAndPeriodController(TouristAgencyContext context)
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

            var query = @"GetOccupiedRoomsByHotelAndPeriod @StartDate, @EndDate;";

            var clients = await _context.GetOccupiedRoomsByHotelAndPeriods.FromSqlRaw(query, parameters).ToListAsync();

            return View(clients);
        }
    }
}
