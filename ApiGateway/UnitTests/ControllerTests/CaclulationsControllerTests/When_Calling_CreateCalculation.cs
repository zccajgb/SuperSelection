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
using Newtonsoft.Json;

namespace UnitTests.ControllerTests.CaclulationsControllerTests
{
    [TestClass]
    public class When_Calling_CreateCalculation : BaseTest
    {
        private readonly Mock<ICalculationsRepository> mockCalculationsRepository;
        private readonly CalculationsController sut;

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
                var calc = this.Fixture.Create<SelectivityCalculation>();
                sut.ModelState.AddModelError("test", "test");
                var res = await this.sut.CreateSelectivityCalculation("string", calc);
                TestCorrelator.GetLogEventsFromCurrentContext().FirstOrDefault().RenderMessage()
                    .Should().Contain("Calculation model is invalid: Calculation");
                res.Result.Should().BeOfType<BadRequestObjectResult>();
            }
        }        
        
        [TestMethod]
        public async Task Then_Returns_Ok()
        {
            var calc = this.Fixture.Create<SelectivityCalculation>();
            var res = await this.sut.CreateSelectivityCalculation("string", calc);
            res.Result.Should().BeOfType<OkObjectResult>();
        }

        [TestMethod]
        public async Task Then_Calls_PostCommand_With_Correct_Command()
        {
            var calc = this.Fixture.Create<SelectivityCalculation>();
            var json = JsonConvert.SerializeObject(calc);
            try
            {
                var res = await this.sut.CreateSelectivityCalculation("string", calc);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            this.mockCalculationsRepository.Verify(x =>
            x.PostCommand(It.Is<CreateSelectivityCalculationCommand>(cmd =>
                cmd.Name == "Name"
                )), Times.Once());
        }
    }
}
