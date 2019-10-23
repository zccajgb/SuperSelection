namespace DomainModel.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using AutoMapper;
    using DomainModel.Models;
    using MongoDB.Driver;
    using Serilog;

    public class UsersRepository : IUsersRepository
    {
        private readonly IMongoCollection<User> users;
        private readonly IMapper mapper;

        public UsersRepository(UsersDatabaseSettings settings, IMapper mapper)
        {
            Contract.Requires(settings != null);

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            this.users = database.GetCollection<User>(settings.UsersCollectionName);

            this.mapper = mapper;
        }

        public void AddUser(User user)
        {
            Contract.Requires(user != null);

            if (this.DoesUserExist(user.Username, user.UserId, user.Email))
            {
                Log.Logger.Error("User already exists: @{user}", user);
                throw new ArgumentException("User already exists");
            }

            this.users.InsertOne(user);
        }

        public User GetUser(Guid userId)
        {
            var user = this.users.Find(x => x.UserId == userId).FirstOrDefault();
            if (user == null)
            {
                Log.Logger.Error("User with userId: {@userId} could not be found", userId);
            }

            return user;
        }

        public User GetUser(string username)
        {
            var user = this.users.Find(x => x.Username == username).FirstOrDefault();
            if (user == null)
            {
                Log.Logger.Error("User with username: {@username} could not be found", username);
            }

            return user;
        }

        public IEnumerable<UserView> GetAllUsers()
        {
            var users = this.users.Find(user => true).ToList();
            if (!users.Any())
            {
                Log.Logger.Error("No users exist");
            }

            return this.mapper.Map<IEnumerable<UserView>>(users);
        }

        private bool DoesUserExist(string username, Guid userId, string email)
        {
            var user = this.users.Find(u => u.Username == username || u.UserId == userId || u.Email == email).ToList();

            return (user == null || !user.Any()) ? false : true;
        }
    }
}
