namespace OnlineStoreProject.Models
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddToCart(CartItem item)
        {
            var existingItem = Items.FirstOrDefault(i => i.ProductId == item.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                Items.Add(item);
            }
        }

        public void RemoveFromCart(int productId)
        {
            var item = Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                Items.Remove(item);
            }
        }

        public void ClearCart()
        {
            Items.Clear();
        }

        public decimal GetTotal()
        {
            return Items.Sum(i => i.Price * i.Quantity);
        }
    }
}
