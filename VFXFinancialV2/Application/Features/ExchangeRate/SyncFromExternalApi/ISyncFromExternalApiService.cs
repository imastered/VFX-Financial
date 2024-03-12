using DomainModel = VFXFinancialV2.Application.DomainModels;

namespace VFXFinancialV2.Application.Features.ExchangeRate.SyncFromExternalApi
{
    public interface ISyncFromExternalApiService
    {
        Task<DomainModel.ExchangeRate?> SyncAsync(string fromCurrencyCode, string toCurrencyCode);
    }
}
