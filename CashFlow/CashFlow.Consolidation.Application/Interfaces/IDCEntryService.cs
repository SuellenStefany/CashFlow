using CashFlow.Consolidation.Application.DTOs;

namespace CashFlow.Consolidation.Application.Interfaces
{
    public interface IDCEntryService
    {
        Task<DCEntryDto> GetDailyConsolidated();
    }
}
