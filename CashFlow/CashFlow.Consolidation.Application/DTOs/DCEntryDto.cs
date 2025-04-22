using CashFlow.Consolidation.Domain.Enums;

namespace CashFlow.Consolidation.Application.DTOs
{
    public class DCEntryDto
    {
        public decimal TotalValue { get; set; }
        public decimal CreditValue { get; set; }
        public decimal DebitValue { get; set; }
    }
}
