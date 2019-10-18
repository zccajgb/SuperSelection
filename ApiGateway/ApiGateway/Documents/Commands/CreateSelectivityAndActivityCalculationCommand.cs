using System;

namespace ApiGateway.Documents.Commands
{
    public class CreateSelectivityAndActivityCalculationCommand : BaseCommand
    {
        public string Name { get; private set; }
        public CreateSelectivityAndActivityCalculationCommand(string name, Guid actionUserID, DateTime actionDateTime) : base(actionUserID, actionDateTime)
        {
            this.Name = name;
        }
    }
}