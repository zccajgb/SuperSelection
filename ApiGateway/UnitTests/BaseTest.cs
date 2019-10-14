using AutoFixture;
using AutoFixture.AutoMoq;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    public abstract class BaseTest
    {

        public BaseTest()
        {
            this.Fixture = new Fixture();
            this.Fixture.Customize(new AutoMoqCustomization());
        }

        public Fixture Fixture { get; }
    }
}
