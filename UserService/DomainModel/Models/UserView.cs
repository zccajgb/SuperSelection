namespace DomainModel.Models
{
    using System;

    public class UserView
    {
        public UserView(string username, string email, string firstName, string lastName, Guid userId, int userRole, string token)
        {
            this.Username = username;
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.UserId = userId;
            this.UserRole = userRole;
            this.Token = token;
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
