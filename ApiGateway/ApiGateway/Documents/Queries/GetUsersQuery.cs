namespace ApiGateway.Documents.Queries
{
    using System;

    internal class GetUsersQuery : BaseQuery
    {
        public GetUsersQuery(Guid actionUserId, DateTime actionDateTime)
            : base(actionUserId, actionDateTime)
        {
        }
    }
}