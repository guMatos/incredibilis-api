namespace Incredibilis.Infra.Wrapper
{
	public interface IConfigurationWrapper
	{
		string MongoConnectionString { get; }
		string MongoDatabase { get; }
	}
}