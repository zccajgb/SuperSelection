using System;

namespace ApiGateway.Documents.Queries
{
    internal class GetUsersQuery : BaseQuery
    {
        public GetUsersQuery(Guid actionUserId, DateTime actionDateTime)
            : base(actionUserId, actionDateTime)
        {
        }
    }
}