using CashFlow.Transaction.Application.Interfaces;
using CashFlow.Transaction.Domain.Entities;
using CashFlow.Transaction.Infrastructure.Data;
using MongoDB.Driver;

namespace CashFlow.Transaction.Infrastructure.Repositories
{
    public class CreditEntryRepository : ICreditEntryRepository
    {
        private readonly DCEntryContext _DCEntryContext;
        public CreditEntryRepository(DCEntryContext dcEntryContext)
        {
            _DCEntryContext = dcEntryContext;
        }
        public async Task CreditEntryAsync(DCEntry dcEntry)
        {
            await _DCEntryContext.DCEntry.InsertOneAsync(dcEntry);
        }
    }
}
