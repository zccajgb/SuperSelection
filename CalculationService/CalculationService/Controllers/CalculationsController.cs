using DomainModel;
using DomainModel.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculationService.Controllers
{
    [ApiController]
    public class CalculationsController : ControllerBase
    {
        private readonly CalculationsOrchestrator calculationsOrchestrator;

        public CalculationsController(CalculationsOrchestrator calculationsOrchestrator)
        {
            this.calculationsOrchestrator = calculationsOrchestrator;
        }

        [Route("Command")]
        public ActionResult Command([FromBody] CommandObject jsonCommand)
        {
            var cmd = CommandBuilder.BuildCommand(jsonCommand);
            this.calculationsOrchestrator.ProcessCalculation(cmd);
            return Ok();
        }
    }
}
