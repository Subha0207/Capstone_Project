using PizzaApp.Models;

namespace PizzaApp.Interfaces
{
    public interface IUserService
    {
        public Task<User> CreateUser(string email, string userName);
        public Task<int> GetUserRole(string email);
    }
}
