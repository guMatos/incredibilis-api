using System.Collections.Generic;
using System.Threading.Tasks;
using Incredibilis.Business.Rates;
using Incredibilis.Domain.Rates;
using Microsoft.AspNetCore.Mvc;

namespace Incredibilis.Presentation.Controllers
{
    [ApiController]
    [Route("api/rates")]
    public class RatesController : ControllerBase
    {
        private readonly IRateExchangeApiService apiService;

        public RatesController(IRateExchangeApiService apiService)
        {
            this.apiService = apiService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IEnumerable<RateExchangeResponse>> Calculate([FromBody]RateExchangeRequest request)
            => await apiService.CalculatesRateExchange(request);
    }
}
