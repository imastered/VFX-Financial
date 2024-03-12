using Microsoft.AspNetCore.Mvc;
using VFXFinancialV2.Application.Features.ExchangeRate.Delete.Repository;

namespace VFXFinancialV2.Application.Features.ExchangeRate.Delete
{
    [Route("api/exchangeRate")]
    [ApiController]
    public class DeleteExchangeRateController(IDeleteExchangeRateRepository exchangeRateRepo) : Controller
    {
        private readonly IDeleteExchangeRateRepository _exchangeRateRepo = exchangeRateRepo;

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteExchangeRate([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exchangeRateModel = await _exchangeRateRepo.DeleteAsync(id);

            if (exchangeRateModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
