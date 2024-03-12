using Microsoft.EntityFrameworkCore;
using VFXFinancialV2.Application.Infrastructure.Persistence;
using DomainModel = VFXFinancialV2.Application.DomainModels;

namespace VFXFinancialV2.Application.Features.ExchangeRate.Create.Repository
{
    public class CreateExchangeRateRepository(ApplicationDbContext context) : ICreateExchangeRateRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<DomainModel.ExchangeRate> CreateAsync(DomainModel.ExchangeRate exchangeRate)
        {
            await _context.ExchangeRates.AddAsync(exchangeRate);
            await _context.SaveChangesAsync();
            return exchangeRate;
        }
    }
}
