using Microsoft.EntityFrameworkCore;
using VFXFinancial.Data;
using VFXFinancial.Interfaces;
using VFXFinancial.Models;

namespace VFXFinancial.Repository
{
    public class CurrencyPairRepository(ApplicationDbContext context) : ICurrencyPairRepository
    {
        private readonly ApplicationDbContext _context = context;

        public Task<CurrencyPair> GetId(string fromCurrency, string toCurrency)
        {
            return _context.CurrencyPairs.FirstOrDefaultAsync(cp => cp.FromCurrencyCode == fromCurrency && cp.ToCurrencyCode == toCurrency);
        }

    }
}
