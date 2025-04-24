namespace CashFlow.Transaction.Application.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(Guid id);
    }
}
