namespace ApiGateway.Repos
{
    using System.Threading.Tasks;
    using ApiGateway.Documents.Queries;

    public interface IResultsRepository
    {
        Task<string> PostResultsQuery(BaseQuery query);
    }
}
