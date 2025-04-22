using CashFlow.Transaction.Application.DTOs;
using CashFlow.Transaction.Domain.Entities;

namespace CashFlow.Transaction.Application.Interfaces
{
    public interface ICreditEntryService
    {
        Task CreditEntryAsync(CreateDCEntryDto dcEntry);
    }
}

