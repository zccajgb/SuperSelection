using System;
using System.Collections.Generic;
using DomainModel;
using DomainModel.Models;
using DomainModel.Repositories;
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
        public ActionResult<IEnumerable<UserView>> Get()
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
        public ActionResult<UserView> CreateNewUser([FromBody] User user)
        {
            return Ok(this.createNewUserService.CreateNewUser(user.Username, user.Password, user.FirstName, user.LastName););
        }

        [HttpPost]
        [Route("/Login")]
        public ActionResult<UserView> Login([FromBody] User user)
        {
            return this.loginService.Login(user.Username, user.Password);
        }
    }
}