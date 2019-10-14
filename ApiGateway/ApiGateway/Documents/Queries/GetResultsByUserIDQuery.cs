using System;

namespace ApiGateway.Documents.Queries
{
    internal class GetResultsByUserIDQuery : BaseQuery
    {
        private Guid userID;

        public GetResultsByUserIDQuery(string userID, Guid actionUserID, DateTime actionDateTime)
            : base(actionUserID, actionDateTime)
        {
            this.userID = new Guid(userID);
        }
    }
}