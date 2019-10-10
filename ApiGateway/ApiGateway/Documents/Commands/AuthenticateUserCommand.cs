using ApiGateway.Models;
using System;

namespace ApiGateway.Documents.Commands
{
    internal class AuthenticateUserCommand : BaseCommand
    {
        private User user;

        public AuthenticateUserCommand(User user, Guid actionUserID, DateTime actionDateTime) 
            : base(actionUserID, actionDateTime)
        {
            this.user = user;
        }
    }
}