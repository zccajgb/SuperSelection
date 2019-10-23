using DomainModel;
using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainModel.Models;
using Moq;
using DomainModel.Repositories;
using DomainModel.Infrastructure;
using FluentAssertions;
using Serilog.Sinks.TestCorrelator;
using System.Linq;

namespace UnitTests.ServiceTests.LoginServiceTests
{
    [TestClass]
    public class When_Calling_Login : BaseTest
    {
        private readonly Mock<IUsersRepository> usersRepo;
        private readonly string hashedPassword;
        private readonly User user;
        private readonly Mock<ITokenManager> tokenManager;
        private readonly LoginService sut;

        public When_Calling_Login()
        {
            this.usersRepo = this.Fixture.Freeze<Mock<IUsersRepository>>();
            this.hashedPassword = PasswordHasher.HashPassword("password", "salt");
            this.user = new User("user", "email", this.hashedPassword, "first", "last", default, 1, DateTime.Now, DateTime.Now, "salt");
            this.usersRepo.Setup(x => x.GetUser(It.IsAny<Guid>())).Returns(user);
            this.usersRepo.Setup(x => x.GetUser(It.IsAny<string>())).Returns(user);

            this.tokenManager = this.Fixture.Freeze<Mock<ITokenManager>>();
            this.tokenManager.Setup(x => x.GenerateToken(user)).Returns("token");
            this.sut = this.Fixture.Create<LoginService>();
        }

        [TestMethod]
        public void Then_GetUser_Is_Called_On_UsersRepository_With_Correct_Args()
        {
            this.sut.Login(this.user.Username, this.user.Password);
            this.usersRepo.Verify(x => x.GetUser(this.user.Username), Times.Once);
        }

        [TestMethod]
        public void Then_Null_Is_Returned_And_Error_Is_Logged_If_Password_Is_Incorrect()
        {
            using (TestCorrelator.CreateContext())
            {
                var res = this.sut.Login(user.Username, "IncorrectPassword");
                res.Should().BeNull();
                TestCorrelator.GetLogEventsFromCurrentContext().FirstOrDefault().RenderMessage()
                    .Should().Contain($"Password is incorrect");
            }
        }

        [TestMethod]
        public void Then_Correct_UserView_Is_Returned_And_Message_Is_Logged()
        {
            using (TestCorrelator.CreateContext())
            {
                var res = this.sut.Login(user.Username, "password");
                res.Should().BeOfType<UserView>();
                res.Username.Should().Be(user.Username);
                res.Email.Should().Be(user.Email);
                res.FirstName.Should().Be(user.FirstName);
                res.LastName.Should().Be(user.LastName);
                res.UserId.Should().Be(user.UserId);
                res.Token.Should().Be("token");

                TestCorrelator.GetLogEventsFromCurrentContext().FirstOrDefault().RenderMessage()
                    .Should().Contain($"Token generated for user: \"{user.Username}\"");
            }
        }
    }
}
