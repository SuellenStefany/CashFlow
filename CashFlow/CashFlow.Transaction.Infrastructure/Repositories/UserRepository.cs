using CashFlow.Transaction.Application.Interfaces;
using CashFlow.Transaction.Domain.Entities;
using CashFlow.Transaction.Infrastructure.Data;
using MongoDB.Driver;

namespace CashFlow.Transaction.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DCEntryContext _DCEntryContext;
        public UserRepository(DCEntryContext dcEntryContext)
        {
            _DCEntryContext = dcEntryContext;
        }
        public async Task CreateUser(User user)
        {
            await _DCEntryContext.User.InsertOneAsync(user);
        }
        public async Task<User> GetUserByUsername(string username)
        {
            var resultUser = Builders<User>.Filter;
            var filter = resultUser.Eq(user => user.Username , username);

            return await _DCEntryContext.User.Find(filter).FirstOrDefaultAsync();
        }
    }
}
