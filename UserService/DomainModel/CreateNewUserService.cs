using DomainModel.Infrastructure;
using DomainModel.Models;
using DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DomainModel
{
    public class CreateNewUserService
    {
        private readonly IUsersRepository userRepository;

        public CreateNewUserService(IUsersRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void CreateNewUser(string username, string password, string firstName, string lastName)
        {
            var salt = GenerateSalt();
            var hashedPassword = PasswordHasher.HashPassword(password, salt);

            var userId = Guid.NewGuid();
            var email = username;
            var now = DateTime.UtcNow;
            var userRole = UserRoles.User;

            var user = new User(username, email, hashedPassword, firstName, lastName, userId, userRole, now, now, salt);

            this.userRepository.AddUser(user);
        }

        private string GenerateSalt()
        {
            using (RNGCryptoServiceProvider saltGenerator = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[24];
                saltGenerator.GetBytes(salt);
                return Convert.ToBase64String(salt);
            }
        }
    }
}
