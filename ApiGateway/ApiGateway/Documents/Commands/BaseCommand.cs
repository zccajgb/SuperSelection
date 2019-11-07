namespace ApiGateway.Documents.Commands
{
    using System;

    public class BaseCommand
    {
        public BaseCommand(Guid actionUserID, DateTime actionDateTime)
        {
            this.ActionDateTime = actionDateTime;
            this.ActionUserID = actionUserID;
        }

        public DateTime ActionDateTime { get; private set; }

        public Guid ActionUserID { get; private set; }
    }
}
