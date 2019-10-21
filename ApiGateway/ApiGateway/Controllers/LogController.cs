using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiGateway.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ApiGateway.Controllers
{
    [ApiController]
    [Route("Api/Log")]
    public class LogController : ControllerBase
    {
        private ILogger logger;

        public LogController(ILogger logger)
        {
            this.logger = logger;
        }

        [HttpPost]
        public ActionResult Log([FromBody] NgLog log)
        {
            if (log.Level == 0) this.logger.Verbose(log.Message);
            if (log.Level == 1) this.logger.Debug(log.Message);
            if (log.Level == 2) this.logger.Information(log.Message);
            if (log.Level == 3) this.logger.Information(log.Message);
            if (log.Level == 4) this.logger.Warning(log.Message);
            if (log.Level == 5) this.logger.Error(log.Message);
            if (log.Level == 6) this.logger.Fatal(log.Message);
            else this.logger.Error(log.Message);
            return Ok();
        }
    }
}