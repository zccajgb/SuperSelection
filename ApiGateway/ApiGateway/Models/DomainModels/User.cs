namespace ApiGateway.Models.DomainModels
{
    using ApiGateway.Models.Validation;
    using FluentValidation.Attributes;

    [Validator(typeof(UserValidator))]
    public class User
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
