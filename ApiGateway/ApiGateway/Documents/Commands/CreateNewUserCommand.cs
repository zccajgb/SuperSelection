using System;
using ApiGateway.Models;
using ApiGateway.Models.DomainModels;

namespace ApiGateway.Documents.Commands
{
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