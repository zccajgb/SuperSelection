namespace ApiGateway.Repos
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ApiGateway.Models.DomainModels;
    using ApiGateway.Models.ViewModels;

    public interface IUsersRepository
    {
        Task<Guid> GetUserID(string token);

        Task<IEnumerable<UserView>> GetAllUsers();

        Task<UserView> CreateNewUser(User user);

        Task<UserView> Login(User user);
    }
}
