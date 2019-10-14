using AutoMapper;
using DomainModel.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DomainModel.IOC
{
    public static class DependencyInjection
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<TokenManager>(_ => new TokenManager(configuration["tokenSecret"], Int32.Parse(configuration["tokenExpiry"])));
            RegisterAutomapper(services);
            RegisterRepos(services);
            RegisterServices(services);
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

            servs.Select(x => services.AddScoped(x)).ToList();
        }

        private static void RegisterRepos(IServiceCollection services)
        {
            var repoNamespace = "DomainModel.Repositories";

            var repos = GetTypes().Where(x => x.Namespace.Contains(repoNamespace) && !x.IsAbstract && x.IsClass && !x.IsInterface);
            var interfaces = GetTypes().Where(x => x.Namespace.Contains(repoNamespace) && x.IsInterface);

            foreach (var item in repos.Zip(interfaces, (r,i) => new { repo = r, inter = i }))
            {
                services.AddTransient(item.inter, item.repo);
            }
        }

        private static IEnumerable<Type> GetTypes()
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetTypes().Where(x => !x.IsSealed);
        }
    }
}
