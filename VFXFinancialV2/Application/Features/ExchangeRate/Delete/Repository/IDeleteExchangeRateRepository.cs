using DomainModel = VFXFinancialV2.Application.DomainModels;

namespace VFXFinancialV2.Application.Features.ExchangeRate.Delete.Repository
{
    public interface IDeleteExchangeRateRepository
    {
        Task<DomainModel.ExchangeRate?> DeleteAsync(Guid id);
    }
}
