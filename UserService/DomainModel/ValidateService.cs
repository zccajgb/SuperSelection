using DomainModel.Infrastructure;
using DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;

namespace DomainModel
{
    public class ValidateService
    {
        private readonly IUsersRepository usersRepository;
        private readonly TokenManager tokenManager;

        public ValidateService(IUsersRepository usersRepository, TokenManager tokenManager)
        {
            this.usersRepository = usersRepository;
            this.tokenManager = tokenManager;
        }

        public Guid Validate(string token)
        {
            var (_, id, _) = tokenManager.ValidateToken(token);

            var user = this.usersRepository.GetUser(new Guid(id));

            if (user == null) throw new KeyNotFoundException($"Could not find user");
            if (user.UserId.ToString() != id) throw new AuthenticationException("Token is not valid");

            return user.UserId;
        }

        public Guid Validate(string token, string username)
        {
            var tup = tokenManager.ValidateToken(token);

            var user = this.usersRepository.GetUser(username);

            if (user == null) throw new KeyNotFoundException($"Could not find user with username: {username}");
            if (user.UserId.ToString() != tup.id) throw new AuthenticationException("Token is not valid");

            return user.UserId;
        }

        public int GetUserRole(string token)
        {
            var (_, _, role) = tokenManager.ValidateToken(token);
            return Convert.ToInt32(role);
        }
    }
}
