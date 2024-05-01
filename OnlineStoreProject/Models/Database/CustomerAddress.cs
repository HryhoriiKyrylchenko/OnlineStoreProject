using System.ComponentModel.DataAnnotations;

namespace OnlineStoreProject.Models.Database
{
    public class CustomerAddress
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        public int AddressId { get; set; }
        public virtual Address? Address { get; set; }

        public CustomerAddress(int customerId, int addressId)
        {
            CustomerId = customerId;
            AddressId = addressId;
        }
    }
}
