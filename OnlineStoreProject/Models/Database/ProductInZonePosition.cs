﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineStoreProject.Models.Database
{
    public class ProductInZonePosition
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }

        public int Quantity { get; set; }

        public DateTime? ManufactureDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public int ZonePositionId { get; set; }

        [ForeignKey("ZonePositionId")]
        public virtual ZonePosition? ZonePosition { get; set; }

        public ProductInZonePosition(int productId, int quantity, int zonePositionId)
        {
            ProductId = productId;
            Quantity = quantity;
            ZonePositionId = zonePositionId;
        }
    }
}
