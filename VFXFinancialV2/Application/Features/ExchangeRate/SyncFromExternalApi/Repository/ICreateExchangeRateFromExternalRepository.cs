using DomainModel = VFXFinancialV2.Application.DomainModels;

namespace VFXFinancialV2.Application.Features.ExchangeRate.SyncFromExternalApi.Repository
{
    public interface ICreateExchangeRateFromExternalRepository
    {
        Task<DomainModel.ExchangeRate> CreateAsync(DomainModel.ExchangeRate exchangeRate);
    }
}
