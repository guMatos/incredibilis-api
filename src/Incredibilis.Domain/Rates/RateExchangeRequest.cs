using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Incredibilis.Domain.Rates
{
    public class RateExchangeRequest
    {
        [Required]
        public string Base { get; set; }

        [Required]
        public IEnumerable<string> Symbols { get; set; }
    }
}
