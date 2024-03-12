using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VFXFinancialV2.Application.Features.ExchangeRate.Create.Dtos;
using VFXFinancialV2.Application.Features.ExchangeRate.Create.Mappers;
using VFXFinancialV2.Application.Features.ExchangeRate.Create.Repository;
using VFXFinancialV2.Application.Infrastructure.Persistence;

namespace VFXFinancialV2.Application.Features.ExchangeRate.Create
{
    [Route("api/exchangeRate")]
    [ApiController]
    public class CreateExchangeRateController(ApplicationDbContext context, ICreateExchangeRateRepository exchangeRateRepo) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;
        private readonly ICreateExchangeRateRepository _exchangeRateRepo = exchangeRateRepo;

        [HttpPost]
        public async Task<IActionResult> CreateExchangeRate([FromBody] CreateExchangeRateDto createExchangeRateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exchangeRateModel = createExchangeRateDto.ToDomainModel();
            var exists = await _context.ExchangeRates.AnyAsync(er => er.FromCurrencyCode == exchangeRateModel.FromCurrencyCode && er.ToCurrencyCode == exchangeRateModel.ToCurrencyCode);
            if (exists) { return Conflict(); };

            await _exchangeRateRepo.CreateAsync(exchangeRateModel);

            return Created();
        }
    }
}
