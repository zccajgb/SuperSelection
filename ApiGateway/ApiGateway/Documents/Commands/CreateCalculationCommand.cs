using System;
using ApiGateway.Models;
using ApiGateway.Models.DomainModels;

namespace ApiGateway.Documents.Commands
{
    internal class CreateCalculationCommand : BaseCommand
    {
        private readonly Calculation calculation;

        public CreateCalculationCommand(Calculation calculation, Guid actionUserID, DateTime actionDateTime)
            : base(actionUserID, actionDateTime)
        {
            this.calculation = calculation;
        }
    }
}