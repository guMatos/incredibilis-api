using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Incredibilis.Domain.Rates
{
    public class RateExchangeRequest
    {
        [Required]
        public string BaseSymbol { get; set; }

        [Required]
        public IEnumerable<string> Symbols { get; set; }

        public decimal BaseValue { get; set; }
    }
}
