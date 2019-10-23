namespace DomainModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    [BsonIgnoreExtraElements]
    public class User
    {
        public User(string username, string email, string password, string firstName, string lastName, Guid userId, int userRole, DateTime createdDate, DateTime modifiedDate, string salt)
        {
            this.Username = username;
            this.Email = email;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.UserId = userId;
            this.UserRole = userRole;
            this.CreatedDate = createdDate;
            this.ModifiedDate = modifiedDate;
            this.Salt = salt;
        }

        public string Username { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public Guid UserId { get; private set; }

        public int UserRole { get; private set; }

        public DateTime CreatedDate { get; private set; }

        public DateTime ModifiedDate { get; private set; }

        public string Salt { get; private set; }
    }
}
