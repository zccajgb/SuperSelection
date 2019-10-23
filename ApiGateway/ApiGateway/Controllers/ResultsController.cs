namespace ApiGateway.Controllers
{
    using System;
    using System.Threading.Tasks;
    using ApiGateway.Documents.Queries;
    using ApiGateway.Repos;
    using Microsoft.AspNetCore.Mvc;
    using Serilog;

    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly IResultsRepository resultsRepository;

        public ResultsController(IResultsRepository resultsRepository)
        {
            this.resultsRepository = resultsRepository;
        }

        [HttpGet]
        [Route("Results/GetResultsByUserID")]
        public async Task<ActionResult<string>> GetResultsByUserID([FromBody] string userID)
        {
            if (!this.ModelState.IsValid)
            {
                Log.Logger.Error("userID model is invalid: {@userID}", userID);
                return this.BadRequest(this.ModelState);
            }

            var query = new GetResultsByUserIDQuery(userID, new Guid(userID), DateTime.UtcNow);
            var results = await this.resultsRepository.PostResultsQuery(query);
            return this.Ok(results);
        }

        [HttpGet]
        [Route("Results/GetResultsByID")]
        public async Task<ActionResult<string>> GetResultByID([FromBody] string resultID)
        {
            if (!this.ModelState.IsValid)
            {
                Log.Logger.Error("resultID model is invalid: {@resultID}", resultID);
                return this.BadRequest(this.ModelState);
            }

            var query = new GetResultByIDQuery(resultID, default, DateTime.UtcNow);
            var result = await this.resultsRepository.PostResultsQuery(query);
            return this.Ok(result);
        }
    }
}