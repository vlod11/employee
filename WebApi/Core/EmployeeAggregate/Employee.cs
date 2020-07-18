using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.EmployeeAggregate
{
    public class Employee: IDocumentEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTimeOffset CreatedAtUtc { get; set; }
        public DateTimeOffset ModifiedAtUtc { get; set; }
        public DateTimeOffset DeletedAtUtc { get; set; }
        public ICollection<EmployeePosition> Positions { get; set; }
    }
}