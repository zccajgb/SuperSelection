using ApiGateway.Infrastructure;
using ApiGateway.Repos;
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
            //services.AddScoped(typeof(UsersRepository));
            RegisterRepos(services);
        }

        private static void RegisterRepos(IServiceCollection services)
        {
            var repoNamespace = "ApiGateway.Repos";
            var repos = GetTypes().Where(x => x.Namespace.Contains(repoNamespace) && !x.IsAbstract && !x.IsSealed && x.IsClass);
            
            repos.Select(r => services.AddTransient(r)).ToList();
        }

        private static IEnumerable<Type> GetTypes()
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetTypes();
        }

    }
}
