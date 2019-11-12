namespace ApiGateway.Controllers
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using ApiGateway.Documents.Commands;
    using ApiGateway.Models.DomainModels;
    using ApiGateway.Repos;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Serilog;

    [ApiController]
    [Route("Calculations")]
    public class CalculationsController : ControllerBase
    {
        private readonly ICalculationsRepository calculationsRepository;
        private readonly IUsersRepository usersRepository;
        private readonly IMapper mapper;

        public CalculationsController(ICalculationsRepository calculationsRepository, IUsersRepository usersRepository, IMapper mapper)
        {
            this.calculationsRepository = calculationsRepository;
            this.usersRepository = usersRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("CreateSelectivityCalculation")]
        public async Task<ActionResult<string>> CreateSelectivityCalculation([FromHeader(Name ="Authorization")] string token, [FromBody] SelectivityCalculation calculation)
        {
            if (!this.ModelState.IsValid)
            {
                Log.Logger.Error("Calculation model is invalid: {@calc}", calculation);
                return this.BadRequest(this.ModelState);
            }

            Guid userId = default;
            try
            {
                userId = await this.usersRepository.GetUserID(token);
            }
            catch (HttpRequestException ex)
            {
                return this.Unauthorized(ex);
            }

            var command = this.mapper.Map<CreateSelectivityCalculationCommand>(calculation, opts =>
            {
                opts.Items["calculationID"] = Guid.NewGuid();
                opts.Items["actionDateTime"] = DateTime.UtcNow;
                opts.Items["actionUserID"] = userId;
            });

            var response = await this.calculationsRepository.PostCommand(command);
            return this.Ok(response);
        }
    }
}