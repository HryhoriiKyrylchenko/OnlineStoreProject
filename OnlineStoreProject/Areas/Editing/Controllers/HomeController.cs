using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreProject.Servises;

namespace OnlineStoreProject.Areas.Editing.Controllers
{
    [Area("Editing")]
    public class HomeController : Controller
    {
        private DBService _dbService;

        public HomeController(DBService dbService)
        {
            _dbService = dbService;
        }

        [Authorize(Policy = "AdminOnly")]
        public IActionResult Index()
        {
            var categories = _dbService.GetProductCategoriesWithProducts();
            return View(categories);
        }
    }
}
