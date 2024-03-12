using Microsoft.EntityFrameworkCore;
using VFXFinancial.Models;

namespace VFXFinancial.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CurrencyPair> CurrencyPairs { get; set; }

        public DbSet<ExchangeRate> ExchangeRates { get; set; }

    }
}
