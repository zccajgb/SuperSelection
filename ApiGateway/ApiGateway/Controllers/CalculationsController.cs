using System;
using System.Threading.Tasks;
using ApiGateway.Documents.Commands;
using ApiGateway.Models;
using ApiGateway.Repos;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [ApiController]
    public class CalculationsController : ControllerBase
    {
        private readonly CalculationsRepository calculationsRepository;

        public CalculationsController(CalculationsRepository calculationsRepository)
        {
            this.calculationsRepository = calculationsRepository;
        }

        [HttpPost]
        [Route("Calcuations")]
        public async Task<ActionResult<string>> CreateCalculation([FromBody] Calculation calculation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new CreateCalculationCommand(calculation, new Guid(), DateTime.UtcNow);
            var response = this.calculationsRepository.PostCommand(command);
            return Ok(response);
        }

    }
}