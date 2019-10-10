using System;
using System.Collections.Generic;
using DomainModel.Models;

namespace DomainModel.Repositories
{
    public interface IUsersRepository
    {
        void AddUser(User user);
        User GetUser(Guid userId);
        User GetUser(string username);
        IEnumerable<User> GetUsers();
    }
}