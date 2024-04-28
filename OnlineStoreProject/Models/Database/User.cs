using Newtonsoft.Json;
using OnlineStoreProject.Enums;
using System.ComponentModel.DataAnnotations;

namespace OnlineStoreProject.Models.Database
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public UserRolesEnum Role { get; set; }

        public string? AdditionalInfo { get; set; }

        [JsonIgnore]
        public virtual ICollection<Shipment> Shipments { get; set; }

        [JsonIgnore]
        public virtual ICollection<Receipt> Receipts { get; set; }

        public virtual ICollection<Report> Reports { get; set; }

        public User(string username, string password, UserRolesEnum role)
        {
            Username = username;
            Password = password;
            Role = role;

            Shipments = new List<Shipment>();
            Receipts = new List<Receipt>();
            Reports = new List<Report>();
        }

        public override string ToString()
        {
            return Username.ToString();
        }
    }
}
