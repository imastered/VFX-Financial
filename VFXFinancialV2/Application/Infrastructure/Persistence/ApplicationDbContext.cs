using Microsoft.EntityFrameworkCore;
using VFXFinancialV2.Application.DomainModels;

namespace VFXFinancialV2.Application.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ExchangeRate> ExchangeRates { get; set; }

    }
}
