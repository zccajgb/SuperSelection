namespace ApiGateway.Models.ViewModels
{
    using System;

    public class UserView
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid UserId { get; set; }

        public int UserRole { get; set; }

        public string Token { get; set; }
    }
}
