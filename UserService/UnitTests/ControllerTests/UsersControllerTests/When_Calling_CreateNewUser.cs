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
    public class When_Calling_CreateNewUser : BaseUsersControllerTest
    {
        public When_Calling_CreateNewUser() : base()
        {
            var userView = this.Fixture.Create<UserView>();
            this.createNewUserService.Setup(x => x.CreateNewUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(userView);
        }
        [TestMethod]
        public void Then_AddUser_Is_Called_On_UsersRepository()
        {
            var user = this.Fixture.Create<User>();
            this.sut.CreateNewUser(user);
            this.createNewUserService.Verify(x => x.CreateNewUser(user.Username, user.Password, user.FirstName, user.LastName), Times.Once);
        }

        [TestMethod]
        public void Then_Ok_Of_UserView_Is_Returned()
        {
            var user = this.Fixture.Create<User>();
            var res = this.sut.CreateNewUser(user);
            res.Result.Should().BeOfType<OkObjectResult>();
            res.Should().BeOfType<ActionResult<UserView>>();
        }

    }
}
