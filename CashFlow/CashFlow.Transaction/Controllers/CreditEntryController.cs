using CashFlow.Transaction.Application.DTOs;
using CashFlow.Transaction.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Transaction.API.Controllers
{
    [ApiController]
    [Route("transaction/credit")]
    public class CreditEntryController : ControllerBase
    {
        private readonly ICreditEntryService _dcEntryService;

        public CreditEntryController(ICreditEntryService creditEntryService)
        {
            _dcEntryService = creditEntryService;
        }
        [HttpPost]
        public async Task<ActionResult> Post(CreateDCEntryDto createDCEntry)
        {
            await _dcEntryService.CreditEntryAsync(createDCEntry);
            return Ok("Credit Entry created successfully.");
        }
    }
}
