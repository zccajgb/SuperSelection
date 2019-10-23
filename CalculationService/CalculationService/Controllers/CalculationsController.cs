namespace CalculationService.Controllers
{
    using DomainModel;
    using DomainModel.Infrastructure;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class CalculationsController : ControllerBase
    {
        private readonly ICalculationsOrchestrator calculationsOrchestrator;

        public CalculationsController(ICalculationsOrchestrator calculationsOrchestrator)
        {
            this.calculationsOrchestrator = calculationsOrchestrator;
        }

        [Route("Command")]
        public ActionResult Command([FromBody] CommandObject jsonCommand)
        {
            var cmd = CommandBuilder.BuildCommand(jsonCommand);
            this.calculationsOrchestrator.ProcessCalculation(cmd);
            return this.Ok();
        }
    }
}
