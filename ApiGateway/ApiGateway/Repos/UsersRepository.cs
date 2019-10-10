using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApiGateway.Controllers;
using ApiGateway.Documents.Commands;
using ApiGateway.Documents.Queries;
using ApiGateway.Infrastructure;
using ApiGateway.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

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

        internal async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = (IEnumerable<User>) await httpHelper.GetAsync(this.uri);
            return users;
        }

        internal async Task<User> CreateNewUser(User user)
        {
            var createNewUserUri = this.uri + "/CreateNewUser";
            user = await httpHelper.PostAsync<User>(createNewUserUri, user);
            return user;
        }

        internal async Task<string> Login(User user)
        {
            var loginUri = this.uri + "/Login";
            var token = await this.httpHelper.PostAsync<string>(loginUri, user);
            return token;
        }
    }
}
