using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStoreProject.Areas.Editing.Models;
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
            Subcategories = GetProductSubcategories(c.Id, _appllicationContext)
        })
        .ToList();

            return categories;
        }

        private static List<CategoryViewModel> GetProductSubcategories(int parentId, ApplicationContext applicationContext)
        {
            var subcategories = applicationContext.ProductCategories
                .Where(c => c.PreviousCategoryId == parentId)
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    CategoryName = c.CategoryName,
                    Subcategories = GetProductSubcategories(c.Id, applicationContext)
                })
                .ToList();

            return subcategories;
        }

        public List<CategoryWithProductsViewModel> GetProductCategoriesWithProducts()
        {
            var categories = _appllicationContext.ProductCategories
            .Where(c => c.PreviousCategoryId == null)
            .Include(c => c.Products)
            .Select(c => new CategoryWithProductsViewModel
            {
                Id = c.Id,
                CategoryName = c.CategoryName,
                Products = c.Products.ToList(),
                Subcategories = GetProductSubcategoriesWithProducts(c.Id, _appllicationContext)
            })
            .ToList();

            return categories;
        }

        private static List<CategoryWithProductsViewModel> GetProductSubcategoriesWithProducts(int parentId, ApplicationContext applicationContext)
        {
            var subcategories = applicationContext.ProductCategories
                .Where(c => c.PreviousCategoryId == parentId)
                .Select(c => new CategoryWithProductsViewModel
                {
                    Id = c.Id,
                    CategoryName = c.CategoryName,
                    Products = c.Products.ToList(),
                    Subcategories = GetProductSubcategoriesWithProducts(c.Id, applicationContext)
                })
                .ToList();

            return subcategories;
        }

        public IQueryable<Product> GetProductsQuerry(int categoryId)
        {
            return _appllicationContext.Products
                .Where(p => p.ProductCategoryId == categoryId || p.ProductCategory.PreviousCategoryId == categoryId)
                .Where(p => p.Quantity > 0)
                .Include(p => p.ProductPhotos);
        }
    }
}
