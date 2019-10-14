using AutoMapper;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.Repositories
{
    public class MockUsersRepository : IUsersRepository
    {
        private readonly IMapper mapper;

        public IEnumerable<User> Users { get; private set; }

        public MockUsersRepository(IMapper mapper)
        {
            this.mapper = mapper;
            this.Users = new List<User>
            {
                new User("test@testuser.com", "test@test.com", "hJg8YPfarcHLhphiH4AsDZ+aPDwpXIEHSPsEgRXBhuw=", "first", "last", new Guid(), UserRoles.SuperAdmin, DateTime.UtcNow, DateTime.UtcNow, ""),
                new User("test2@testuser.com", "test2@test.com", "hJg8YPfarcHLhphiH4AsDZ+aPDwpXIEHSPsEgRXBhuw=", "f1", "l1", Guid.NewGuid(), UserRoles.User, DateTime.UtcNow, DateTime.UtcNow, "")
            };
        }

        public User GetUser(Guid userId)
        {
            return Users.FirstOrDefault(x => x.UserId == userId);
        }

        public User GetUser(string username)
        {
            return Users.FirstOrDefault(x => x.Username == username);
        }

        public void AddUser(User user)
        {
            if (DoesUserExist(user.Username, user.UserId, user.Email)) throw new ArgumentException("User already exists");

            var users = this.Users.ToList();
            users.Add(user);
            this.Users = users;
        }

        private bool DoesUserExist(string username, Guid userId, string emailAddress)
        {
            return this.Users.Any(u => u.Username == username || u.UserId == userId || u.Email == emailAddress);
        }

        public IEnumerable<UserView> GetUsers()
        {
            return mapper.Map<IEnumerable<User>, IEnumerable<UserView>>(this.Users);
        }
    }
}
