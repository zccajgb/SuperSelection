namespace ApiGateway.Repos
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ApiGateway.Documents.Queries;
    using ApiGateway.Models.ViewModels;

    public interface IResultsRepository
    {
        Task<IEnumerable<SelectivityCalculationView>> GetByUserID(string userID);
        Task<SelectivityCalculationView> GetByID(string ID);
    }
}
