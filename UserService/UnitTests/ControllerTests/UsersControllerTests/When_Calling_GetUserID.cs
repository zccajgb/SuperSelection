using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.ControllerTests.UsersControllerTests
{
    [TestClass]
    public class When_Calling_GetUserID : BaseUsersControllerTest
    {
        public When_Calling_GetUserID() : base()
        {
            this.validateService.Setup(x => x.Validate(It.IsAny<string>())).Returns(new Guid());
        }

        [TestMethod]
        public void Then_Validate_Is_Called_On_ValidateService()
        {
            var user = this.Fixture.Create<string>();
            _ = this.sut.GetUserID(user);
            this.validateService.Verify(x => x.Validate(user), Times.Once);
        }

        [TestMethod]
        public void Then_Ok_Of_Guid_Is_Returned()
        {
            var user = this.Fixture.Create<string>();
            var ok = this.sut.GetUserID(user);
            ok.Result.Should().BeAssignableTo<OkObjectResult>();
            ok.Should().BeAssignableTo<ActionResult<Guid>>();
        }
    }
}
