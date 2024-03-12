namespace VFXFinancial.Models
{
    public class CurrencyPair
    {
        // Primary Key
        public Guid Id { get; set; }

        public string? FromCurrencyName { get; set; }

        public required string FromCurrencyCode { get; set; }

        public string? ToCurrencyName { get; set; }

        public required string ToCurrencyCode { get; set; }
        
        // Navigation
        public ExchangeRate ExchangeRate { get; set; }
    }
}
