using DomainModel = VFXFinancialV2.Application.DomainModels;

namespace VFXFinancialV2.Application.Features.ExchangeRate.Get.Repository
{
    public interface IGetExchangeRateRepository
    {
        Task<DomainModel.ExchangeRate?> GetExchangeRateAsync(string fromCurrencyCode, string toCurrencyCode);
    }
}
