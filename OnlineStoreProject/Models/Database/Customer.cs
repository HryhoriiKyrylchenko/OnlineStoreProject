using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;


namespace OnlineStoreProject.Models.Database
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? AddressId { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address? Address { get; set; }

        public decimal? DiscountPercentage { get; set; }

        public string? AdditionalInfo { get; set; }

        [JsonIgnore]
        public virtual ICollection<Shipment> Shipments { get; set; }

        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }

        public Customer(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;

            Orders = new List<Order>();
            Shipments = new List<Shipment>();
        }

        public override string ToString()
        {
            return $"{Firstname} {Lastname}";
        }
    }
}
