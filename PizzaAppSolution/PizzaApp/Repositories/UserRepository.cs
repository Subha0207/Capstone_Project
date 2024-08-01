using Microsoft.EntityFrameworkCore;
using PizzaApp.Contexts;
using PizzaApp.Exceptions;
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
        public async Task<User> GetUserByUserId(int userId)
        {
            var userDto = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            if (userDto == null)
            {
                throw new NotFoundException("User not found");
            }

            // Map UserDTO to User
            var user = new User
            {
                UserId = userDto.UserId,
                UserName = userDto.UserName,
                Email = userDto.Email,
              
                Role = userDto.Role
            };

            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var userDto = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (userDto == null)
            {
                throw new NotFoundException("User not found");
            }

            // Map UserDTO to User
            var user = new User
            {
                UserId = userDto.UserId,
                UserName = userDto.UserName,
                Email = userDto.Email,
               
                Role = userDto.Role
            };

            return user;
        }

    }
}
