namespace DomainModel.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using RabbitMQ.Client;
    using Serilog;
    using Serilog.Core;

    public static class DependencyInjection
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration config)
        {
            RegisterRabbitMQ(services, config);
            RegisterRepos(services);
            services.AddScoped<ICalculationsOrchestrator, CalculationsOrchestrator>();
        }

        public static Logger GetLogger()
        {
            return new LoggerConfiguration()
                .WriteTo.File("-log.txt", rollingInterval: RollingInterval.Month)
                .CreateLogger();
        }

        private static void RegisterRabbitMQ(IServiceCollection services, IConfiguration config)
        {
            var host = config.GetConnectionString("RabbitHost");
            var user = config.GetConnectionString("RabbitUser");
            var pw = config.GetConnectionString("RabbitPassword");
            services.AddScoped(x => new RabbitMQConnectionHelper(new ConnectionFactory(), host, user, pw));
        }

        private static void RegisterRepos(IServiceCollection services)
        {
            var repoNamespace = "DomainModel.Repos";
            var repos = GetTypes().Where(x => x.Namespace.Contains(repoNamespace) && !x.IsAbstract && x.IsClass);
            var inters = GetTypes().Where(x => x.Namespace.Contains(repoNamespace) && x.IsInterface);

            foreach (var (repo, inter) in repos.Zip(inters, (r, i) => (repo: r, inter: i)))
            {
                services.AddTransient(inter, repo);
            }
        }

        //private static void RegisterAutomapper(IServiceCollection services)
        //{
        //    var mappingConfig = new MapperConfiguration(mc =>
        //    {
        //        mc.AddProfile(new MapperProfile());
        //    });

        //    IMapper mapper = mappingConfig.CreateMapper();

        //    services.AddSingleton(mapper);
        //}

        private static IEnumerable<Type> GetTypes()
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetTypes().Where(x => !x.IsSealed);
        }
    }
}
