namespace VFXFinancialV2.Application.Features.ExchangeRate.Get.Dtos
{
    public record GetExchangeRateResponseDto
    {
        public string? FromCurrencyName { get; set; }

        public required string FromCurrencyCode { get; set; }

        public string? ToCurrencyName { get; set; }

        public required string ToCurrencyCode { get; set; }

        public required decimal Value { get; set; }

        public decimal Bid { get; set; }

        public decimal Ask { get; set; }

        public DateTime LastRefreshed { get; set; }
    }
}
