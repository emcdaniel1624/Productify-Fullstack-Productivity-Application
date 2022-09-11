using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Productify.DAL.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Productify.DAL.Factory
{
    public interface INoSqlProviderFactory
    {
        public INoSqlProvider CreateProvider();
    }
    public class NoSqlProviderFactory : INoSqlProviderFactory
    {
        private IMongoDatabase _mongoDatabase;

        public NoSqlProviderFactory(string connectionString, string databaseName)
        {
            var mongoClient = new MongoClient(connectionString);
            _mongoDatabase = mongoClient.GetDatabase(databaseName);
        }

        public INoSqlProvider CreateProvider()
        {
            return new NoSqlProvider(_mongoDatabase);
        }
    }

    public static class FactoryExtensions
    {
        public static IServiceCollection AddNoSqlProviderFactory(this IServiceCollection services, ServiceLifetime lifetime,string connectionString, string databaseName)
        {
            switch(lifetime)
            {
                case ServiceLifetime.Transient:
                    services.AddTransient<INoSqlProviderFactory>(x => new NoSqlProviderFactory(connectionString, databaseName));
                    break;
                case ServiceLifetime.Singleton:
                    services.AddSingleton<INoSqlProviderFactory>(x => new NoSqlProviderFactory(connectionString, databaseName));
                    break;
                case ServiceLifetime.Scoped:
                    services.AddScoped<INoSqlProviderFactory>(x => new NoSqlProviderFactory(connectionString, databaseName));
                    break;
                default:
                    break;
            }
            return services;
        }
    }
}
