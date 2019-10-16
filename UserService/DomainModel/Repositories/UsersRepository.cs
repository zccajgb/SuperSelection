using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using DomainModel.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

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
            if (DoesUserExist(user.Username, user.UserId, user.Email)) throw new ArgumentException("User already exists");
            this.users.InsertOne(user);
        }

        private bool DoesUserExist(string username, Guid userId, string email)
        {
            var user = this.users.Find(u => u.Username == username || u.UserId == userId || u.Email == email).ToList();

            return (user == null || user.Count() == 0) ? false : true; 
        }

        public User GetUser(Guid userId)
        {
            return this.users.Find(x => x.UserId == userId).FirstOrDefault();
        }

        public User GetUser(string username)
        {
            var users = this.users.Find(x => true).ToList();
            return this.users.Find(x => x.Username == username).FirstOrDefault();
        }

        public IEnumerable<UserView> GetUsers()
        {
            var users = this.users.Find(user => true).ToList();
            return mapper.Map<IEnumerable<UserView>>(users);
        }
    }
}
