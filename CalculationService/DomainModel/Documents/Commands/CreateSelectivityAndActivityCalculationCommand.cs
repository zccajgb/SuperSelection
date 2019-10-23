namespace DomainModel.Documents.Commands
{
    using System;

    public class CreateSelectivityAndActivityCalculationCommand : BaseCommand
    {
        public CreateSelectivityAndActivityCalculationCommand(string name, Guid actionUserID, DateTime actionDateTime)
            : base(actionUserID, actionDateTime)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
