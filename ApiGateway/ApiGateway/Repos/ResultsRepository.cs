using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApiGateway.Controllers;
using ApiGateway.Documents.Queries;
using ApiGateway.Infrastructure;
using ApiGateway.Models;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace ApiGateway.Repos
{
    public class ResultsRepository : IResultsRepository
    {
        private readonly HttpHelper httpHelper;
        private readonly string uri;

        public ResultsRepository(HttpHelper httpHelper)
        {
            this.httpHelper = httpHelper;
        }

        public async Task<string> PostResultsQuery(BaseQuery query)
        {
            var str = await httpHelper.PostAsync<string>(this.uri, query);
            return str;
        }
    }
}
