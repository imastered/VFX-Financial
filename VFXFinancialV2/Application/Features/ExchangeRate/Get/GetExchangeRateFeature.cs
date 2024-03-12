using Microsoft.AspNetCore.Mvc;
using VFXFinancialV2.Application.Features.ExchangeRate.Get.Dtos;
using VFXFinancialV2.Application.Features.ExchangeRate.Get.Mappers;
using VFXFinancialV2.Application.Features.ExchangeRate.Get.Repository;
using VFXFinancialV2.Application.Features.ExchangeRate.SyncFromExternalApi;

namespace VFXFinancialV2.Application.Features.ExchangeRate.Get
{
    [Route("api/exchangeRate")]
    [ApiController]
    public class GetExchangeRateController(IGetExchangeRateRepository exchangeRateRepo, ISyncFromExternalApiService externalApi) : Controller
    {
        private readonly IGetExchangeRateRepository _exchangeRateRepo = exchangeRateRepo;
        private readonly ISyncFromExternalApiService _externalApi = externalApi;

        [HttpGet]
        public async Task<IActionResult> GetExchangeRateAsync([FromQuery] GetExchangeRateDto getExchangeRateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exchangeRate = await _exchangeRateRepo.GetExchangeRateAsync(getExchangeRateDto.FromCurrencyCode, getExchangeRateDto.ToCurrencyCode);

            if (exchangeRate == null)
            {
                var externalApiResponse = await _externalApi.SyncAsync(getExchangeRateDto.FromCurrencyCode, getExchangeRateDto.ToCurrencyCode);

                if(externalApiResponse == null)
                {
                    return Conflict();
                }

                return Ok(externalApiResponse?.ToResponseDto());

            }

            return Ok(exchangeRate.ToResponseDto());
        }
    }
}
