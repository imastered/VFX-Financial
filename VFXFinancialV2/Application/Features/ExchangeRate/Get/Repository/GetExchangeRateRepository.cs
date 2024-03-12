using Microsoft.EntityFrameworkCore;
using VFXFinancialV2.Application.Infrastructure.Persistence;
using DomainModel = VFXFinancialV2.Application.DomainModels;

namespace VFXFinancialV2.Application.Features.ExchangeRate.Get.Repository
{
    public class GetExchangeRateRepository(ApplicationDbContext context) : IGetExchangeRateRepository
    {
        private readonly ApplicationDbContext _context = context;

        public Task<DomainModel.ExchangeRate?> GetExchangeRateAsync(string fromCurrencyCode, string toCurrencyCode)
        {
            return _context.ExchangeRates.FirstOrDefaultAsync(er => er.FromCurrencyCode == fromCurrencyCode && er.ToCurrencyCode == toCurrencyCode);

        }
    }
}
