using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.PositionAggregate
{
    public class Position: IDocumentEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string Title { get; set; }
    }
}