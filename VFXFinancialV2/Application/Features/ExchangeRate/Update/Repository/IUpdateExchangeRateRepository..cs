using VFXFinancialV2.Application.Features.ExchangeRate.Update.Dtos;
using DomainModel = VFXFinancialV2.Application.DomainModels;

namespace VFXFinancialV2.Application.Features.ExchangeRate.Update.Repository
{
    public interface IUpdateExchangeRateRepository
    {
        Task<DomainModel.ExchangeRate?> UpdateAsync(UpdateExchangeRateDto updatedExchangeRateDto);
    }
}
