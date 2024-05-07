using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStoreProject.Models.Database;
using OnlineStoreProject.Models.ViewModels;

namespace OnlineStoreProject.Servises
{
    public class DBService
    {
        private readonly ApplicationContext _appllicationContext;

        public DBService(ApplicationContext appllicationContext)
        {
            _appllicationContext = appllicationContext;
        }

        public List<CategoryViewModel> GetProductCategories()
        {
            var categories = _appllicationContext.ProductCategories
                .Where(c => c.PreviousCategoryId == null)
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    CategoryName = c.CategoryName,
                    Subcategories = GetProductSubcategories(c.Id)
                })
                .ToList();

            return categories;
        }

        private List<CategoryViewModel>? GetProductSubcategories(int parentId)
        {
            var subcategories = _appllicationContext.ProductCategories
                .Where(c => c.PreviousCategoryId == parentId)
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    CategoryName = c.CategoryName,
                    Subcategories = GetProductSubcategories(c.Id)
                })
                .ToList();

            return subcategories.Any() ? subcategories : null;
        }

        public IQueryable<Product> GetProductsQuery(int categoryId)
        {
            return _appllicationContext.Products
                .Where(p => p.ProductCategoryId == categoryId || p.ProductCategory.PreviousCategoryId == categoryId).Include(p => p.ProductPhotos);
        }
    }
}
