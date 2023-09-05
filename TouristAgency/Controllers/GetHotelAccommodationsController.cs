using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TouristAgency.Models;

namespace TouristAgency.Controllers
{
    public class GetHotelAccommodationsController : Controller
    {
        private readonly TouristAgencyContext _context;

        public GetHotelAccommodationsController(TouristAgencyContext context)
        {
            _context = context;
        }

        // GET: CountOfDrivers
        public async Task<IActionResult> Index(int category_id = 1)
        {
            string procedureName = "GetHotelAccommodations @PID";
            SqlParameter sqlParameter = new SqlParameter("@PID", category_id);

            var result = await _context.GetHotelAccommodationss.FromSqlRaw(procedureName, sqlParameter).ToListAsync();

            return View(result);
        }
    }
}
