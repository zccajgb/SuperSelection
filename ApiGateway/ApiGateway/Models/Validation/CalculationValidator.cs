namespace ApiGateway.Models.Validation
{
    using ApiGateway.Models.DomainModels;
    using FluentValidation;

    public class CalculationValidator : AbstractValidator<Calculation>
    {
        public CalculationValidator()
        {
            this.RuleFor(x => x.Name).NotEmpty();
        }
    }
}
