using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace OnlineStoreProject.Models.Database
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? AddressId { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address? Address { get; set; }

        public string? AdditionalInfo { get; set; }

        [JsonIgnore]
        public virtual ICollection<Receipt> Receipts { get; set; }

        public Supplier(string name, int addressId)
        {
            Name = name;
            AddressId = addressId;

            Receipts = new List<Receipt>();
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
