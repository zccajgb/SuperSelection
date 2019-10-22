using DomainModel.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.ControllerTests.UsersControllerTests
{
    [TestClass]
    public class When_Calling_Login : BaseUsersControllerTest
    {
        public When_Calling_Login() : base()
        {
            var userView = this.Fixture.Create<UserView>();
            this.loginService.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(userView);
        }

        [TestMethod]
        public void Then_Login_Is_Called_On_LoginService()
        {
            var user = this.Fixture.Create<User>();
            _ = this.sut.Login(user);
            this.loginService.Verify(x => x.Login(user.Username, user.Password), Times.Once);
        }

        [TestMethod]
        public void Then_Ok_Of_UserView_Is_Returned()
        {
            var user = this.Fixture.Create<User>();
            var ok = this.sut.Login(user);
            ok.Result.Should().BeAssignableTo<OkObjectResult>();
            ok.Should().BeAssignableTo<ActionResult<UserView>>();
        }
    }
}
