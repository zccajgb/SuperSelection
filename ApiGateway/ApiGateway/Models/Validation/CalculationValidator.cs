using ApiGateway.Models.DomainModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGateway.Models.Validation
{
    public class CalculationValidator : AbstractValidator<Calculation>
    {
        public CalculationValidator()
        {
        }
    }
}
