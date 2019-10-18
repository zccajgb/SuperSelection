using ApiGateway.Models.Validation;
using FluentValidation.Attributes;
using System;

namespace ApiGateway.Models.DomainModels
{
    [Validator(typeof(CalculationValidator))]
    public class Calculation
    {
        public Calculation(string name, Guid userId)
        {
            Name = name;
            ActionUserID = userId;
        }

        public string Name { get; private set; }
        public Guid ActionUserID { get; }
    }
}