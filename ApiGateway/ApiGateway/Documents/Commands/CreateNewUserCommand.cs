namespace ApiGateway.Documents.Commands
{
    using System;
    using ApiGateway.Models.DomainModels;

    internal class CreateNewUserCommand : BaseCommand
    {
        private readonly User user;

        public CreateNewUserCommand(User user, Guid actionUserID, DateTime actionDateTime)
            : base(actionUserID, actionDateTime)
        {
            this.user = user;
        }
    }
}