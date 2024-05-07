using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStoreProject.Models;
using OnlineStoreProject.Models.Database;
using OnlineStoreProject.Models.ViewModels;
using OnlineStoreProject.Servises;
using System.Diagnostics;
using System.Security.Claims;

namespace OnlineStoreProject.Controllers
{
    public class HomeController : Controller
    {
        private CustomerService _customerService;
        private UserService _userService;
        private DBService _dbService;

        private readonly ILogger<HomeController> _logger;

        public HomeController(CustomerService customerService, 
            ILogger<HomeController> logger,
            UserService userService,
            DBService dbService)
        {
            _customerService = customerService;
            _logger = logger;
            _userService = userService;
            _dbService = dbService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Categories()
        {
            var categories = _dbService.GetProductCategories();
            return View(categories);
        }

        public IActionResult Products(int categoryId, string searchName, string sortBy)
        {
            var productsQuery = _dbService.GetProductsQuery(categoryId);

            if (!string.IsNullOrEmpty(searchName))
            {
                productsQuery = productsQuery.Where(p => p.Name.Contains(searchName));
            }

            productsQuery = ApplySorting(productsQuery, sortBy);

            var products = productsQuery
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description ?? "",
                    Price = p.Price,
                    ImageUrl = p.ProductPhotos.FirstOrDefault() != null ? p.ProductPhotos.First().PhotoUrl : ""
                })
                .ToList();

            return View(products);
        }

        public IActionResult Cart()
        {
            var cartItems = new List<CartItemViewModel>(); /////////////////////////////////// Implementation needed

            return View(cartItems);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        public IActionResult TermsAndConditions()
        {
            return View();
        }

        public IActionResult Returns()
        {
            return View();
        }

        public IActionResult Guarantee()
        {
            return View();
        }

        public IActionResult DeliveryAndPayment()
        {
            return View();
        }

        [Authorize(Policy = "CustomerOnly")]
        public IActionResult Account()
        {
            string? customername = HttpContext.User.Identity?.Name;

            Customer? customer = _customerService.GetCustomerByEmail(customername);

            if (customer == null)
            {
                return RedirectToAction("Login", "Home");
            }

            return View(customer);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var customer = await _customerService.GetCustomerByEmailAndPassword(username, password);

            if (customer != null)
            {
                await AuthenticateUser(customer.Firstname, customer.EmailAddress, "Customer");

                return RedirectToAction("Index", "Home");
            }

            var user = await _userService.GetUserByUsernameAndPassword(username, password);

            if (user != null)
            {
                await AuthenticateUser(username, "", "Admin");

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Login", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        

        [HttpPost]
        public async Task<IActionResult> Register(Customer customer)
        {
            var existingCustomer = _customerService.GetCustomerByEmail(customer.EmailAddress);

            if (existingCustomer != null)
            {
                ViewData["ErrorMessage"] = "User with this email already exists.";
                return View(customer);
            }

            await _customerService.AddCustomer(customer);

            return RedirectToAction("Login", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task AuthenticateUser(string username, string email, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }

        private IQueryable<Product> ApplySorting(IQueryable<Product> productsQuery, string sortBy)
        {
            switch (sortBy)
            {
                case "Name":
                    return productsQuery.OrderBy(p => p.Name);
                case "Price":
                    return productsQuery.OrderBy(p => p.Price);
                default:
                    return productsQuery.OrderBy(p => p.Name);
            }
        }
    }
}
