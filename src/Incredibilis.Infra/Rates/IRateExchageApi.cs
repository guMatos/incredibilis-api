using System.Threading.Tasks;
using Incredibilis.Domain.Rates;
using RestEase;

namespace Incredibilis.Infra.Rates
{
    public interface IRateExchageApi
    {
        [Get("latest?{request}")]
        Task<RateExchange> GetRateExchangeAsync([Path] RateExchangeRequest request);
    }
}
