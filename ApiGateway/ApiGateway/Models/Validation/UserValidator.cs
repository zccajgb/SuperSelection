namespace ApiGateway.Models.Validation
{
    using ApiGateway.Models.DomainModels;
    using FluentValidation;

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            this.RuleFor(user => user.Username).NotEmpty().EmailAddress();
            this.RuleFor(user => user.Password).NotEmpty();
        }
    }
}
