using CashFlow.Consolidation.Domain.Entities;
using CashFlow.Consolidation.Infrastructure.Config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CashFlow.Consolidation.Infrastructure.Data
{
    public class DCEntryContext 
    {
        private readonly IMongoDatabase _database;

        public DCEntryContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }
        public IMongoCollection<DCEntry> DCEntry
            => _database.GetCollection<DCEntry>("DCEntry");
    }
}
