namespace VFXFinancialV2.Application.Features.ExchangeRate.Update.Dtos
{
    public record UpdateExchangeRateResponseDto
    {
        public Guid Id { get; set; }

        public string? FromCurrencyName { get; set; }

        public required string FromCurrencyCode { get; set; }

        public string? ToCurrencyName { get; set; }

        public required string ToCurrencyCode { get; set; }

        public required decimal Value { get; set; }

        public decimal Bid { get; set; }

        public decimal Ask { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
