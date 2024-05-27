using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreProject.Models;
using OnlineStoreProject.Servises;

namespace OnlineStoreProject.Controllers
{
    [Authorize(Policy = "CustomerOnly")]
    public class CartController : Controller
    {
        private const string CartSessionKey = "CartSessionKey";

        private ShoppingCart GetCart()
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>(CartSessionKey) ?? new ShoppingCart();
            return cart;
        }

        private void SaveCart(ShoppingCart cart)
        {
            HttpContext.Session.SetObjectAsJson(CartSessionKey, cart);
        }

        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        public IActionResult AddToCart(int productId, string productName, string imageUrl, decimal price, int quantity = 1)
        {
            var cart = GetCart();
            cart.AddToCart(new CartItem { ProductId = productId, ProductName = productName, ImageUrl = imageUrl, Price = price, Quantity = quantity });
            SaveCart(cart);
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            var cart = GetCart();
            cart.RemoveFromCart(productId);
            SaveCart(cart);
            return RedirectToAction("Index");
        }

        public IActionResult ClearCart()
        {
            var cart = GetCart();
            cart.ClearCart();
            SaveCart(cart);
            return RedirectToAction("Index");
        }
    }
}
