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

        public List<CategoryViewModel> GetProductCategoriesViewModel()
        {
            var categories = _appllicationContext.ProductCategories.ToList(); 

            var rootCategories = categories
                .Where(c => c.PreviousCategoryId == null)
                .Select(c => MapCategory(c, categories))
                .ToList();

            return rootCategories;
        }

        private static CategoryViewModel MapCategory(ProductCategory category, List<ProductCategory> allCategories)
        {
            return new CategoryViewModel
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                Subcategories = allCategories
                    .Where(c => c.PreviousCategoryId == category.Id)
                    .Select(c => MapCategory(c, allCategories))
                    .ToList()
            };
        }

        public IQueryable<Product> GetProductsQuerry(int categoryId)
        {
            return _appllicationContext.Products
                .Where(p => p.ProductCategoryId == categoryId || p.ProductCategory.PreviousCategoryId == categoryId)
                .Where(p => p.Quantity > 0)
                .Include(p => p.ProductPhotos);
        }

        public async Task AddCategoryAsync(ProductCategory category)
        {
            _appllicationContext.ProductCategories.Add(category);
            await _appllicationContext.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(ProductCategory category)
        {
            _appllicationContext.ProductCategories.Update(category);
            await _appllicationContext.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var category = await _appllicationContext.ProductCategories.FindAsync(categoryId);
            if (category != null)
            {
                _appllicationContext.ProductCategories.Remove(category);
                await _appllicationContext.SaveChangesAsync();
            }
        }

        public async Task AddProductAsync(Product product)
        {
            _appllicationContext.Products.Add(product);
            await _appllicationContext.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _appllicationContext.Products.Update(product);
            await _appllicationContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateProductAsync(int id, string name, string description, decimal price)
        {
            var product = await _appllicationContext.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }

            product.Name = name;
            product.Description = description;
            product.Price = price;

            await _appllicationContext.SaveChangesAsync();
            return true;
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await _appllicationContext.Products.FindAsync(productId);
            if (product != null)
            {
                _appllicationContext.Products.Remove(product);
                await _appllicationContext.SaveChangesAsync();
            }
        }

        internal async Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            return await _appllicationContext.Products.Where(p => p.ProductCategoryId == categoryId).ToListAsync();
        }
    }
}
