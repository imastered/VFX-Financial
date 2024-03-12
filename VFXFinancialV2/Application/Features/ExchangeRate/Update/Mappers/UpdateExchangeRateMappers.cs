using VFXFinancialV2.Application.Features.ExchangeRate.Update.Dtos;
using DomainModel = VFXFinancialV2.Application.DomainModels;

namespace VFXFinancialV2.Application.Features.ExchangeRate.Update.Mappers
{
    public static class UpdateExchangeRateMappers
    {
        public static DomainModel.ExchangeRate ToResponseDto(this UpdateExchangeRateResponseDto exchangeRateDto)
        {
            return new DomainModel.ExchangeRate
            {
                Id = exchangeRateDto.Id,
                FromCurrencyName = exchangeRateDto.FromCurrencyName,
                FromCurrencyCode = exchangeRateDto.FromCurrencyCode,
                ToCurrencyName = exchangeRateDto.ToCurrencyName,
                ToCurrencyCode = exchangeRateDto.ToCurrencyCode,
                Value = exchangeRateDto.Value,
                Bid = exchangeRateDto.Bid,
                Ask = exchangeRateDto.Ask,
                Timestamp = DateTime.Now
            };
        }
    }
}
