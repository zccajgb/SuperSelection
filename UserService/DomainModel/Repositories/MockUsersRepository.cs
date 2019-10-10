using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.Repositories
{
    public class MockUsersRepository : IUsersRepository
    {
        public IEnumerable<User> users { get; private set; }

        public MockUsersRepository()
        {
            this.users = new List<User>
            {
                new User("test", "test@test.com", "hJg8YPfarcHLhphiH4AsDZ+aPDwpXIEHSPsEgRXBhuw=", "first", "last", new Guid(), UserRoles.SuperAdmin, DateTime.UtcNow, DateTime.UtcNow, ""),
                new User("test2", "test2@test.com", "hJg8YPfarcHLhphiH4AsDZ+aPDwpXIEHSPsEgRXBhuw=", "f1", "l1", Guid.NewGuid(), UserRoles.User, DateTime.UtcNow, DateTime.UtcNow, "")
            };
        }

        public User GetUser(Guid userId)
        {
            return users.FirstOrDefault(x => x.UserId == userId);
        }

        public User GetUser(string username)
        {
            return users.FirstOrDefault(x => x.Username == username);
        }

        public void AddUser(User user)
        {
            if (DoesUserExist(user.Username, user.UserId, user.Email)) throw new ArgumentException("User already exists");

            var users = this.users.ToList();
            users.Add(user);
            this.users = users;
        }

        private bool DoesUserExist(string username, Guid userId, string emailAddress)
        {
            return this.users.Any(u => u.Username == username || u.UserId == userId || u.Email == emailAddress);
        }

        public IEnumerable<User> GetUsers()
        {
            return users.Select(u => new User(u.Username, u.Email, "******", u.FirstName, u.LastName, u.UserId, u.UserRole, u.CreatedDate, u.ModifiedDate, "****"));
        }
    }
}
