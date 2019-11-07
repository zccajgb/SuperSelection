namespace ApiGateway.Repos
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ApiGateway.Infrastructure;
    using ApiGateway.Models.DomainModels;
    using ApiGateway.Models.ViewModels;
    using Microsoft.Extensions.Configuration;

    public class UsersRepository : IUsersRepository
    {
        private readonly HttpHelper httpHelper;
        private readonly string uri;

        public UsersRepository(HttpHelper httpHelper, IConfiguration configuration)
        {
            this.httpHelper = httpHelper;
            this.uri = configuration.GetConnectionString("UserService");
        }

        public async Task<Guid> GetUserID(string token)
        {
            var getUserIDUri = this.uri + "/GetUserID";
            var userId = await this.httpHelper.PostAsync<Guid>(getUserIDUri, token);
            return userId;
        }

        public async Task<IEnumerable<UserView>> GetAllUsers()
        {
            var userViews = (IEnumerable<UserView>)await this.httpHelper.GetAsync<IEnumerable<UserView>>(this.uri);
            return userViews;
        }

        public async Task<UserView> CreateNewUser(User user)
        {
            var createNewUserUri = this.uri + "/CreateNewUser";
            var userView = await this.httpHelper.PostAsync<UserView>(createNewUserUri, user);
            return userView;
        }

        public async Task<UserView> Login(User user)
        {
            var loginUri = this.uri + "/Login";
            var token = await this.httpHelper.PostAsync<UserView>(loginUri, user);
            return token;
        }
    }
}
