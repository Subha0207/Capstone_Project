using PizzaApp.Models;
using PizzaApp.Models.DTOs;

namespace PizzaApp.Interfaces
{
    public interface IUserService
    {
        public Task<User> CreateUser(string email, string userName);
        public Task<int> GetUserRole(string email);
    }
}
