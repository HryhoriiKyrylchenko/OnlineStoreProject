using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineStoreProject.Models.Database
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int? OrderId { get; set; }

        [ForeignKey("OrderId")]
        [JsonIgnore]
        public virtual Order? Order { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }

        public int Quantity { get; set; }

        public OrderItem(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public OrderItem(int orderId, int productId, int quantity) : this(productId, quantity)
        {
            OrderId = orderId;
        }
    }
}
