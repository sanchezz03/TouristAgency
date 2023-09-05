using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TouristAgency.Models;

namespace TouristAgency.Controllers
{
    public class GetFlightLoadingDataController : Controller
    {
        private readonly TouristAgencyContext _context;
        private readonly DateTime _date;
        public GetFlightLoadingDataController(TouristAgencyContext context)
        {
            _context = context;
            _date = new DateTime(2023, 8, 15);
        }

        public async Task<IActionResult> Index(string flight_number = "PS101")
        {
            var parameters = new[]
            {
                new SqlParameter("@flight_number", flight_number),
                new SqlParameter("@date", _date)
            };

            var query = @"SELECT *FROM GetFlightLoadingData(@flight_number, @date);";

            var clients = await _context.GetFlightLoadingDatas.FromSqlRaw(query, parameters).ToListAsync();

            return View(clients);
        }
    }
}
