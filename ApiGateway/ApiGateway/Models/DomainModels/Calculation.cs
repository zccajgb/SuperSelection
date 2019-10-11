using ApiGateway.Models.Validation;
using FluentValidation.Attributes;

namespace ApiGateway.Models.DomainModels
{
    [Validator(typeof(CalculationValidator))]
    public class Calculation
    {
    }
}