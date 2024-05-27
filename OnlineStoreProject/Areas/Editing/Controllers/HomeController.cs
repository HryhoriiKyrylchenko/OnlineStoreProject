using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStoreProject.Models.Database;
using OnlineStoreProject.Servises;

namespace OnlineStoreProject.Areas.Editing.Controllers
{
    [Area("Editing")]
    [Authorize(Policy = "AdminOnly")]
    public class HomeController : Controller
    {
        private DBService _dbService;

        public HomeController(DBService dbService)
        {
            _dbService = dbService;
        }

        public IActionResult Index()
        {
            var categories = _dbService.GetProductCategoriesViewModel();
            return View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(string categoryName, int? parentCategoryId)
        {
            var category = new ProductCategory(categoryName)
            {
                PreviousCategoryId = parentCategoryId
            };
            await _dbService.AddCategoryAsync(category);
            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            await _dbService.DeleteCategoryAsync(categoryId);
            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(string name, string productCode, int categoryId, int warehouseId)
        {
            var product = new Product(productCode, name, warehouseId)
            {
                ProductCategoryId = categoryId
            };
            await _dbService.AddProductAsync(product);
            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            await _dbService.DeleteProductAsync(productId);
            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(int id, string name, string description, decimal price)
        {
            var result = await _dbService.UpdateProductAsync(id, name, description, price);
            if (!result)
            {
                return Json(new { success = false, message = "Product not found" });
            }

            return Json(new { success = true });
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(int categoryId)
        {
            var products = await _dbService.GetProductsByCategoryIdAsync(categoryId);
            return Json(products);
        }
    }
}
