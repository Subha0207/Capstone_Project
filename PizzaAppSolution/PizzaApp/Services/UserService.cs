﻿
using PizzaApp.Interfaces;
using PizzaApp.Models.Enums;
using PizzaApp.Models;
using PizzaApp.Repositories;

namespace PizzaApp.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
 

        public async Task<User> CreateUser(string email, string userName)
        {
            var user = new User
            {
                Email=email,
                UserName=userName,
                Role=UserRole.User,
                
        

            };
            await _userRepository.Add(user);
            return user;
         
        }
    }
}