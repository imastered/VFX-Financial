using Newtonsoft.Json.Linq;
using DomainModel = VFXFinancialV2.Application.DomainModels;

namespace VFXFinancialV2.Application.Features.ExchangeRate.SyncFromExternalApi.Mappers
{
    public static class CreateExchangeRateFromExternalMappers
    {
        public static DomainModel.ExchangeRate ToDomainModel(this JToken jsonData)
        {
            return new DomainModel.ExchangeRate
            {
                Id = Guid.NewGuid(),
                FromCurrencyName = jsonData?["2. From_Currency Name"]?.ToString(),
                FromCurrencyCode = jsonData["1. From_Currency Code"].ToString(),
                ToCurrencyName = jsonData?["4. To_Currency Name"]?.ToString(),
                ToCurrencyCode = jsonData["3. To_Currency Code"].ToString(),
                Value = decimal.Parse(jsonData["5. Exchange Rate"].ToString()),
                Bid = decimal.Parse(jsonData["8. Bid Price"].ToString()),
                Ask = decimal.Parse(jsonData["9. Ask Price"].ToString()),
                Timestamp = DateTime.Now
            };
        }
    }
}
