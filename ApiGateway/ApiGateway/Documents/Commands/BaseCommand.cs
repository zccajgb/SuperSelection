namespace ApiGateway.Documents.Commands
{
    using System;

    public class BaseCommand
    {
        private DateTime actionDateTime;
        private Guid actionUserId;

        public BaseCommand(Guid actionUserID, DateTime actionDateTime)
        {
            this.actionDateTime = actionDateTime;
            this.actionUserId = actionUserID;
        }
    }
}
