using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineStoreProject.Models.Database
{
    public class Zone
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int WarehouseId { get; set; }

        [ForeignKey("WarehouseId")]
        public virtual Warehouse? Warehouse { get; set; }

        public int Capacity { get; set; }

        public int ZoneCategoryId { get; set; }

        [ForeignKey("ZoneCategoryId")]
        public virtual ZoneCategory? ZoneCategory { get; set; }

        public string? AdditionalInfo { get; set; }

        public virtual ICollection<ZonePosition> ZonePositions { get; set; }

        public Zone(string name, int warehouseId, int zoneCategoryId, int capacity)
        {
            Name = name;
            WarehouseId = warehouseId;
            ZoneCategoryId = zoneCategoryId;
            Capacity = capacity;

            ZonePositions = new List<ZonePosition>();
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
