namespace DomainModel.Repositories
{
    using System;
    using System.Collections.Generic;
    using DomainModel.Models;

    public interface IUsersRepository
    {
        void AddUser(User user);

        User GetUser(Guid userId);

        User GetUser(string username);

        IEnumerable<UserView> GetAllUsers();
    }
}