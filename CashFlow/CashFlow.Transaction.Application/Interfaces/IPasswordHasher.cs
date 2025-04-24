namespace CashFlow.Transaction.Application.Interfaces
{
    public interface IPasswordHasher
    {
        string HashPassword(string password, byte[] salt);
    }
}
