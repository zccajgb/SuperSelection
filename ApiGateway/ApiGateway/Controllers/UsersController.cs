using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiGateway.Documents.Commands;
using ApiGateway.Documents.Queries;
using ApiGateway.Models;
using ApiGateway.Models.DomainModels;
using ApiGateway.Models.ViewModels;
using ApiGateway.Repos;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersRepository usersRepository;

        public UsersController(UsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        [HttpPost]
        [Route("Users/Login")]
        public async Task<ActionResult<UserView>> Login([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
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
                return BadRequest(ModelState);
            }

            var users = await this.usersRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        [Route("Users/CreateNewUser")]
        public async Task<ActionResult<UserView>> CreateNewUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await this.usersRepository.CreateNewUser(user);
            return Ok(result);
        }
    }
}
