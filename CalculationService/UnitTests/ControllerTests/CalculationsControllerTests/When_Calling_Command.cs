namespace UnitTests.ControllerTests.CalculationsControllerTests
{
    using System.Collections.Generic;
    using AutoFixture;
    using CalculationService.Controllers;
    using DomainModel;
    using DomainModel.Documents.Commands;
    using DomainModel.Infrastructure;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Newtonsoft.Json;

    [TestClass]
    public class When_Calling_Command : BaseTest
    {
        private readonly List<BaseCommand> commands;
        private readonly Mock<ICalculationsOrchestrator> calculationsOrchestrator;
        private readonly CalculationsController sut;

        public When_Calling_Command()
            : base()
        {
            this.commands = new List<BaseCommand>
            {
                this.Fixture.Create<CreateSelectivityAndActivityCalculationCommand>(),
            };
            this.calculationsOrchestrator = new Mock<ICalculationsOrchestrator>();
            this.sut = new CalculationsController(this.calculationsOrchestrator.Object);
        }

        [TestMethod]
        public void Then_ProcessCommand_Is_Called_With_Correct_Command()
        {
            object command = default;
            this.calculationsOrchestrator.Setup(x => x.ProcessCalculation(It.IsAny<object>()))
                .Callback<object>(cmd => command = cmd);

            foreach (var cmd in this.commands)
            {
                var cmdObj = CommandBuilder.BuildCommandObject(cmd);
                this.sut.Command(cmdObj);
                this.calculationsOrchestrator.Verify(x => x.ProcessCalculation(It.IsAny<object>()), Times.Once);
                command.Should().BeOfType(cmd.GetType());
                command.Should().BeEquivalentTo(cmd);
            }
        }

        [TestMethod]
        public void Then_Ok_Is_Returned()
        {
            foreach (var cmd in this.commands)
            {
                var cmdObj = CommandBuilder.BuildCommandObject(cmd);
                var res = this.sut.Command(cmdObj);
                res.Should().BeOfType(typeof(OkResult));
            }
        }
    }
}
