using System;

namespace ApiGateway.Documents.Commands
{
    public class CreateSelectivityAndActivityCalculationCommand : BaseCommand
    {
        public CreateSelectivityAndActivityCalculationCommand(Guid actionUserID, DateTime actionDateTime) : base(actionUserID, actionDateTime)
        {
        }
    }
}