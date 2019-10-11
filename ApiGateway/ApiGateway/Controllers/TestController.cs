using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiGateway.Documents.Commands;
using ApiGateway.Documents.Queries;
using ApiGateway.Models;
using ApiGateway.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly UsersRepository usersRepository;

        public TestController(UsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        [HttpGet]
        public string Get()
        {
            return "got";
        }

        [HttpGet]
        [Route("test2")]
        public string TestGetBG1()
        {
            return "hello world";
        }

        [HttpPost]
        public string TestPostBG2([FromBody] string str)
        {
            str = str + "/n hello world";
            return str;
        }
    }
}
