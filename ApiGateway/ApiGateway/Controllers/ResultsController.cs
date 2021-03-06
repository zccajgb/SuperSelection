﻿namespace ApiGateway.Controllers
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using ApiGateway.Documents.Queries;
    using ApiGateway.Repos;
    using Microsoft.AspNetCore.Mvc;
    using Serilog;

    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly IResultsRepository resultsRepository;
        private readonly IUsersRepository usersRepository;

        public ResultsController(IResultsRepository resultsRepository, IUsersRepository usersRepository)
        {
            this.resultsRepository = resultsRepository;
            this.usersRepository = usersRepository;
        }

        [HttpGet]
        [Route("Results/GetResultsByUserID")]
        public async Task<ActionResult<string>> GetResultsByUserID([FromHeader(Name = "Authorization")] string token)
        {
            if (!this.ModelState.IsValid)
            {
                Log.Logger.Error("token model is invalid: {@token}", token);
                return this.BadRequest(this.ModelState);
            }

            Guid userID = default;
            try
            {
                userID = await this.usersRepository.GetUserID(token);
            }
            catch(HttpRequestException ex)
            {
                return this.Unauthorized(ex);
            }

            var results = await this.resultsRepository.GetByUserID(userID.ToString());
            return this.Ok(results);
        }

        [HttpGet]
        [Route("Results/GetResultByID/{resultID}")]
        public async Task<ActionResult<string>> GetResultByID(string resultID)
        {
            if (!this.ModelState.IsValid)
            {
                Log.Logger.Error("resultID model is invalid: {@resultID}", resultID);
                return this.BadRequest(this.ModelState);
            }

            var result = await this.resultsRepository.GetByID(resultID);
            return this.Ok(result);
        }
    }
}