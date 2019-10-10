using ApiGateway.Models.Validation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGateway.Models
{
    [Validator(typeof(ResultsValidator))]
    public class Results
    {
    }
}
