using Microsoft.AspNetCore.Mvc;
using VFXFinancialV2.Application.Features.ExchangeRate.Get.Mappers;
using VFXFinancialV2.Application.Features.ExchangeRate.Update.Dtos;
using VFXFinancialV2.Application.Features.ExchangeRate.Update.Repository;

namespace VFXFinancialV2.Application.Features.ExchangeRate.Update
{
    [Route("api/exchangeRate")]
    [ApiController]
    public class UpdateExchangeRateController(IUpdateExchangeRateRepository exchangeRateRepo) : Controller
    {
        private readonly IUpdateExchangeRateRepository _exchangeRateRepo = exchangeRateRepo;

        [HttpPut]
        public async Task<IActionResult> UpdateExchangeRate([FromBody] UpdateExchangeRateDto updateExchangeRateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exchangeRateModel = await _exchangeRateRepo.UpdateAsync(updateExchangeRateDto);

            if (exchangeRateModel == null)
            {
                return NotFound();
            }

            return Ok(exchangeRateModel.ToResponseDto());
        }
    }
}
