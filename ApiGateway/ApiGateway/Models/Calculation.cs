using ApiGateway.Models.Validation;
using FluentValidation.Attributes;

namespace ApiGateway.Models
{
    [Validator(typeof(CalculationValidator))]
    public class Calculation
    {
    }
}