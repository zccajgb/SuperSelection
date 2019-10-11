using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiGateway.Infrastructure;
using ApiGateway.Models.DomainModels;
using ApiGateway.Models.ViewModels;
using Microsoft.Extensions.Configuration;

namespace ApiGateway.Repos
{
    public class UsersRepository
    {
        
        private readonly HttpHelper httpHelper;
        private readonly string uri;

        public UsersRepository(HttpHelper httpHelper, IConfiguration configuration)
        {
            this.httpHelper = httpHelper;
            this.uri = configuration.GetConnectionString("UserService");
        }
        
        internal async Task<Guid> GetUserID(string token)
        {
            var getUserIDUri = this.uri + "/GetUserID";
            var userId = (Guid) await this.httpHelper.PostAsync<Guid>(getUserIDUri, token);
            return userId;
        }

        internal async Task<IEnumerable<UserView>> GetAllUsers()
        {
            var userViews = (IEnumerable<UserView>) await httpHelper.GetAsync(this.uri);
            return userViews;
        }

        internal async Task<UserView> CreateNewUser(User user)
        {
            var createNewUserUri = this.uri + "/CreateNewUser";
            var userView = await httpHelper.PostAsync<UserView>(createNewUserUri, user);
            return userView;
        }

        internal async Task<UserView> Login(User user)
        {
            var loginUri = this.uri + "/Login";
            var token = await this.httpHelper.PostAsync<UserView>(loginUri, user);
            return token;
        }
    }
}
