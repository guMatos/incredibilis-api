using MongoDB.Driver;

namespace Incredibilis.Infra.Connection
{
	public interface IMongoConnection
	{
		IMongoCollection<T> OpenCollectionConnection<T>() where T : new();
	}
}