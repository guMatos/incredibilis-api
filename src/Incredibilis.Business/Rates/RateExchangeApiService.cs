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

        public async Task<RateExchangeResponse> CalculatesRateExchange(RateExchangeRequest request)
        {
            var exchangeRates = await GetRateExchangeAsync(request);
            var rates = new List<Rate>();
            
            foreach (var rate in exchangeRates.Rates)
            {
                rates.Add(new Rate {
                    Currency = rate.Key,
                    Value = decimal.Round(rate.Value * request.BaseValue, 2)
                });
            }

            var response = new RateExchangeResponse {
                BaseCurrency = request.BaseSymbol,
                BaseValue = request.BaseValue,
                Rates = rates
            };
            
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
