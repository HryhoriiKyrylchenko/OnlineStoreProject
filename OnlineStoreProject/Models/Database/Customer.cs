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

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public int PhoneNumber { get; set; }

        public decimal? DiscountPercentage { get; set; }

        public string? AdditionalInfo { get; set; }

        [JsonIgnore]
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }

        [JsonIgnore]
        public virtual ICollection<Shipment> Shipments { get; set; }

        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }

        public Customer() : this(string.Empty, string.Empty, string.Empty, string.Empty, default)
        { 
        }

        public Customer(string firstname, string lastname, string emailAddress, string password, int phoneNumber)
        {
            Firstname = firstname;
            Lastname = lastname;
            EmailAddress = emailAddress;
            Password = password;
            PhoneNumber = phoneNumber;

            Orders = new List<Order>();
            Shipments = new List<Shipment>();
            CustomerAddresses = new List<CustomerAddress>();
        }

        public override string ToString()
        {
            return $"{Firstname} {Lastname}";
        }
    }
}
