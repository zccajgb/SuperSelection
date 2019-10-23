namespace DomainModel.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using AutoMapper;
    using DomainModel.Models;

    public class MockUsersRepository : IUsersRepository
    {
        private readonly IMapper mapper;

        public MockUsersRepository(IMapper mapper)
        {
            this.mapper = mapper;
            this.Users = new List<User>
            {
                new User("test@testuser.com", "test@test.com", "hJg8YPfarcHLhphiH4AsDZ+aPDwpXIEHSPsEgRXBhuw=", "first", "last", default, UserRoles.SuperAdmin, DateTime.UtcNow, DateTime.UtcNow, string.Empty),
                new User("test2@testuser.com", "test2@test.com", "hJg8YPfarcHLhphiH4AsDZ+aPDwpXIEHSPsEgRXBhuw=", "f1", "l1", Guid.NewGuid(), UserRoles.User, DateTime.UtcNow, DateTime.UtcNow, string.Empty),
            };
        }

        public IEnumerable<User> Users { get; private set; }

        public User GetUser(Guid userId)
        {
            return this.Users.FirstOrDefault(x => x.UserId == userId);
        }

        public User GetUser(string username)
        {
            return this.Users.FirstOrDefault(x => x.Username == username);
        }

        public void AddUser(User user)
        {
            Contract.Requires(user != null);

            if (this.DoesUserExist(user.Username, user.UserId, user.Email))
            {
                throw new ArgumentException("User already exists");
            }

            var users = this.Users.ToList();
            users.Add(user);
            this.Users = users;
        }

        public IEnumerable<UserView> GetAllUsers()
        {
            return this.mapper.Map<IEnumerable<User>, IEnumerable<UserView>>(this.Users);
        }

        private bool DoesUserExist(string username, Guid userId, string emailAddress)
        {
            return this.Users.Any(u => u.Username == username || u.UserId == userId || u.Email == emailAddress);
        }
    }
}
