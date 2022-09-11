using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productify.DAL.Provider
{
    public interface INoSqlProvider
    {
        public IEnumerable<T> GetAll<T>();
        public T? Get<T>(string id);
        public Task<IEnumerable<T>> GetAllAsync<T>();
        public Task<T?> GetAsync<T>(string id);
        public void Create<T>(T doc);
        public Task CreateAsync<T>(T doc);
        public void Update<T>(string id, T doc);
        public Task UpdateAsync<T>(string id, T doc);
        public void Delete<T>(string id);
        public Task DeleteAsync<T>(string id);
    }
    public class NoSqlProvider : INoSqlProvider
    {
        private IMongoDatabase _mongoDatabase;

        public NoSqlProvider(IMongoDatabase database)
        {
            _mongoDatabase = database;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var collection = _mongoDatabase.GetCollection<T>($"{typeof(T).Name}s").AsQueryable();
            return collection;
        }

        public T? Get<T>(string id)
        {
            var collection = _mongoDatabase.GetCollection<T>($"{typeof(T).Name}s");
            var retVal = collection.Find(Builders<T>.Filter.Eq("id", id)).FirstOrDefault();
            return retVal;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var collection = _mongoDatabase.GetCollection<T>($"{typeof(T).Name}s").AsQueryable();
            return collection;
        }

        public async Task<T?> GetAsync<T>(string id)
        {
            var collection = _mongoDatabase.GetCollection<T>($"{typeof(T).Name}s");
            var retVal = await collection.Find(Builders<T>.Filter.Eq("id", id)).FirstOrDefaultAsync();
            return retVal;
        }

        public void Create<T>(T doc)
        {
            var collection = _mongoDatabase.GetCollection<T>($"{typeof(T).Name}s");
            collection.InsertOne(doc);
        }

        public async Task CreateAsync<T>(T doc)
        {
            var collection = _mongoDatabase.GetCollection<T>($"{typeof(T).Name}s");
            await collection.InsertOneAsync(doc);
        }

        public void Update<T>(string id, T doc)
        {
            var collection = _mongoDatabase.GetCollection<T>($"{typeof(T).Name}s");
            collection.ReplaceOne(Builders<T>.Filter.Eq("id", id), doc);
        }

        public async Task UpdateAsync<T>(string id, T doc)
        {
            var collection = _mongoDatabase.GetCollection<T>($"{typeof(T).Name}s");
            await collection.ReplaceOneAsync(Builders<T>.Filter.Eq("id", id), doc);
        }

        public void Delete<T>(string id)
        {
            var collection = _mongoDatabase.GetCollection<T>($"{typeof(T).Name}s");
            var filter = Builders<T>.Filter.Eq("id", id);
            collection.DeleteOne(filter);
        }

        public async Task DeleteAsync<T>(string id)
        {
            var collection = _mongoDatabase.GetCollection<T>($"{typeof(T).Name}s");
            var filter = Builders<T>.Filter.Eq("id", id);
            await collection.DeleteOneAsync(filter);
        }
    }
}
