using Microsoft.EntityFrameworkCore;
using VFXFinancialV2.Application.Infrastructure.Persistence;
using DomainModel = VFXFinancialV2.Application.DomainModels;

namespace VFXFinancialV2.Application.Features.ExchangeRate.Delete.Repository
{
    public class DeleteExchangeRateRepository(ApplicationDbContext context) : IDeleteExchangeRateRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<DomainModel.ExchangeRate?> DeleteAsync(Guid id)
        {
            var exchangeRateModel = await _context.ExchangeRates.FirstOrDefaultAsync(er => er.Id == id);

            if (exchangeRateModel == null)
            {
                return null;
            }

            _context.ExchangeRates.Remove(exchangeRateModel);
            await _context.SaveChangesAsync();
            return exchangeRateModel;
        }
    }
}
