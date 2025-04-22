using System.ComponentModel.DataAnnotations;
using CashFlow.Transaction.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CashFlow.Transaction.Domain.Entities
{
    public class DCEntry
    {
        [Key]
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public TransactionType Type { get;  set; }

        public DCEntry(decimal value, TransactionType type)
        {
            Id = Guid.NewGuid();
            Value = value;
            Date = DateTime.UtcNow;
            Type = type;
        }
    }
}

