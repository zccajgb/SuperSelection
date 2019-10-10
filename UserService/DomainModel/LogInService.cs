using DomainModel.Infrastructure;
using DomainModel.Models;
using DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;

namespace DomainModel
{
    public class LoginService
    {
        private readonly IUsersRepository userRepository;

        public LoginService(IUsersRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public string Login(string username, string password)
        {
            var user = userRepository.GetUser(username);
            if (user == null) return "Username could not be found";

            var hashedPassword = PasswordHasher.HashPassword(password, user.Salt);

            if (hashedPassword != user.Password) return "Password is incorrect";

            return TokenManager.GenerateToken(user);
        }

    }
}
