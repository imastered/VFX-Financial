using VFXFinancialV2.Application.Features.ExchangeRate.Get.Dtos;
using DomainModel = VFXFinancialV2.Application.DomainModels;

namespace VFXFinancialV2.Application.Features.ExchangeRate.Get.Mappers
{
    public static class GetExchangeRateMappers
    {
        public static GetExchangeRateResponseDto ToResponseDto(this DomainModel.ExchangeRate exchangeRate)
        {
            return new GetExchangeRateResponseDto
            {
                FromCurrencyName = exchangeRate.FromCurrencyName,
                FromCurrencyCode = exchangeRate.FromCurrencyCode,
                ToCurrencyName = exchangeRate.ToCurrencyName,
                ToCurrencyCode = exchangeRate.ToCurrencyCode,
                Value = exchangeRate.Value,
                Bid = exchangeRate.Bid,
                Ask = exchangeRate.Ask,
                LastRefreshed = exchangeRate.Timestamp
            };
        }
    }
}
