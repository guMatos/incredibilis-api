using System.Collections.Generic;

namespace Incredibilis.Domain.Rates
{
    public class RateExchangeRequest
    {
        public string Base { get; set; }

        public IEnumerable<string> Symbols { get; set; }
    }
}
