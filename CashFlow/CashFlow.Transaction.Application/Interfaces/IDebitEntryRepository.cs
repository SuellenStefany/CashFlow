using CashFlow.Transaction.Domain.Entities;

namespace CashFlow.Transaction.Application.Interfaces
{
    public interface IDebitEntryRepository
    {
        Task DebitEntryAsync(DCEntry dcEntry);
    }
}
