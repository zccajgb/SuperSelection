namespace CalculationViews.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DomainModel.Repositories;
    using DomainModel.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    [Route("/")]
    [ApiController]
    public class CalculationsController : ControllerBase
    {
        private readonly ISelectivityCalculationsRepository selectivityCalculationsRepository;

        public CalculationsController(ISelectivityCalculationsRepository selectivityCalculationsRepository)
        {
            this.selectivityCalculationsRepository = selectivityCalculationsRepository;
        }

        [Route("GetAllForUser")]
        [HttpPost]
        public ActionResult<IEnumerable<SelectivityCalculationViewModel>> GetAllForUser([FromBody] string userID)
        {
            return this.Ok(this.selectivityCalculationsRepository.GetAllByUserID(new Guid(userID)));
        }

        [Route("GetByID")]
        [HttpPost]
        public ActionResult<IEnumerable<SelectivityCalculationViewModel>> GetByID([FromBody] string calcID)
        {
            return this.Ok(this.selectivityCalculationsRepository.GetByID(new Guid(calcID)));
        }
    }
}