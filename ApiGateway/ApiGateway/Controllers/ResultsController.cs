using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiGateway.Documents.Queries;
using ApiGateway.Models;
using ApiGateway.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ApiGateway.Controllers
{
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
            if (!ModelState.IsValid)
            {
                Log.Logger.Error("userID model is invalid: {@userID}", userID);
                return BadRequest(ModelState);
            }

            var query = new GetResultsByUserIDQuery(userID, new Guid(userID), DateTime.UtcNow);
            var results = await this.resultsRepository.PostResultsQuery(query);
            return Ok(results);
        }

        [HttpGet]
        [Route("Results/GetResultsByID")]
        public async Task<ActionResult<string>> GetResultByID([FromBody] string resultID)
        {
            if (!ModelState.IsValid)
            {
                Log.Logger.Error("resultID model is invalid: {@resultID}", resultID);
                return BadRequest(ModelState);
            }

            var query = new GetResultByIDQuery(resultID, new Guid(), DateTime.UtcNow);
            var result = await this.resultsRepository.PostResultsQuery(query);
            return Ok(result);
        }
    }
}