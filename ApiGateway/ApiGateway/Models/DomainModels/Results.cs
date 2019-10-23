namespace ApiGateway.Models.DomainModels
{
    using ApiGateway.Models.Validation;
    using FluentValidation.Attributes;

    [Validator(typeof(ResultsValidator))]
    public class Results
    {
    }
}
