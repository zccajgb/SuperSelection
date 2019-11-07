using ApiGateway.Models.DomainModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using ApiGateway.Infrastructure;

namespace UnitTests.InfrastructureTests.CommandBuilderTests
{
    [TestClass]
    public class When_Calling_BuildJson : BaseTest
    {
        [TestMethod]
        public void Then_Json_With_Correct_Payload_Is_Created()
        {
            var obj = this.Fixture.Create<SelectivityCalculation>();
            var json = CommandBuilder.BuildJson(obj);
            Assert.IsTrue(json.Contains($"\"Type\":\"{obj.GetType().Name}\""));
            Assert.IsTrue(json.Contains($"\\\"Name\\\":\\\"{obj.Name}\\\""));
        }
    }
}
