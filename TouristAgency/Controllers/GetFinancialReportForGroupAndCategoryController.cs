using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TouristAgency.Models;

namespace TouristAgency.Controllers
{
    public class GetFinancialReportForGroupAndCategoryController : Controller
    {
        private readonly TouristAgencyContext _context;

        public GetFinancialReportForGroupAndCategoryController(TouristAgencyContext context)
        {
            _context = context;
        }

        // GET: CountOfDrivers
        public async Task<IActionResult> Index(string groupName = "Group A", string categoryName = "Сімейний")
        {
            var parameters = new[]
            {
                new SqlParameter("@groupName", groupName),
                new SqlParameter("@categoryName", categoryName)
            };

            var query = @"GetFinancialReportForGroupAndCategory @groupName, @categoryName;";

            var clients = await _context.GetFinancialReportForGroupAndCategories.FromSqlRaw(query, parameters).ToListAsync();

            return View(clients);
        }
    }
}
