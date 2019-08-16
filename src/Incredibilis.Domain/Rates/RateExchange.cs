using System;
using System.Collections.Generic;

namespace Incredibilis.Domain.Rates
{
    public class RateExchange
    {
        public IDictionary<string, decimal> Rates { get; set; }

        public string Base { get; set; }

        public DateTime Date { get; set; }
    }
}
