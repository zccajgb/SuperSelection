using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using DomainModel;
using DomainModel.Models;
using Moq;
using DomainModel.Repositories;
using Serilog.Sinks.TestCorrelator;
using System.Linq;
using FluentAssertions;

namespace UnitTests.ServiceTests.CreateNewUserServiceTests
{
    [TestClass]
    public class When_Calling_CreateNewUser : BaseTest
    {
        private readonly CreateNewUserService sut;
        private readonly User user;
        private readonly Mock<IUsersRepository> usersRepo;

        public When_Calling_CreateNewUser()
        {

            this.user = new User("user", "user", "password", "first", "last", new Guid(), 1, DateTime.Now, DateTime.Now, "salt");
            this.usersRepo = this.Fixture.Freeze<Mock<IUsersRepository>>();
            this.sut = this.Fixture.Create<CreateNewUserService>();
        }

        [TestMethod]
        public void Then_AddUser_On_UsersRepo_Is_Called_With_User()
        {
            this.sut.CreateNewUser(user.Username, user.Password, user.FirstName, user.LastName);
            this.usersRepo.Verify(x => x.AddUser(It.Is<User>(u =>
            (
                u.Username == user.Username && u.Email == user.Email
                && u.FirstName == user.FirstName && u.LastName == user.LastName
            ))), Times.Once);
        }

        [TestMethod]
        public void Then_Info_Is_Logged()
        {
            using (TestCorrelator.CreateContext())
            {
                this.sut.CreateNewUser(user.Username, user.Password, user.FirstName, user.LastName);
                TestCorrelator.GetLogEventsFromCurrentContext().FirstOrDefault().RenderMessage()
                    .Should().Contain($"User created with username: \"{user.Username}\"");
            }
        }

        [TestMethod]
        public void Then_Correct_UserView_Is_Returned()
        {
            var userView = this.sut.CreateNewUser(user.Username, user.Password, user.FirstName, user.LastName);
            
            userView.FirstName.Should().Be(user.FirstName);
            userView.LastName.Should().Be(user.LastName);
            userView.Username.Should().Be(user.Username);
        }

    }
}
