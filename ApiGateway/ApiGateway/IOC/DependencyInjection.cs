namespace ApiGateway.IOC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using ApiGateway.Infrastructure;
    using AutoMapper;
    using DomainModel.Infrastructure;
    using Microsoft.Extensions.DependencyInjection;
    using Serilog;
    using Serilog.Core;

    public static class DependencyInjection
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<HttpHelper>();
            RegisterFrontEndLogger(services);
            RegisterAutomapper(services);
            RegisterRepos(services);
        }

        public static Logger GetLogger()
        {
            return new LoggerConfiguration()
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Month)
                .CreateLogger();
        }

        private static void RegisterRepos(IServiceCollection services)
        {
            var repoNamespace = "ApiGateway.Repos";

            var repos = GetClassesByNameSpace(repoNamespace);
            var interfaces = GetInterfacesByNameSpace(repoNamespace);

            foreach (var item in repos.Zip(interfaces, (r, i) => new { repo = r, inter = i }))
            {
                services.AddTransient(item.inter, item.repo);
            }
        }

        private static void RegisterAutomapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);
        }

        private static IEnumerable<Type> GetClassesByNameSpace(string namesp)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var classes = assembly.GetTypes().Where(x => !x.IsAbstract && !x.IsInterface && !x.IsSealed && x.IsClass);
            return classes.Where(x => x.Namespace.Contains(namesp));
        }

        private static IEnumerable<Type> GetInterfacesByNameSpace(string namesp)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var classes = assembly.GetTypes().Where(x => x.IsInterface);
            return classes.Where(x => x.Namespace.Contains(namesp));
        }

        private static void RegisterFrontEndLogger(IServiceCollection services)
        {
            var feLogger = new LoggerConfiguration()
                .WriteTo.File("../../website/log.txt", rollingInterval: RollingInterval.Month)
                .CreateLogger();
            services.AddSingleton<ILogger>(feLogger);
        }
    }
}
