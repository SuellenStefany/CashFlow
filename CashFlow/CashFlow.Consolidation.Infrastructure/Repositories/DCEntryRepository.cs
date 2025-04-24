using CashFlow.Consolidation.Application.Interfaces;
using CashFlow.Consolidation.Domain.Entities;
using CashFlow.Consolidation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace CashFlow.Consolidation.Infrastructure.Repositories
{
    public class DCEntryRepository : IDCEntryRepository
    {
        private readonly DCEntryContext _DCEntryContext;
        public DCEntryRepository(DCEntryContext dcEntryContext)
        {
            _DCEntryContext = dcEntryContext;
        }
        public async Task<IEnumerable<DCEntry>> GetDailyConsolidated(DateTime date)
        {
            var resultConsolidated = Builders<DCEntry>.Filter;

            var filter = resultConsolidated.And(
                resultConsolidated.Gte(entry => entry.Date, date.Date.ToUniversalTime()),
                resultConsolidated.Lt(entry => entry.Date, date.Date.AddDays(1).ToUniversalTime())
            );

            return await _DCEntryContext.DCEntry.Find(filter).ToListAsync();
        }
    }
}
