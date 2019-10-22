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
        private readonly IValidateService validateService;
        private readonly ICreateNewUserService createNewUserService;
        private readonly ILoginService loginService;

        public UserController(IUsersRepository userRepository, IValidateService validateService, ICreateNewUserService createNewUserService, ILoginService loginService)
        {
            this.userRepository = userRepository;
            this.validateService = validateService;
            this.createNewUserService = createNewUserService;
            this.loginService = loginService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserView>> Get()
        {
            var users = this.userRepository.GetUsers();
            return Ok(users);
        }

        [HttpPost]
        [Route("GetUserID")]
        public ActionResult<Guid> GetUserID([FromBody] string token)
        {
            return Ok(this.validateService.Validate(token));
        }

        [HttpPost]
        [Route("CreateNewUser")]
        public ActionResult<UserView> CreateNewUser([FromBody] User user)
        {
            var userView = this.createNewUserService.CreateNewUser(user.Username, user.Password, user.FirstName, user.LastName);
            return Ok(userView);
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<UserView> Login([FromBody] User user)
        {
            return Ok(this.loginService.Login(user.Username, user.Password));
        }
    }
}