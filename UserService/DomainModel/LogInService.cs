using AutoMapper;
using DomainModel.Infrastructure;
using DomainModel.Models;
using DomainModel.Repositories;
using Serilog;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;

namespace DomainModel
{
    public class LoginService
    {
        private readonly IUsersRepository userRepository;
        private readonly IMapper mapper;
        private readonly TokenManager tokenManager;

        public LoginService(IUsersRepository userRepository, IMapper mapper, TokenManager tokenManager)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.tokenManager = tokenManager;
        }

        public UserView Login(string username, string password)
        {
            var user = userRepository.GetUser(username);

            var hashedPassword = PasswordHasher.HashPassword(password, user.Salt);

            if (hashedPassword != user.Password)
            {
                Log.Logger.Error("Password is incorrect");
                return null;
            }

            var token = tokenManager.GenerateToken(user);
            Log.Logger.Information("Token generated for user: {@username}", username);
            return mapper.Map<UserView>(user, opts => opts.Items["Token"] = token);
        }

    }
}
