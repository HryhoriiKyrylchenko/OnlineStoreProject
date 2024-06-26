﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineStoreProject.Models.Database
{
    public class MovementHistory
    {
        [Key]
        public int Id { get; set; }

        public DateTime MovementDate { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }

        public decimal Quantity { get; set; }

        public int SourceZonePositionId { get; set; }

        [ForeignKey("SourceZonePositionId")]
        [InverseProperty("SourceMovementHistories")]
        public virtual ZonePosition? SourceZonePosition { get; set; }

        public int DestinationZonePositionId { get; set; }

        [ForeignKey("DestinationZonePositionId")]
        [InverseProperty("DestinationMovementHistories")]
        public virtual ZonePosition? DestinationZonePosition { get; set; }

        public string? AdditionalInfo { get; set; }

        public MovementHistory(DateTime movementDate, int productId, decimal quantity, int sourceZonePositionId, int destinationZonePositionId)
        {
            MovementDate = movementDate;
            ProductId = productId;
            Quantity = quantity;
            SourceZonePositionId = sourceZonePositionId;
            DestinationZonePositionId = destinationZonePositionId;
        }
    }
}
