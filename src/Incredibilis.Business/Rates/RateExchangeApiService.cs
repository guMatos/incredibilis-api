using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<RateExchangeResponse>> CalculatesRateExchange(RateExchangeRequest request)
        {
            var exchangeRates = await GetRateExchangeAsync(request);
            var response = new List<RateExchangeResponse>();

            foreach (var rate in exchangeRates.Rates)
            {
                var value = decimal.Round(rate.Value * request.BaseValue, 2);

                response.Add(new RateExchangeResponse {
                    BaseCurrency = exchangeRates.Base,
                    BaseValue = request.BaseValue,
                    Currency = rate.Key,
                    Value = value
                });
            }

            return response;
        }

        private async Task<RateExchange> GetRateExchangeAsync(RateExchangeRequest request)
        {
            var api = RestClient.For<IRateExchageApi>(configuration.ExchangeRatesApi);

            var rateExchange = await api.GetRateExchangeAsync(request.BaseSymbol, request.Symbols);
            return rateExchange;
        }
    }
}
