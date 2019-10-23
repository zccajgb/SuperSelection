namespace ApiGateway.Controllers
{
    using ApiGateway.Models.DomainModels;
    using Microsoft.AspNetCore.Mvc;
    using Serilog;

    [ApiController]
    [Route("Api/Log")]
    public class LogController : ControllerBase
    {
        private readonly ILogger logger;

        public LogController(ILogger logger)
        {
            this.logger = logger;
        }

        [HttpPost]
        public ActionResult Log([FromBody] NgLog log)
        {
            switch (log.Level)
            {
                case 0: this.logger.Verbose(log.Message);
                    break;
                case 1: this.logger.Debug(log.Message);
                    break;
                case 2: this.logger.Information(log.Message);
                    break;
                case 3: this.logger.Warning(log.Message);
                    break;
                case 4: this.logger.Information(log.Message);
                    break;
                case 6: this.logger.Fatal(log.Message);
                    break;
                default: this.logger.Error(log.Message);
                    break;
            }

            return this.Ok();
        }
    }
}