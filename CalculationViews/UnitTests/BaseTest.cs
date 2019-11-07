using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace UnitTests
{
    public abstract class BaseTest
    {

        public BaseTest()
        {
            this.Fixture = new Fixture();
            this.Fixture.Customize(new AutoMoqCustomization());
            //Log.Logger = new LoggerConfiguration().WriteTo.TestCorrelator().CreateLogger();
            //SetupHttpClient();
            //SetupAutoMapper();
        }

        //private void SetupAutoMapper()
        //{
        //    var mappingConfig = new MapperConfiguration(mc =>
        //    {
        //        mc.AddProfile(new MapperProfile());
        //    });

        //    IMapper mapper = mappingConfig.CreateMapper();
        //    this.Fixture.Register<IMapper>(() => mapper);
        //}

        //private void SetupHttpClient()
        //{
        //    var mockHttpClient = new Mock<HttpClient>();
        //    this.Fixture.Register<HttpClient>(() => mockHttpClient.Object);
        //}

        public Fixture Fixture { get; }
    }
}
