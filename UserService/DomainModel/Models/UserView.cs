using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Models
{
    public class UserView
    {
        public UserView(string username, string email, string firstName, string lastName, Guid userId, int userRole, string token)
        {
            Username = username;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            UserId = userId;
            UserRole = userRole;
            Token = token;
        }

        public string Username { get; }
        public string Email { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public Guid UserId { get; }
        public int UserRole { get; }
        public string Token { get; }
    }
}
