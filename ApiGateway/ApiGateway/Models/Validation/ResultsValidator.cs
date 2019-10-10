using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGateway.Models.Validation
{
    public class ResultsValidator : AbstractValidator<Results>
    {
        public ResultsValidator()
        {
        }
    }
}
