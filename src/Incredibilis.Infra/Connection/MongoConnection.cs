using Incredibilis.Infra.Wrapper;
using MongoDB.Driver;

namespace Incredibilis.Infra.Connection
{
	public class MongoConnection : IMongoConnection
	{
		private readonly IMongoDatabase database;

		public MongoConnection(IConfigurationWrapper configuration)
		{
			var connectionString = configuration.MongoConnectionString;
			var database = configuration.MongoDatabase;
			var client = new MongoClient(connectionString);
			this.database = client.GetDatabase(database);
		}

		public IMongoCollection<T> OpenCollectionConnection<T>() where T : new()
		{
			var collectionName = typeof(T).Name;
			return database.GetCollection<T>(collectionName);
		}
	}
}
