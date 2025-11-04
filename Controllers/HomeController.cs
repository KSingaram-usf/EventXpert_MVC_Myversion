using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventXpert.Data;

namespace EventXpert.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Home page (was index.html)
        public async Task<IActionResult> Index()
        {
            // show 5 upcoming events sorted by date
            var topEvents = await _context.Events
                .OrderBy(e => e.Date)
                .Take(5)
                .ToListAsync();

            return View(topEvents);
        }

        // Data Visualization page (was data.html)
        public async Task<IActionResult> Data()
        {
            var allEvents = await _context.Events
                .OrderBy(e => e.Date)
                .ToListAsync();

            return View(allEvents);
        }

        // About page (was about.html)
        public IActionResult About()
        {
            return View();
        }
    }
}
