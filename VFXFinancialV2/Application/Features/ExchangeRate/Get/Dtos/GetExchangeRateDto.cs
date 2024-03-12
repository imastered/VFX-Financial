namespace VFXFinancialV2.Application.Features.ExchangeRate.Get.Dtos
{
    public record GetExchangeRateDto
    {
        public required string FromCurrencyCode { get; set; }

        public required string ToCurrencyCode { get; set; }
    }
}
