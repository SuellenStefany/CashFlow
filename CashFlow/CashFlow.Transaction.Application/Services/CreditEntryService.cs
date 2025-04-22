using CashFlow.Transaction.Application.DTOs;
using CashFlow.Transaction.Application.Interfaces;
using CashFlow.Transaction.Domain.Entities;
using CashFlow.Transaction.Domain.Enums;

namespace CashFlow.Transaction.Application.Services
{
    public class CreditEntryService : ICreditEntryService
    {
        private readonly ICreditEntryRepository _creditEntryRepository;
        public CreditEntryService(ICreditEntryRepository creditEntryRepository)
        {
            _creditEntryRepository = creditEntryRepository;
        }
        public Task CreditEntryAsync(CreateDCEntryDto dcEntry)
        {
            var entries = new DCEntry(dcEntry.Value, TransactionType.Credit);
            return _creditEntryRepository.CreditEntryAsync(entries);
        }
    }
}
