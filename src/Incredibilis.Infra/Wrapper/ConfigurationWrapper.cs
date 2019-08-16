using Microsoft.Extensions.Configuration;

namespace Incredibilis.Infra.Wrapper
{
	public class ConfigurationWrapper : IConfigurationWrapper
	{
		private readonly IConfiguration configuration;

		public ConfigurationWrapper(IConfiguration configuration)
			=> this.configuration = configuration;

		public string MongoConnectionString => configuration[nameof(MongoConnectionString)];
		public string MongoDatabase => configuration[nameof(MongoDatabase)];
		public string ExchangeRatesApi => configuration[nameof(ExchangeRatesApi)];
	}
}
