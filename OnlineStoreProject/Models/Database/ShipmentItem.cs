using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace OnlineStoreProject.Models.Database
{
    public class ShipmentItem
    {
        [Key]
        public int Id { get; set; }

        public int? ShipmentId { get; set; }

        [ForeignKey("ShipmentId")]
        [JsonIgnore]
        public virtual Shipment? Shipment { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }

        public int Quantity { get; set; }

        public ShipmentItem(int shipmentId, int productId, int quantity)
        {
            ShipmentId = shipmentId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
