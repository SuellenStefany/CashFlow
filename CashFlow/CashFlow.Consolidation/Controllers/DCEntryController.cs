using CashFlow.Consolidation.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Transaction.API.Controllers
{
    [ApiController]
    [Route("consolidation")]
    public class DCEntryController : ControllerBase
    {
        private readonly IDCEntryService _dcEntryService;
        public DCEntryController(IDCEntryService dcEntryService)
        {
            _dcEntryService = dcEntryService;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok( await _dcEntryService.GetDailyConsolidated());
        }
    }
}
