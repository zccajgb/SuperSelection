﻿using Newtonsoft.Json;
using System;

namespace ApiGateway.Documents.Queries
{
    internal class BaseQuery
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