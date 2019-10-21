using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Serilog.Core;
using Serilog;

namespace DomainModel.Infrastructure
{
    public static class DependencyInjection
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration config)
        {
            RegisterRabbitMQ(services, config);
            //RegisterAutomapper(services);
            //services.AddScoped(typeof(UsersRepository));
            RegisterRepos(services);
            services.AddScoped<CalculationsOrchestrator>();
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
            var repos = GetTypes().Where(x => x.Namespace.Contains(repoNamespace) && !x.IsAbstract && !x.IsSealed && x.IsClass);

            repos.Select(r => services.AddTransient(r)).ToList();
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
            return assembly.GetTypes();
        }

        public static Logger GetLogger()
        {
            return new LoggerConfiguration()
                .WriteTo.File("-log.txt", rollingInterval: RollingInterval.Month)
                .CreateLogger();
        }

    }
}
