using System;
using System.Threading.Tasks;
using Incredibilis.Domain.Rates;
using Incredibilis.Infra.Wrapper;
using RestEase;

namespace Incredibilis.Infra.Rates
{
    public class RateExchangeApiService
    {
        IConfigurationWrapper configuration;

        public RateExchangeApiService(IConfigurationWrapper configuration)
        {
            this.configuration = configuration;
        }

        public async Task<RateExchange> GetRateExchangeAsync([Path] RateExchangeRequest request)
        {
            var api = RestClient.For<IRateExchageApi>(configuration.ExchangeRatesApi);

            var rateExchange = await api.GetRateExchangeAsync(request) ?? throw new Exception("Requisição para Api de conversão falhou");
            return rateExchange;
        }
    }
}
