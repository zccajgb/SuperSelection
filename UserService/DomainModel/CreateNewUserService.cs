using AutoMapper;
using DomainModel.Infrastructure;
using DomainModel.Models;
using DomainModel.Repositories;
using Serilog;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DomainModel
{
    public class CreateNewUserService
    {
        private readonly IUsersRepository userRepository;
        private readonly IMapper mapper;

        public CreateNewUserService(IUsersRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public UserView CreateNewUser(string username, string password, string firstName, string lastName)
        {
            var salt = GenerateSalt();
            var hashedPassword = PasswordHasher.HashPassword(password, salt);

            var userId = Guid.NewGuid();
            var email = username;
            var now = DateTime.UtcNow;
            var userRole = UserRoles.User;

            var user = new User(username, email, hashedPassword, firstName, lastName, userId, userRole, now, now, salt);
            this.userRepository.AddUser(user);

            Log.Logger.Information("User created with username: {@username}", username);

            return mapper.Map<UserView>(user, opts => opts.Items["Token"] = string.Empty);
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
