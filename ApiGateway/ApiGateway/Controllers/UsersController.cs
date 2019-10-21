using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using ApiGateway.Documents.Commands;
using ApiGateway.Documents.Queries;
using ApiGateway.Models;
using ApiGateway.Models.DomainModels;
using ApiGateway.Models.ViewModels;
using ApiGateway.Repos;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ApiGateway.Controllers
{
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
            if (!ModelState.IsValid)
            {
                Log.Logger.Error("User model is invalid: {@user}", user);
                return BadRequest(ModelState);
            }

            var result = await this.usersRepository.Login(user);
            return Ok(result);
        }

        [HttpGet]
        [Route("Users")]
        public async Task<ActionResult<UserView>> Get()
        {
            if (!ModelState.IsValid)
            {
                Log.Logger.Error("modelstate is invalid: {@userID}");
                return BadRequest(ModelState);
            }

            var users = await this.usersRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        [Route("Users/CreateNewAccount")]
        public async Task<ActionResult<UserView>> CreateNewAccount([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                Log.Logger.Error("User model is invalid: {@user}", user);
                return BadRequest(ModelState);
            }

            var result = await this.usersRepository.CreateNewUser(user);
            return Ok(result);
        }
    }
}
