using Microsoft.AspNetCore.Mvc;
using OnlineStoreProject.Models;
using OnlineStoreProject.Models.Database;
using OnlineStoreProject.Models.ViewModels;
using System.Diagnostics;

namespace OnlineStoreProject.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _context.Users.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
