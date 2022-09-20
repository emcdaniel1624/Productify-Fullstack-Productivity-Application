using MongoDB.Driver;
using NoSqlProvider.Entity;
using NoSqlProvider.Providers;
using Productify.API.Models;

namespace Productify.API.Data.Provider
{
    public class ProductifyProvider : MongoProvider
    {
        public DocumentSet<Project> Projects { get; set; }
        public ProductifyProvider(IMongoDatabase mongoDb) : base(mongoDb)
        {
        }
    }
}
