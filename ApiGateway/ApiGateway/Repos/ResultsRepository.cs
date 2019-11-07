namespace ApiGateway.Repos
{
    using System;
    using System.Threading.Tasks;
    using ApiGateway.Documents.Queries;
    using ApiGateway.Infrastructure;
    using ApiGateway.Models.ViewModels;

    public class ResultsRepository : IResultsRepository
    {
        private readonly HttpHelper httpHelper;
        private readonly string uri = "https://localhost:44356";

        public ResultsRepository(HttpHelper httpHelper)
        {
            this.httpHelper = httpHelper;
        }

        public async Task<SelectivityCalculationView> GetByID(string ID)
        {
            var result = await this.httpHelper.PostAsync<SelectivityCalculationView>(this.uri + "/GetByID", ID);
            return result;
        }

        public async Task<SelectivityCalculationView> GetByUserID(string userID)
        {
            var result = await this.httpHelper.PostAsync<SelectivityCalculationView>(this.uri + "/GetAllForUser", userID);
            return result;
        }
    }
}
