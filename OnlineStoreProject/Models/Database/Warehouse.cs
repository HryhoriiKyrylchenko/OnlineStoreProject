﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineStoreProject.Models.Database
{
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int? AddressId { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address? Address { get; set; }

        public string? AdditionalInfo { get; set; }

        public virtual ICollection<Zone> Zones { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Warehouse(string name)
        {
            Name = name;

            Zones = new List<Zone>();
            Products = new List<Product>();
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
