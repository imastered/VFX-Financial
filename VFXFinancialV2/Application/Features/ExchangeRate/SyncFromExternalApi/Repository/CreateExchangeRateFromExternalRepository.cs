using VFXFinancialV2.Application.Infrastructure.Persistence;

namespace VFXFinancialV2.Application.Features.ExchangeRate.SyncFromExternalApi.Repository
{
    public class CreateExchangeRateFromExternalRepository (ApplicationDbContext context) : ICreateExchangeRateFromExternalRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<DomainModels.ExchangeRate> CreateAsync(DomainModels.ExchangeRate exchangeRate)
        {
            await _context.ExchangeRates.AddAsync(exchangeRate);
            await _context.SaveChangesAsync();
            return exchangeRate;
        }
    }
}
