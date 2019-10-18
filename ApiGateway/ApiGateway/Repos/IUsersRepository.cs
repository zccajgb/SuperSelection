using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiGateway.Infrastructure;
using ApiGateway.Models.DomainModels;
using ApiGateway.Models.ViewModels;
using Microsoft.Extensions.Configuration;

namespace ApiGateway.Repos
{
    public interface IUsersRepository
    {
        Task<Guid> GetUserID(string token);
        Task<IEnumerable<UserView>> GetAllUsers();
        Task<UserView> CreateNewUser(User user);
        Task<UserView> Login(User user);
    }
}
