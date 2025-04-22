using CashFlow.Transaction.Application.DTOs;

namespace CashFlow.Transaction.Application.Interfaces
{
    public interface IDebitEntryService
    {
        Task DebitEntryAsync(CreateDCEntryDto dcEntry);
    }
}
