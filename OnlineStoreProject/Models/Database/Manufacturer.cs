﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStoreProject.Models.Database
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? AddressId { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address? Address { get; set; }
        public string? AdditionalInfo { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
        public Manufacturer(string name)
        {
            Name = name;
            Products = new List<Product>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
