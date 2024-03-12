using Microsoft.EntityFrameworkCore;
using VFXFinancial.Data;
using VFXFinancial.Interfaces;
using VFXFinancial.Models;

namespace VFXFinancial.Repository
{
    public class ExchangeRateRepository(ApplicationDbContext context) : IExchangeRateRepository
    {
        private readonly ApplicationDbContext _context = context;

        public Task<List<ExchangeRate>> GetAllAsync()
        {
            return _context.ExchangeRates.ToListAsync();

        }

    }
}
