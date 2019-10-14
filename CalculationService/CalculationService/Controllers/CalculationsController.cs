using Microsoft.AspNetCore.Mvc;

eusing System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculationService.Controllers
{
    [ApiController]
    public class CalculationsController : ControllerBase
    {
        private readonly CalculationsOrchestrator calculationsOrchestrator;
    }
}
