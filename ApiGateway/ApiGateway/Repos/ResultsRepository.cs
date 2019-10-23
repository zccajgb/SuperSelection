namespace ApiGateway.Repos
{
    using System.Threading.Tasks;
    using ApiGateway.Documents.Queries;
    using ApiGateway.Infrastructure;

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
            var str = await this.httpHelper.PostAsync<string>(this.uri, query);
            return str;
        }
    }
}
