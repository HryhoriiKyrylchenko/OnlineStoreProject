using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineStoreProject.Models.Database
{
    public class ZonePosition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int? ZoneId { get; set; }

        [ForeignKey("ZoneId")]
        public virtual Zone? Zone { get; set; }

        public string? AdditionalInfo { get; set; }

        public virtual ICollection<ProductInZonePosition> ProductsInZonePosition { get; set; }

        [InverseProperty("SourceZonePosition")]
        public virtual ICollection<MovementHistory> SourceMovementHistories { get; set; }

        [InverseProperty("DestinationZonePosition")]
        public virtual ICollection<MovementHistory> DestinationMovementHistories { get; set; }

        public ZonePosition(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            ProductsInZonePosition = new List<ProductInZonePosition>();
            SourceMovementHistories = new List<MovementHistory>();
            DestinationMovementHistories = new List<MovementHistory>();
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
