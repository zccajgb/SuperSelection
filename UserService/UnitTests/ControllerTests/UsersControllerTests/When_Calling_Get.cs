using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using DomainModel.Models;

namespace UnitTests.ControllerTests.UsersControllerTests
{
    [TestClass]
    public class When_Calling_Get : BaseUsersControllerTest
    {
        [TestMethod]
        public void Then_GetUsers_Is_Called_On_Repository()
        {
            _ = this.sut.Get();
            this.usersRepository.Verify(x => x.GetUsers(), Times.Once);
        }        
        
        [TestMethod]
        public void Then_Ok_Of_Users_Is_Returned()
        {
            var ok = this.sut.Get();
            ok.Result.Should().BeAssignableTo<OkObjectResult>();
            ok.Should().BeAssignableTo<ActionResult<IEnumerable<UserView>>>();
        }
    }
}
