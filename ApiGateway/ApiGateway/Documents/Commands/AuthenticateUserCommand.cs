namespace ApiGateway.Documents.Commands
{
    using System;
    using ApiGateway.Models.DomainModels;

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