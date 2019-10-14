using ApiGateway.Infrastructure;
using ApiGateway.Models.DomainModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.InfrastructureTests.CommandBuilderTests
{
    [TestClass]
    public class When_Calling_BuildCommand : BaseTest
    {
        [TestMethod]
        public void Then_CalculationObject_Is_Build()
        {
            var json = "{\"Type\":\"Calculation\",\"Payload\":\"{\\\"Name\\\":\\\"Name\\\"}\"}";
            var obj = CommandBuilder.BuildCommand(json);
            Assert.IsInstanceOfType(obj, typeof(Calculation));
            var calc = (Calculation)obj;
            Assert.AreEqual("Name", calc.Name);
        }
    }
}
