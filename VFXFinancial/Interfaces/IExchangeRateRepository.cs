using VFXFinancial.Models;

namespace VFXFinancial.Interfaces
{
    public interface IExchangeRateRepository
    {
        Task<List<ExchangeRate>> GetAllAsync();
    }
}
