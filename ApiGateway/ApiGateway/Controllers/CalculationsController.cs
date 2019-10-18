using System;
using System.Threading.Tasks;
using ApiGateway.Documents.Commands;
using ApiGateway.Models;
using ApiGateway.Models.DomainModels;
using ApiGateway.Repos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ApiGateway.Controllers
{
    [ApiController]
    [Route("Calculations")]
    public class CalculationsController : ControllerBase
    {
        private readonly ICalculationsRepository calculationsRepository;
        private readonly IMapper mapper;

        public CalculationsController(ICalculationsRepository calculationsRepository, IMapper mapper)
        {
            this.calculationsRepository = calculationsRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("CreateCalcuation")]
        public async Task<ActionResult<string>> CreateCalculation([FromBody] Calculation calculation)
        {
            if (!ModelState.IsValid)
            {
                Log.Logger.Error("Calculation model is invalid: {@calc}", calculation);
                return BadRequest(ModelState);
            }

            var command = mapper.Map<CreateSelectivityAndActivityCalculationCommand>(calculation, opts =>
            {
                opts.Items["Datetime"] = DateTime.UtcNow;
            });

            var response = await this.calculationsRepository.PostCommand(command);
            return Ok(response);
        }

    }
}