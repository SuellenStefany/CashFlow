using CashFlow.Transaction.Application.DTOs;
using CashFlow.Transaction.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Transaction.API.Controllers
{
    [ApiController]
    [Route("transaction/debit")]
    public class DebitEntryController : ControllerBase
    {
        private readonly IDebitEntryService _dcEntryService;

        public DebitEntryController( IDebitEntryService dcEntryService)
        {
            _dcEntryService = dcEntryService;
        }
        [HttpPost]
        public async Task<ActionResult> Post(CreateDCEntryDto createDCEntry)
        {
            await _dcEntryService.DebitEntryAsync(createDCEntry);
            return Ok("Debit Entry created successfully.");
        }
    }
}
