namespace VFXFinancial.Models
{
    public class ExchangeRate
    {
        // Primary Key
        public Guid Id { get; set; }

        // Navigation
        public Guid CurrencyPairId { get; set; }

        public decimal Bid { get; set; }

        public decimal Ask { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
