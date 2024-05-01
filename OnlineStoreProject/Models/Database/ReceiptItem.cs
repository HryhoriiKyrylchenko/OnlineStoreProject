using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace OnlineStoreProject.Models.Database
{
    public class ReceiptItem
    {
        [Key]
        public int Id { get; set; }

        public int? ReceiptId { get; set; }

        [ForeignKey("ReceiptId")]
        [JsonIgnore]
        public virtual Receipt? Receipt { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }

        public int Quantity { get; set; }

        public ReceiptItem(int productId, int quantity)
        {
            Quantity = quantity;
        }

        public ReceiptItem(int productId, int quantity, int receiptId) : this(productId,quantity)
        {
            ReceiptId = receiptId;
        }
    }
}
