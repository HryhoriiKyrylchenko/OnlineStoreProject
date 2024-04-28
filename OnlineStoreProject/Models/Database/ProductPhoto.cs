using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineStoreProject.Models.Database
{
    public class ProductPhoto
    {
        [Key]
        public int Id { get; set; }

        public string PhotoUrl { get; set; }

        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }

        public ProductPhoto(string photoUrl)
        {
            PhotoUrl = photoUrl;
        }
        public ProductPhoto(string photoUrl, int productId)
        {
            PhotoUrl = photoUrl;
            ProductId = productId;
        }
    }
}
