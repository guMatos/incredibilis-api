using System.Collections.Generic;
using System.Threading.Tasks;
using Incredibilis.Domain.Rates;
using RestEase;

namespace Incredibilis.Business.Rates
{
    public interface IRateExchageApi
    {
        [Get("latest")]
        Task<RateExchange> GetRateExchangeAsync([Query("base")] string baseCurrency, [Query] IEnumerable<string> symbols);
    }
}
