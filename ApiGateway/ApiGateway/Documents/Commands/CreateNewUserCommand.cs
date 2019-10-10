using System;
using ApiGateway.Models;

namespace ApiGateway.Documents.Commands
{
    internal class CreateNewUserCommand : BaseCommand
    {
        private User user;

        public CreateNewUserCommand(User user, Guid actionUserID, DateTime actionDateTime)
            : base(actionUserID, actionDateTime)
        {
            this.user = user;
        }
    }
}