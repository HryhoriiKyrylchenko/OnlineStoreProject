using Microsoft.EntityFrameworkCore;
using OnlineStoreProject.Models.Database;

namespace OnlineStoreProject.Servises
{
    public class UserService
    {
        ApplicationContext _context;

        public UserService(ApplicationContext context)
        {
            _context = context;
        }

        public User? GetUserByUsername(string? username)
        {
            return _context.Users.FirstOrDefault(c => c.Username == username);
        }

        public async Task<User?> GetUserByUsernameAndPassword(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.Username == username && c.Password == password);
        }
    }
}
