namespace DomainModel.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using AutoMapper;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization;
    using MongoDB.Bson.Serialization.Options;
    using MongoDB.Bson.Serialization.Serializers;

    public static class DependencyInjection
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration config)
        {
            RegisterMongoDb(services, config);
            RegisterAutomapper(services);
            RegisterRepos(services);
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

        private static void RegisterMongoDb(IServiceCollection services, IConfiguration configuration)
        {
            // requires Microsoft.Extensions.Options.ConfigurationExtensions nuget packeage
            BsonSerializer.RegisterSerializer(typeof(Guid), new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer(typeof(decimal),
                new DecimalSerializer(BsonType.Decimal128, new RepresentationConverter(true, true))
 );
            services.Configure<CalculationsDatabaseSettings>(configuration.GetSection(nameof(CalculationsDatabaseSettings)));

            services.AddSingleton<CalculationsDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<CalculationsDatabaseSettings>>().Value);
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

        private static IEnumerable<Type> GetTypes()
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetTypes().Where(x => !x.IsSealed);
        }
    }
}
