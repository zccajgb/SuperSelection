namespace ApiGateway.Models.Validation
{
    using ApiGateway.Models.DomainModels;
    using FluentValidation;

    public class ResultsValidator : AbstractValidator<Results>
    {
        public ResultsValidator()
        {
        }
    }
}
