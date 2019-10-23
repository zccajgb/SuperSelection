namespace ApiGateway.Models.DomainModels
{
    using System;
    using ApiGateway.Models.Validation;
    using FluentValidation.Attributes;

    [Validator(typeof(CalculationValidator))]
    public class Calculation
    {
        public Calculation(string name, Guid userId)
        {
            this.Name = name;
            this.ActionUserID = userId;
        }

        public string Name { get; private set; }

        public Guid ActionUserID { get; }
    }
}