using DomainModel = VFXFinancialV2.Application.DomainModels;

namespace VFXFinancialV2.Application.Features.ExchangeRate.Create.Repository
{
    public interface ICreateExchangeRateRepository
    {
        Task<DomainModel.ExchangeRate> CreateAsync(DomainModel.ExchangeRate exchangeRate);
    }
}
