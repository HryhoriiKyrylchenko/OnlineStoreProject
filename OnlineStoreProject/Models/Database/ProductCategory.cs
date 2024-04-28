using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace OnlineStoreProject.Models.Database
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public int? PreviousCategoryId { get; set; }

        [ForeignKey("PreviousCategoryId")]
        public virtual ProductCategory? PreviousCategory { get; set; }

        public string? AdditionalInfo { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }

        public ProductCategory(string categoryName)
        {
            CategoryName = categoryName;

            Products = new List<Product>();
        }
    }
}
