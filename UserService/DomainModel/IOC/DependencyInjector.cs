namespace DomainModel.IOC
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Reflection;
    using AutoMapper;
    using DomainModel.Infrastructure;
    using DomainModel.Models;
    using DomainModel.Repositories;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Serilog;
    using Serilog.Core;

    public static class DependencyInjector
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            Contract.Requires(configuration != null);

            services.AddTransient<ITokenManager, TokenManager>(_ => new TokenManager(configuration["tokenSecret"], int.Parse(configuration["TokenExpiry"])));
            RegisterAutomapper(services);
            RegisterMongoDb(services, configuration);
            RegisterRepos(services);
            RegisterServices(services);
        }

        public static Logger GetLogger()
        {
            return new LoggerConfiguration()
                .WriteTo.File("-log.txt", rollingInterval: RollingInterval.Month)
                .CreateLogger();
        }

        private static void RegisterMongoDb(IServiceCollection services, IConfiguration configuration)
        {
            // requires Microsoft.Extensions.Options.ConfigurationExtensions nuget package
            services.Configure<UsersDatabaseSettings>(configuration.GetSection(nameof(UsersDatabaseSettings)));

            services.AddSingleton<UsersDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<UsersDatabaseSettings>>().Value);
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

        private static void RegisterServices(IServiceCollection services)
        {
            var namesp = "DomainModel";
            var servs = GetTypes().Where(x => x.Namespace.EndsWith(namesp) && x.Name.EndsWith("Service")
                && !x.IsAbstract && !x.IsSealed && x.IsClass && !x.IsInterface);
            var inters = GetTypes().Where(x => x.Namespace.EndsWith(namesp) && x.Name.EndsWith("Service")
                && x.IsInterface);

            foreach (var (serv, inter) in servs.Zip(inters, (s, i) => (serv: s, inter: i)))
            {
                services.AddScoped(inter, serv);
            }
        }

        private static void RegisterRepos(IServiceCollection services)
        {
            // var repoNamespace = "DomainModel.Repositories";
            // var repos = GetTypes().Where(x => x.Namespace.Contains(repoNamespace) && !x.IsAbstract && x.IsClass && !x.IsInterface);
            // var interfaces = GetTypes().Where(x => x.Namespace.Contains(repoNamespace) && x.IsInterface);

            //foreach (var item in repos.Zip(interfaces, (r,i) => new { repo = r, inter = i }))
            //{
            //    services.AddTransient(item.inter, item.repo);
            //}

            services.AddTransient<IUsersRepository, UsersRepository>();
        }

        private static IEnumerable<Type> GetTypes()
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetTypes().Where(x => !x.IsSealed);
        }
    }
}
