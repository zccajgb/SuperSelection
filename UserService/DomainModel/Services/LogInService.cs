namespace DomainModel
{
    using AutoMapper;
    using DomainModel.Infrastructure;
    using DomainModel.Models;
    using DomainModel.Repositories;
    using Serilog;

    public class LoginService : ILoginService
    {
        private readonly IUsersRepository userRepository;
        private readonly IMapper mapper;
        private readonly ITokenManager tokenManager;

        public LoginService(IUsersRepository userRepository, IMapper mapper, ITokenManager tokenManager)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.tokenManager = tokenManager;
        }

        public UserView Login(string username, string password)
        {
            var user = this.userRepository.GetUser(username);

            var hashedPassword = PasswordHasher.HashPassword(password, user.Salt);

            if (hashedPassword != user.Password)
            {
                Log.Logger.Warning("Password is incorrect");
                return null;
            }

            var token = this.tokenManager.GenerateToken(user);
            Log.Logger.Information("Token generated for user: {@username}", username);
            return this.mapper.Map<UserView>(user, opts => opts.Items["Token"] = token);
        }

    }
}
