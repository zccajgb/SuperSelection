namespace ApiGateway.Repos
{
    using System.Threading.Tasks;
    using ApiGateway.Documents.Commands;
    using ApiGateway.Documents.Queries;

    public interface ICalculationsRepository
    {
        Task<string> PostCommand(BaseCommand cmd);

        Task<string> PostQuery(BaseQuery qry);
    }
}
