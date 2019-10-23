using DomainModel;
using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using Moq;
using DomainModel.Infrastructure;
using DomainModel.Models;
using DomainModel.Repositories;

namespace UnitTests.ServiceTests.ValidateServiceTests
{
    public abstract class BaseValidateTest : BaseTest
    {
        protected Guid userId;
        protected Mock<ITokenManager> tokenManager;
        protected ValidateService sut;
        protected Mock<IUsersRepository> usersRepo;
        protected User user;

        public BaseValidateTest()
        {
            this.userId = Guid.NewGuid();
            var valid = (this.Fixture.Create<string>(), this.userId.ToString(), "1");
            this.tokenManager = this.Fixture.Freeze<Mock<ITokenManager>>();
            this.tokenManager.Setup(x => x.GenerateToken(It.IsAny<User>())).Returns(this.Fixture.Create<string>());
            this.tokenManager.Setup(x => x.ValidateToken(It.IsAny<string>())).Returns(valid);

            this.usersRepo = this.Fixture.Freeze<Mock<IUsersRepository>>();
            this.user = new User("", "", "", "", "", this.userId, 1, DateTime.Now, DateTime.Now, "");
            this.usersRepo.Setup(x => x.GetUser(It.IsAny<Guid>())).Returns(user);
            this.usersRepo.Setup(x => x.GetUser(It.IsAny<string>())).Returns(user);

            this.sut = this.Fixture.Create<ValidateService>();
        }
    }
}
