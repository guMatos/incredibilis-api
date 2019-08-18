using System;
using System.Threading.Tasks;
using Incredibilis.Domain.Rates;
using Incredibilis.Infra.Wrapper;
using RestEase;

namespace Incredibilis.Business.Rates
{
    public class RateExchangeApiService : IRateExchangeApiService
    {
        IConfigurationWrapper configuration;

        public RateExchangeApiService(IConfigurationWrapper configuration)
        {
            this.configuration = configuration;
        }

        public async Task<RateExchange> GetRateExchangeAsync(RateExchangeRequest request)
        {
            var api = RestClient.For<IRateExchageApi>(configuration.ExchangeRatesApi);

            var rateExchange = await api.GetRateExchangeAsync(request.Base, request.Symbols);
            return rateExchange;
        }
    }
}
