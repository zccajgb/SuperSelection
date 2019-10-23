namespace DomainModel.Documents.Commands
{
    using System;

    public class BaseCommand
    {
        public BaseCommand(Guid actionUserId, DateTime actionDateTime)
        {
            this.ActionUserId = actionUserId;
            this.ActionDateTime = actionDateTime;
        }

        public Guid ActionUserId { get; private set; }

        public DateTime ActionDateTime { get; private set; }
    }
}