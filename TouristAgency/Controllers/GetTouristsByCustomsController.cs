using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TouristAgency.Models;

namespace TouristAgency.Controllers
{
    public class GetTouristsByCustomsController : Controller
    {
        private readonly TouristAgencyContext _context;

        public GetTouristsByCustomsController(TouristAgencyContext context)
        {
            _context = context;
        }

        // GET: CountOfDrivers
        public async Task<IActionResult> Index(int category_id = 1)
        {
            string procedureName = "GetTouristsByCustoms @PID";
            SqlParameter sqlParameter = new SqlParameter("@PID", category_id);

            var result = await _context.Tourists.FromSqlRaw(procedureName, sqlParameter).ToListAsync();

            return View(result);
        }
    }
}
