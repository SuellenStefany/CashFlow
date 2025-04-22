using CashFlow.Transaction.Application.Interfaces;
using CashFlow.Transaction.Domain.Entities;
using CashFlow.Transaction.Infrastructure.Data;
using MongoDB.Driver;

namespace CashFlow.Transaction.Infrastructure.Repositories
{
    public class DebitEntryRepository : IDebitEntryRepository
    {
        private readonly DCEntryContext _DCEntryContext;
        public DebitEntryRepository(DCEntryContext dcEntryContext)
        {
            _DCEntryContext = dcEntryContext;
        }
        public async Task DebitEntryAsync(DCEntry dcEntry)
        {
            await _DCEntryContext.DCEntry.InsertOneAsync(dcEntry);
        }
    }
}
