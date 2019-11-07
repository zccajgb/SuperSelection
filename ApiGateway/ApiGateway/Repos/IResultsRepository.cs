namespace ApiGateway.Repos
{
    using System;
    using System.Threading.Tasks;
    using ApiGateway.Documents.Queries;
    using ApiGateway.Models.ViewModels;

    public interface IResultsRepository
    {
        Task<SelectivityCalculationView> GetByUserID(string userID);
        Task<SelectivityCalculationView> GetByID(string ID);
    }
}
