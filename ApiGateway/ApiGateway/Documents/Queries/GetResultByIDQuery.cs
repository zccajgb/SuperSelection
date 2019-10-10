using System;

namespace ApiGateway.Documents.Queries
{
    internal class GetResultByIDQuery : BaseQuery
    {
        private Guid resultID;

        public GetResultByIDQuery(string resultID, Guid actionUserID, DateTime actionDateTime) : 
            base(actionUserID, actionDateTime)
        {
            this.resultID = new Guid(resultID);
        }
    }
}