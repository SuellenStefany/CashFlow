using CashFlow.Transaction.Application.DTOs;
using CashFlow.Transaction.Application.Interfaces;
using CashFlow.Transaction.Domain.Entities;
using CashFlow.Transaction.Domain.Enums;

namespace CashFlow.Transaction.Application.Services
{
    public class DebitEntryService : IDebitEntryService
    {
        private readonly IDebitEntryRepository _dcEntryRepository;
        public DebitEntryService(IDebitEntryRepository dcEntryRepository)
        {
            _dcEntryRepository = dcEntryRepository;
        }
        public Task DebitEntryAsync(CreateDCEntryDto dcEntry)
        {
            var entries = new DCEntry(dcEntry.Value, TransactionType.Debit);
            return _dcEntryRepository.DebitEntryAsync(entries);
        }
    }
}
