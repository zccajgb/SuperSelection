namespace ApiGateway.Controllers
{
    using ApiGateway.Repos;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Code Quality", "IDE0052:Remove unread private members", Justification = "Tests DI")]
        private readonly IUsersRepository usersRepository;

        public TestController(IUsersRepository usersRepository)
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
            str += "/n hello world";
            return str;
        }
    }
}
