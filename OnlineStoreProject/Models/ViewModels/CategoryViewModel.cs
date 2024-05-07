namespace OnlineStoreProject.Models.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public List<CategoryViewModel>? Subcategories { get; set; }
    }
}
