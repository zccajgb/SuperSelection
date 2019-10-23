using AutoFixture;
using DomainModel;
using DomainModel.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UserService.Controllers;

namespace UnitTests.ControllerTests.UsersControllerTests
{
    public abstract class BaseUsersControllerTest : BaseTest
    {
        protected Mock<IUsersRepository> usersRepository;
        protected Mock<IValidateService> validateService;
        protected Mock<ICreateNewUserService> createNewUserService;
        protected Mock<ILoginService> loginService;
        protected UserController sut;

        public BaseUsersControllerTest() : base()
        {
            this.usersRepository = this.Fixture.Freeze<Mock<IUsersRepository>>();
            this.validateService = this.Fixture.Freeze<Mock<IValidateService>>();
            this.createNewUserService = this.Fixture.Freeze<Mock<ICreateNewUserService>>();
            this.loginService = this.Fixture.Freeze<Mock<ILoginService>>();
            this.sut = new UserController(usersRepository.Object, validateService.Object, createNewUserService.Object, loginService.Object);
        }
    }
}
