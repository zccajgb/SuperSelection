namespace ApiGateway.Repos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using ApiGateway.Documents.Commands;
    using ApiGateway.Documents.Queries;
    using ApiGateway.Infrastructure;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;

    public class CalculationsRepository : ICalculationsRepository
    {
        private readonly HttpHelper httpHelper;
        private string uri;

        public CalculationsRepository(HttpHelper httpHelper, IConfiguration configuration)
        {
            this.httpHelper = httpHelper;
            this.uri = configuration.GetConnectionString("CalculationService");
        }

        public async Task<string> PostCommand(BaseCommand cmd)
        {
            var cmdObj = CommandBuilder.BuildJson(cmd);
            var str = await this.httpHelper.PostAsync<string>(this.uri + "/Command", cmdObj);
            return str;
        }

        public async Task<string> PostQuery(BaseQuery qry)
        {
            var str = await this.httpHelper.PostAsync<string>(this.uri, qry);
            return str;
        }
    }
}
