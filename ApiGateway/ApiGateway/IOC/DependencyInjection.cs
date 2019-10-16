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
            
            repos.Select(r => services.AddTransient(r)).ToList();
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

    }
}
