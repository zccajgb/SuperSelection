using ApiGateway.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using ApiGateway.Models.DomainModels;
using System.Threading.Tasks;
using Serilog.Sinks.TestCorrelator;
using FluentAssertions;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApiGateway.Repos;
using Moq;
using ApiGateway.Documents.Commands;

namespace UnitTests.ControllerTests.CaclulationsControllerTests
{
    [TestClass]
    public class When_Calling_CreateCalculation : BaseTest
    {
        private Mock<ICalculationsRepository> mockCalculationsRepository;
        private CalculationsController sut;

        public When_Calling_CreateCalculation() : base()
        {
            this.mockCalculationsRepository = this.Fixture.Freeze<Mock<ICalculationsRepository>>();
            this.mockCalculationsRepository.Setup(x => x.PostCommand(It.IsAny<BaseCommand>()));
            this.sut = this.Fixture.Create<CalculationsController>();
        }

        [TestMethod]
        public async Task Then_Returns_BadRequest_And_Logs_Error_If_ModelState_Invalid()
        {
            using (TestCorrelator.CreateContext())
            {
                var calc = new Calculation("", Guid.NewGuid());
                sut.ModelState.AddModelError("test", "test");
                var res = await this.sut.CreateCalculation(calc);
                TestCorrelator.GetLogEventsFromCurrentContext().FirstOrDefault().RenderMessage()
                    .Should().Contain("Calculation model is invalid: Calculation");
                res.Result.Should().BeOfType<BadRequestObjectResult>();
            }
        }        
        
        [TestMethod]
        public async Task Then_Returns_Ok()
        {
            var calc = new Calculation("Name", Guid.NewGuid());
            var res = await this.sut.CreateCalculation(calc);
            res.Result.Should().BeOfType<OkObjectResult>();
        }

        [TestMethod]
        public async Task Then_Calls_PostCommand_With_Correct_Command()
        {
            var calc = new Calculation("Name", Guid.NewGuid());
            var res = await this.sut.CreateCalculation(calc);
            this.mockCalculationsRepository.Verify(x =>
            x.PostCommand(It.Is<CreateSelectivityAndActivityCalculationCommand>(cmd =>
                cmd.Name == "Name"
                )), Times.Once());
        }
    }
}
