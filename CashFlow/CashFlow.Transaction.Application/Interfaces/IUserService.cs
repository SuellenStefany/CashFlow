using CashFlow.Transaction.Application.DTOs;
using CashFlow.Transaction.Domain.Entities;

namespace CashFlow.Transaction.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUser(CreateUserDto createUser);
        Task<TokenUserDto>? LoginUser(LoginUserDto loginUser);
        Task<User> GetUserByUsername(string username);
    }
}
