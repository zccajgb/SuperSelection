using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGateway.Documents.Commands
{
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
