using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using DomainModel.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Serilog;

namespace DomainModel.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IMongoCollection<User> users;
        private readonly IMapper mapper;

        public UsersRepository(UsersDatabaseSettings settings, IMapper mapper)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            this.users = database.GetCollection<User>(settings.UsersCollectionName);

            this.mapper = mapper;
        }

        public void AddUser(User user)
        {
            if (DoesUserExist(user.Username, user.UserId, user.Email))
            {
                Log.Logger.Error("User already exists: @{user}", user);
                throw new ArgumentException("User already exists");
            }
            this.users.InsertOne(user);
        }

        private bool DoesUserExist(string username, Guid userId, string email)
        {
            var user = this.users.Find(u => u.Username == username || u.UserId == userId || u.Email == email).ToList();

            return (user == null || user.Count() == 0) ? false : true; 
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

        public IEnumerable<UserView> GetUsers()
        {
            var users = this.users.Find(user => true).ToList();
            if (users.Count() == 0)
            {
                Log.Logger.Error("No users exist");
            }

            return mapper.Map<IEnumerable<UserView>>(users);
        }
    }
}
