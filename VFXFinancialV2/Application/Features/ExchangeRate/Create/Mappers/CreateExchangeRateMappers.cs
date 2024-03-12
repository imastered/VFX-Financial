using VFXFinancialV2.Application.Features.ExchangeRate.Create.Dtos;
using DomainModel = VFXFinancialV2.Application.DomainModels;

namespace VFXFinancialV2.Application.Features.ExchangeRate.Create.Mappers
{
    public static class CreateExchangeRateMappers
    {
        public static DomainModel.ExchangeRate ToDomainModel(this CreateExchangeRateDto exchangeRateDto)
        {
            return new DomainModel.ExchangeRate
            {
                Id = Guid.NewGuid(),
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
