namespace Incredibilis.Domain.Rates
{
    public class RateExchangeResponse
    {
        public string BaseCurrency { get; set; }

        public decimal BaseValue { get; set; }

        public string Currency { get; set; }

        public decimal Value { get; set; }
    }
}
