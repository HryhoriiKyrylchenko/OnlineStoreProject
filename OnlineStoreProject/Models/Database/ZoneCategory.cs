using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineStoreProject.Models.Database
{
    public class ZoneCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public int? PreviousCategoryId { get; set; }

        [ForeignKey("PreviousCategoryId")]
        public virtual ZoneCategory? PreviousCategory { get; set; }

        public string? AdditionalInfo { get; set; }

        public virtual ICollection<Zone> Zones { get; set; }

        public ZoneCategory(string categoryName)
        {
            CategoryName = categoryName;

            Zones = new List<Zone>();
        }
    }
}
