namespace UnitTests.CalculationsOrchestratorTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AutoFixture;
    using DomainModel;
    using DomainModel.Documents.Commands;
    using DomainModel.Repos;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Serilog.Events;
    using Serilog.Sinks.TestCorrelator;

    [TestClass]
    public class When_Calling_ProcessCommand : BaseTest
    {
        private Mock<ICalculationsRepository> calculationsRepo;
        private CalculationsOrchestrator sut;

        public When_Calling_ProcessCommand()
        {
            this.calculationsRepo = this.Fixture.Freeze<Mock<ICalculationsRepository>>();
            this.sut = this.Fixture.Create<CalculationsOrchestrator>();
        }

        [TestMethod]
        public void Then_Calls_CreateSelectivityCalculation_On_Repository_And_Logs_Info()
        {
            using (TestCorrelator.CreateContext())
            {
                var cmd = this.Fixture.Freeze<CreateSelectivityCalculationCommand>();
                this.sut.ProcessCalculation(cmd);
                var logMsg = TestCorrelator.GetLogEventsFromCurrentContext().Single();

                logMsg.RenderMessage().Should().Contain("Calculation of type CreateSelectivityAndActivityCommand");
                logMsg.Level.Should().Be(LogEventLevel.Information);

                this.calculationsRepo.Verify(x => x.CreateSelectivityCalculation(cmd), Times.Once);
            }
        }

        [TestMethod]
        public void Then_Error_Is_Throw_And_Error_Is_Logged()
        {
            using (TestCorrelator.CreateContext())
            {
                object cmd = default;

                Action action = () => this.sut.ProcessCalculation(cmd);
                action.Should().Throw<ArgumentException>().WithMessage("Command is not recognised");

                var logMsg = TestCorrelator.GetLogEventsFromCurrentContext().Single();
                logMsg.RenderMessage().Should().Contain($"Command is not recognised: {cmd}");
                logMsg.Level.Should().Be(LogEventLevel.Error);
            }
        }
    }
}
