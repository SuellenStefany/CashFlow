using CashFlow.Transaction.Domain.Entities;

namespace CashFlow.Transaction.Application.Interfaces
{
    public interface ICreditEntryRepository
    {
        Task CreditEntryAsync(DCEntry dcEntry);
    }
}
