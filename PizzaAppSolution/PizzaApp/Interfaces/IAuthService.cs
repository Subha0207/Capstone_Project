using PizzaApp.Models.DTOs.Auth;

namespace PizzaApp.Interfaces
{
    public interface IAuthService
    {
        public Task<AuthReturnDTO> AuthenticateWithGoogle(string token);
    }
}
