using System.ComponentModel.DataAnnotations;
using CashFlow.Consolidation.Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CashFlow.Consolidation.Domain.Entities
{
    public class DCEntry
    {
        [Key]
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public TransactionType Type { get;  set; }
    }
}

