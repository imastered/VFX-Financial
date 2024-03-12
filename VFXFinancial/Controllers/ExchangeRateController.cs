using Microsoft.AspNetCore.Mvc;
using VFXFinancial.Data;
using VFXFinancial.Dtos;
using VFXFinancial.Interfaces;

namespace VFXFinancial.Controllers
{
    [Route("api/exchangeRate")]
    [ApiController]
    public class ExchangeRateController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IExchangeRateRepository _exchangeRateRepo;

        public ExchangeRateController(ApplicationDbContext dbContext, IExchangeRateRepository exchangeRateRepo)
        {
            _context = dbContext;
            _exchangeRateRepo = exchangeRateRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(
            [FromQuery] GetExchangeRateDto getExchangeRateDto,
            CancellationToken cancellationToken)
        {
            var exchangeRates = _exchangeRateRepo.GetAllAsync();

            return Ok(exchangeRates);
        }
    }
}
