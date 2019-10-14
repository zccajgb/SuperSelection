using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DomainModel.Models
{
    public class User
    {
        public User(string username, string email, string password, string firstName, string lastName, Guid userId, int userRole, DateTime createdDate, DateTime modifiedDate, string salt)
        {
            Username = username;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            UserId = userId;
            UserRole = userRole;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            Salt = salt;
        }

        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Guid UserId { get; }
        public int UserRole { get; private set; }
        public DateTime CreatedDate { get; }
        public DateTime ModifiedDate { get; private set; }
        public string Salt { get; }
    }
}
