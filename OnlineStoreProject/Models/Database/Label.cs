using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineStoreProject.Models.Database
{
    public class Label
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Barcode { get; set; }

        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }

        public Label(string barcode)
        {
            Barcode = barcode;
        }

        public Label(string barcode, int productId) : this(barcode)
        {
            ProductId = productId;
        }
    }
}
