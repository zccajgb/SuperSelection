namespace ApiGateway.Controllers
{
    using System.Threading.Tasks;
    using ApiGateway.Models.DomainModels;
    using ApiGateway.Models.ViewModels;
    using ApiGateway.Repos;
    using Microsoft.AspNetCore.Mvc;
    using Serilog;

    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        [HttpPost]
        [Route("Users/Login")]
        public async Task<ActionResult<UserView>> Login([FromBody] User user)
        {
            if (!this.ModelState.IsValid)
            {
                Log.Logger.Error("User model is invalid: {@user}", user);
                return this.BadRequest(this.ModelState);
            }

            var result = await this.usersRepository.Login(user);
            return this.Ok(result);
        }

        [HttpGet]
        [Route("Users")]
        public async Task<ActionResult<UserView>> Get()
        {
            if (!this.ModelState.IsValid)
            {
                Log.Logger.Error("modelstate is invalid: {@userID}");
                return this.BadRequest(this.ModelState);
            }

            var users = await this.usersRepository.GetAllUsers();
            return this.Ok(users);
        }

        [HttpPost]
        [Route("Users/CreateNewAccount")]
        public async Task<ActionResult<UserView>> CreateNewAccount([FromBody] User user)
        {
            if (!this.ModelState.IsValid)
            {
                Log.Logger.Error("User model is invalid: {@user}", user);
                return this.BadRequest(this.ModelState);
            }

            var result = await this.usersRepository.CreateNewUser(user);
            return this.Ok(result);
        }
    }
}
