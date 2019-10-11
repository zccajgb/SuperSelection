using ApiGateway.Documents.Commands;
using ApiGateway.Documents.Queries;
using ApiGateway.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiGateway.Repos
{
    public class CalculationsRepository
    {
        private readonly string uri;
        private readonly HttpHelper httpHelper;

        public CalculationsRepository(HttpHelper httpHelper)
        {
            this.httpHelper = httpHelper;
        }

        internal async Task<string> PostCommand(BaseCommand cmd)
        {
            var str = await httpHelper.PostAsync<string>(this.uri, cmd);
            return str;
        }

        internal async Task<string> PostQuery(BaseQuery qry)
        {
            var str = await httpHelper.PostAsync<string>(this.uri, qry);
            return str;
        }
    }
}
