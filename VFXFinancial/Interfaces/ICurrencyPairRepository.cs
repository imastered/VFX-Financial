using VFXFinancial.Models;

namespace VFXFinancial.Interfaces
{
    public interface ICurrencyPairRepository
    {
        Task<CurrencyPair> GetId(string fromCurrency, string toCurrency);
    }
}
