using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VFXFinancialV2.Application.Features.ExchangeRate.SyncFromExternalApi.Mappers;
using VFXFinancialV2.Application.Features.ExchangeRate.SyncFromExternalApi.Repository;
using DomainModel = VFXFinancialV2.Application.DomainModels;

namespace VFXFinancialV2.Application.Features.ExchangeRate.SyncFromExternalApi
{
    public class SyncFromExternalApiService : ISyncFromExternalApiService
    {
        private readonly ICreateExchangeRateFromExternalRepository _exchangeRateRepo;

        public SyncFromExternalApiService(ICreateExchangeRateFromExternalRepository exchangeRateRepo)
        {
            _exchangeRateRepo = exchangeRateRepo;
        }

        public async Task<DomainModel.ExchangeRate?> SyncAsync(string fromCurrencyCode, string toCurrencyCode)
        {
            var QUERY_URL = $"https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency={fromCurrencyCode}&to_currency={toCurrencyCode}&apikey=demo";
            try
            {
                using var client = new HttpClient();
                var jsonString = await client.GetStringAsync(QUERY_URL);

                if (jsonString.IsNullOrEmpty())
                {
                    return null;
                }

                var jObject = JObject.Parse(jsonString);

                if (jObject == null)
                {
                    return null;
                }

                var map = jObject["Realtime Currency Exchange Rate"];

                var newExchangeRate = map?.ToDomainModel();

                if (newExchangeRate == null)
                {
                    return null;
                }

                await _exchangeRateRepo.CreateAsync(newExchangeRate);

                return newExchangeRate;
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request exception (e.g., network issues)
                Console.WriteLine($"HTTP request exception: {ex.Message}");
            }
            catch (JsonException ex)
            {
                // Handle JSON parsing exception
                Console.WriteLine($"JSON parsing exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            return null;
        }
    }
}
