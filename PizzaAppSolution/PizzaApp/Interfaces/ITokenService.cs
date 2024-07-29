using PizzaApp.Models;

namespace PizzaApp.Interfaces
{
   
        public interface ITokenService
        {
            public string GenerateToken(User user);
        }
    
}

