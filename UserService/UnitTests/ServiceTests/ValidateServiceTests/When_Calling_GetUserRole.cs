using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using FluentAssertions;

namespace UnitTests.ServiceTests.ValidateServiceTests
{
    [TestClass]
    public class When_Calling_GetUserRole : BaseValidateTest
    {
        private string token;

        public When_Calling_GetUserRole() : base()
        {
            this.token = this.Fixture.Create<string>();
        }

        [TestMethod]
        public void Then_User_Role_Is_Returned()
        {
            var id = this.sut.GetUserRole(token);
            id.Should().Be(1);
        }
    }
}
