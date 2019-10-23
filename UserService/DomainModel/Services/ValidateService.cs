namespace DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.Security.Authentication;
    using DomainModel.Infrastructure;
    using DomainModel.Repositories;
    using Serilog;

    public class ValidateService : IValidateService
    {
        private readonly IUsersRepository usersRepository;
        private readonly ITokenManager tokenManager;

        public ValidateService(IUsersRepository usersRepository, ITokenManager tokenManager)
        {
            this.usersRepository = usersRepository;
            this.tokenManager = tokenManager;
        }

        public Guid Validate(string token)
        {
            var (_, id, _) = this.tokenManager.ValidateToken(token);

            var user = this.usersRepository.GetUser(new Guid(id));

            if (user == null)
            {
                Log.Logger.Error("could not find user with id: {@id}", @id);
                throw new KeyNotFoundException($"Could not find user");
            }

            if (user.UserId.ToString() != id)
            {
                Log.Logger.Error("Token is not valid: {@token}", token);
                throw new AuthenticationException("Token is not valid");
            }

            return user.UserId;
        }

        public Guid Validate(string token, string username)
        {
            var tup = this.tokenManager.ValidateToken(token);
            var user = this.usersRepository.GetUser(username);
            if (user == null)
            {
                Log.Logger.Error("could not find user with id: {id}", @tup.id);
                throw new KeyNotFoundException($"Could not find user with username: {username}");
            }

            if (user.UserId.ToString() != tup.id)
            {
                var exceptionMessage = "Token is not valid";
                Log.Logger.Error(exceptionMessage);
                throw new AuthenticationException(exceptionMessage);
            }

            return user.UserId;
        }

        public int GetUserRole(string token)
        {
            var (_, _, role) = this.tokenManager.ValidateToken(token);
            return Convert.ToInt32(role);
        }
    }
}
