using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineStoreProject.Models.Database
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }

        public string? AdditionalInfo { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public Order(DateTime orderDate, int customerId)
        {
            OrderDate = orderDate;
            CustomerId = customerId;

            OrderItems = new List<OrderItem>();
        }
    }
}
