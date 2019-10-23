using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using Moq;
using DomainModel.Models;
using FluentAssertions;
using Serilog.Sinks.TestCorrelator;
using System.Linq;
using System.Security.Authentication;

namespace UnitTests.ServiceTests.ValidateServiceTests
{
    [TestClass]
    public class When_Calling_Validate_With_Username : BaseValidateTest
    {
        private string token;

        public When_Calling_Validate_With_Username() : base()
        {
            this.token = this.Fixture.Create<string>();
        }

        [TestMethod]
        public void Then_ValidateToken_Is_Called_On_TokenManager()
        {
            this.sut.Validate(this.token, user.Username);
            this.tokenManager.Verify(x => x.ValidateToken(this.token), Times.Once);
        }

        [TestMethod]
        public void Then_GetUser_Is_Called_On_UsersRepository_With_Correct_Guid()
        {
            this.sut.Validate(this.token, user.Username);
            this.usersRepo.Verify(x => x.GetUser(this.user.Username), Times.Once);
        }

        [TestMethod]
        public void Then_Error_Is_Thrown_If_User_Is_Null()
        {
            this.usersRepo.Setup(x => x.GetUser(It.IsAny<Guid>())).Returns((User)null);
            Action action = () => this.sut.Validate(this.token);
            action.Should().Throw<KeyNotFoundException>().WithMessage($"Could not find user");
        }
        
        [TestMethod]
        public void Then_Error_Is_Logged_If_User_Is_Null()
        {
            using (TestCorrelator.CreateContext())
            {
                this.usersRepo.Setup(x => x.GetUser(It.IsAny<Guid>())).Returns((User)null);
                try
                {
                    this.sut.Validate(this.token);
                }
                catch
                {
                }
                TestCorrelator.GetLogEventsFromCurrentContext().FirstOrDefault().RenderMessage()
                    .Should().Contain($"could not find user with id: \"{this.userId}\"");
            }
        }        
        
        [TestMethod]
        public void Then_Error_Is_Thrown_If_UserId_Does_Not_Equal_User()
        {
            this.usersRepo.Setup(x => x.GetUser(It.IsAny<Guid>())).Returns(this.Fixture.Create<User>());
            Action action = () => this.sut.Validate(this.token);
            action.Should().Throw<AuthenticationException>().WithMessage("Token is not valid");
        }
        
        [TestMethod]
        public void Then_Error_Is_Logged_If_UserId_Does_Not_Equal_User()
        {
            using (TestCorrelator.CreateContext())
            {
                this.usersRepo.Setup(x => x.GetUser(It.IsAny<Guid>())).Returns(this.Fixture.Create<User>());
                try
                {
                    this.sut.Validate(this.token);
                }
                catch
                {
                }
                TestCorrelator.GetLogEventsFromCurrentContext().FirstOrDefault().RenderMessage()
                    .Should().Contain("Token is not valid");
            }
        }

        [TestMethod]
        public void Then_UserId_Is_Returned()
        {
            var user = this.sut.Validate(this.token);
            user.Should().Be(this.userId);
        }
    }
}
