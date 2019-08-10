using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Incredibilis.Infra.Connection;

namespace Incredibilis.Infra.Repository
{
    public class GenericRepository : IGenericRepository
    {
        private readonly IMongoConnection mongoConnection;

        public GenericRepository(IMongoConnection mongoConnection)
            => this.mongoConnection = mongoConnection ?? throw new ArgumentNullException(nameof(mongoConnection));

        public IQueryable<T> All<T>() where T : class, new() => mongoConnection.OpenCollectionConnection<T>().AsQueryable();

        public Task<T> Single<T>(Expression<Func<T, bool>> expression) where T : class, new()
            => Task.FromResult(All<T>().Where(expression).SingleOrDefault());

        public IQueryable<T> Where<T>(Expression<Func<T, bool>> expression) where T : class, new()
            => All<T>().Where(expression);

        public async Task AddAsync<T>(T document) where T : class, new()
        {
            var collection = mongoConnection.OpenCollectionConnection<T>();
            await collection.InsertOneAsync(document);
        }

        public async Task ReplaceOneAsync<T>(Expression<Func<T, bool>> expression, T document) where T : class, new()
        {
            var collection = mongoConnection.OpenCollectionConnection<T>();
            await collection.ReplaceOneAsync(expression, document);
        }

        public bool CollectionExists<T>() where T : class, new()
        {
            var collection = mongoConnection.OpenCollectionConnection<T>();
            var count = collection.CountDocuments(new BsonDocument());
            return count > 0;
        }
    }
}
