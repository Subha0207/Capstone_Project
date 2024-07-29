using PizzaApp.Exceptions;
using PizzaApp.Interfaces;
using PizzaApp.Models.DTOs.Auth;
using PizzaApp.Models;
using PizzaApp.Repositories;
using Google.Apis.Auth;

namespace PizzaApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthService(UserRepository userRepository, IUserService userService, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _userService = userService;
            _tokenService = tokenService;
        }
        public async Task<AuthReturnDTO> AuthenticateWithGoogle(string token)
        {
            GoogleJsonWebSignature.Payload payload = await GoogleJsonWebSignature.ValidateAsync(token, new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new[] { "477896352233-42j7dt9ure6epjnlmcaj8dtlesjupamr.apps.googleusercontent.com" }
            });

            bool emailVerified = payload.EmailVerified;
            if (emailVerified)
            {

                User existingUser = await _userRepository.GetUserByEmail(payload.Email);
                User userToCreateToken = null;

                if (existingUser == null)
                {
                    string email = payload.Email;
                    string userName = payload.Name;
             
                    userToCreateToken = await _userService.CreateUser(email, userName);
                    await Console.Out.WriteLineAsync("New user created");
                }
                else
                {
                    await Console.Out.WriteLineAsync("got existing user");
                    userToCreateToken = existingUser;
                }

                string Token = _tokenService.GenerateToken(userToCreateToken);
                await Console.Out.WriteLineAsync(Token);
                await Console.Out.WriteLineAsync("above token");
                return new AuthReturnDTO
                {
                    Token = Token
                };
            }

            throw new GmailNotVerifiedException();
        }
    }
}
