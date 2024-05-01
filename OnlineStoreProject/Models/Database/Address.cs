using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace OnlineStoreProject.Models.Database
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        public string Country { get; set; }

        public string Index { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string BuildingNumber { get; set; }

        public string? Room { get; set; }

        public string? AdditionalInfo { get; set; }

        public virtual ICollection<Warehouse> Warehouses { get; set; }

        public virtual ICollection<Supplier> Suppliers { get; set; }

        [JsonIgnore]
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public virtual ICollection<Manufacturer> Manufacturers { get; set; }

        public Address(string country, string index, string city, string street, string buildingNumber)
        {

            Country = country;
            Index = index;
            City = city;
            Street = street;
            BuildingNumber = buildingNumber;

            Warehouses = new List<Warehouse>();
            Suppliers = new List<Supplier>();
            CustomerAddresses = new List<CustomerAddress>();
            Manufacturers = new List<Manufacturer>();
        }

        public override string ToString()
        {
            string number = (Room == null) ? $"{BuildingNumber}" : $"{BuildingNumber}/{Room}";

            return $"{Street} {number}, {Index} {City}";
        }
    }
}
