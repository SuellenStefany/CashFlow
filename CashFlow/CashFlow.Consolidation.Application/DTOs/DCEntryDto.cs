using System.Diagnostics.CodeAnalysis;

namespace CashFlow.Consolidation.Application.DTOs
{
    [ExcludeFromCodeCoverage]
    public class DCEntryDto
    {
        public decimal TotalValue { get; set; }
        public decimal CreditValue { get; set; }
        public decimal DebitValue { get; set; }
    }
}
