using Microsoft.EntityFrameworkCore;
using VFXFinancialV2.Application.Features.ExchangeRate.Update.Dtos;
using VFXFinancialV2.Application.Infrastructure.Persistence;
using DomainModel = VFXFinancialV2.Application.DomainModels;

namespace VFXFinancialV2.Application.Features.ExchangeRate.Update.Repository
{
    public class UpdateExchangeRateRepository(ApplicationDbContext context) : IUpdateExchangeRateRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<DomainModel.ExchangeRate?> UpdateAsync(UpdateExchangeRateDto updatedExchangeRate)
        {
            var existingExchangeRate = await _context.ExchangeRates.FirstOrDefaultAsync(er => er.Id == updatedExchangeRate.Id);

            if (existingExchangeRate == null)
            {
                return null;
            }

            existingExchangeRate.FromCurrencyName = updatedExchangeRate.FromCurrencyName;
            existingExchangeRate.FromCurrencyCode = updatedExchangeRate.FromCurrencyCode;
            existingExchangeRate.ToCurrencyName = updatedExchangeRate.ToCurrencyName;
            existingExchangeRate.ToCurrencyCode = updatedExchangeRate.ToCurrencyCode;
            existingExchangeRate.Value = updatedExchangeRate.Value;
            existingExchangeRate.Bid = updatedExchangeRate.Bid;
            existingExchangeRate.Ask = updatedExchangeRate.Ask;

            await _context.SaveChangesAsync();

            return existingExchangeRate;
        }
    }
}
