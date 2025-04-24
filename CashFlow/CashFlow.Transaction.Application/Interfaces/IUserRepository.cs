using CashFlow.Transaction.Domain.Entities;

namespace CashFlow.Transaction.Application.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task<User> GetUserByUsername(string username);
    }
}
