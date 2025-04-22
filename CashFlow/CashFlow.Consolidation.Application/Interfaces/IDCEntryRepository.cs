using CashFlow.Consolidation.Domain.Entities;

namespace CashFlow.Consolidation.Application.Interfaces
{
    public interface IDCEntryRepository
    {
        Task<IEnumerable<DCEntry>> GetDailyConsolidated(DateTime date);
    }
}
