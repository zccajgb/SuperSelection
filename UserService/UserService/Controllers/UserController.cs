using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
using DomainModel.Models;
using DomainModel.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersRepository userRepository;
        private readonly ValidateService validateService;
        private readonly CreateNewUserService createNewUserService;
        private readonly LoginService loginService;

        public UserController(IUsersRepository userRepository, ValidateService validateService, CreateNewUserService createNewUserService, LoginService loginService)
        {
            this.userRepository = userRepository;
            this.validateService = validateService;
            this.createNewUserService = createNewUserService;
            this.loginService = loginService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(this.userRepository.GetUsers());
        }

        [HttpPost]
        [Route("/GetUserID")]
        public ActionResult<Guid> GetUserID([FromBody] string token)
        {
            return this.validateService.Validate(token);
        }

        [HttpPost]
        [Route("/CreateNewUser")]
        public ActionResult CreateNewUser([FromBody] User user)
        {
            this.createNewUserService.CreateNewUser(user.Username, user.Password, user.FirstName, user.LastName);
            return Ok();
        }

        [HttpPost]
        [Route("/Login")]
        public ActionResult<string> Login([FromBody] User user)
        {
            return this.loginService.Login(user.Username, user.Password);
        }
    }
}