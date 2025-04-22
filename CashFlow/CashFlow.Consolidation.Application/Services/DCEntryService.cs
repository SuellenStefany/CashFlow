using CashFlow.Consolidation.Application.DTOs;
using CashFlow.Consolidation.Application.Interfaces;
using CashFlow.Consolidation.Domain.Enums;

namespace CashFlow.Consolidation.Application.Services
{
    public class DCEntryService : IDCEntryService
    {
        private readonly IDCEntryRepository _dcEntryRepository;
        public DCEntryService(IDCEntryRepository dcEntryRepository)
        {
            _dcEntryRepository = dcEntryRepository;
        }
        public async Task<DCEntryDto> GetDailyConsolidated()
        {
            var entries = await _dcEntryRepository.GetDailyConsolidated(DateTime.UtcNow);

            var credit = entries.Where(e => e.Type == TransactionType.Credit).Sum(e => e.Value);
            var debit = entries.Where(e => e.Type == TransactionType.Debit).Sum(e => e.Value);

            return new DCEntryDto()
                { 
                TotalValue = credit - debit,
                CreditValue = credit,
                DebitValue = debit,
            };
        }
    }
}
