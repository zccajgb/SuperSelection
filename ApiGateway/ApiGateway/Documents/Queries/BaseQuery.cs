namespace ApiGateway.Documents.Queries
{
    using System;

    public class BaseQuery
    {
        private DateTime actionDateTime;
        private Guid actionUserId;

        public BaseQuery(Guid actionUserID, DateTime actionDateTime)
        {
            this.actionDateTime = actionDateTime;
            this.actionUserId = actionUserID;
        }
    }
}