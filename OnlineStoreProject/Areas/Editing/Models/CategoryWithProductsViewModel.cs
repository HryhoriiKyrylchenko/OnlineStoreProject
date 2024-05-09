using OnlineStoreProject.Models.Database;
using OnlineStoreProject.Models.ViewModels;

namespace OnlineStoreProject.Areas.Editing.Models
{
    public class CategoryWithProductsViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public List<Product>? Products { get; set; }
        public List<CategoryWithProductsViewModel>? Subcategories { get; set; }
    }
}
