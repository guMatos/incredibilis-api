using System.Collections.Generic;
using System.Threading.Tasks;
using Incredibilis.Domain.Rates;
using RestEase;

namespace Incredibilis.Business.Rates
{
	public interface IRateExchangeApiService
	{
		Task<IEnumerable<RateExchangeResponse>> CalculatesRateExchange(RateExchangeRequest request);
	}
}
