using AutoMapper;
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
        private readonly Mapper mapper;

        public LoginService(IUsersRepository userRepository, Mapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public UserView Login(string username, string password)
        {
            var user = userRepository.GetUser(username);

            var hashedPassword = PasswordHasher.HashPassword(password, user.Salt);

            if (hashedPassword != user.Password) return null;

            var token = TokenManager.GenerateToken(user);

            return mapper.Map<User, UserView>(user, opts => opts.Items["Token"] = token);
        }

    }
}
