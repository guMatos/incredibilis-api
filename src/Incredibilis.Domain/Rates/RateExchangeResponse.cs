using System.Collections.Generic;

namespace Incredibilis.Domain.Rates
{
    public class RateExchangeResponse
    {
        public string BaseCurrency { get; set; }

        public decimal BaseValue { get; set; }

        public IEnumerable<Rate> Rates { get; set; }
    }
}
