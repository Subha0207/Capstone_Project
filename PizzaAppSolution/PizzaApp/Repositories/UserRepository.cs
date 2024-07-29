using Microsoft.EntityFrameworkCore;
using PizzaApp.Contexts;
using PizzaApp.Models;

namespace PizzaApp.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        private readonly PizzaAppContext _context;

        public UserRepository(PizzaAppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }
    }
}
