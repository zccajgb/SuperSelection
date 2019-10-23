namespace UnitTests
{
    using System.Net.Http;
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using AutoMapper;
    using DomainModel.Infrastructure;
    using Moq;
    using Serilog;

    public abstract class BaseTest
    {
        public BaseTest()
        {
            this.Fixture = new Fixture();
            this.Fixture.Customize(new AutoMoqCustomization());
            Log.Logger = new LoggerConfiguration().WriteTo.TestCorrelator().CreateLogger();
            this.SetupHttpClient();
            this.SetupAutoMapper();
        }

        public Fixture Fixture { get; }

        private void SetupAutoMapper()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            this.Fixture.Register<IMapper>(() => mapper);
        }

        private void SetupHttpClient()
        {
            var mockHttpClient = new Mock<HttpClient>();
            this.Fixture.Register<HttpClient>(() => mockHttpClient.Object);
        }
    }
}
