using ApiGateway.Infrastructure;
using ApiGateway.Repos;
using AutoMapper;
using DomainModel.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Serilog;
using Serilog.Core;

namespace ApiGateway.IOC
{
    public static class DependencyInjection
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<HttpHelper>();
            RegisterAutomapper(services);
            //services.AddScoped(typeof(UsersRepository));
            RegisterRepos(services);
        }

        private static void RegisterRepos(IServiceCollection services)
        {
            var repoNamespace = "ApiGateway.Repos";
            var repos = GetTypes().Where(x => x.Namespace.Contains(repoNamespace) && !x.IsAbstract && !x.IsSealed && x.IsClass);
            var interfaces = GetTypes().Where(x => x.Namespace.Contains(repoNamespace) && x.IsInterface);

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
