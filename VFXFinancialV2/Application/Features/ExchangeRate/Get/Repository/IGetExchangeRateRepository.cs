using DomainModel = VFXFinancialV2.Application.DomainModels;

namespace VFXFinancialV2.Application.Features.ExchangeRate.Get.Repository
{
    public interface IGetExchangeRateRepository
    {
        DomainModel.ExchangeRate GetExchangeRate(string fromCurrencyCode, string toCurrencyCode);
    }
}
