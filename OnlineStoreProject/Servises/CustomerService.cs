using Microsoft.EntityFrameworkCore;
using OnlineStoreProject.Models.Database;

namespace OnlineStoreProject.Servises
{
    public class CustomerService
    {
        ApplicationContext _context;

        public CustomerService(ApplicationContext context) 
        {
            _context = context;
        }

        public Customer? GetCustomerByEmail(string? customername)
        {
            return _context.Customers.FirstOrDefault(c => c.EmailAddress == customername);
        }

        public async Task<Customer?> GetCustomerByEmailAndPassword(string email, string password)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.EmailAddress == email && c.Password == password);
        }

        public async Task AddCustomer(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
    }
}
