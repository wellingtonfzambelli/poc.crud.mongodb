using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace poc.crud.mongodb.Entities;

public sealed class Order
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("userId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string UserId { get; set; }

    [BsonElement("total")]
    [BsonRepresentation(BsonType.Double)]
    public double Total { get; set; }

    [BsonElement("items")]
    public List<string> Items { get; set; }

    [BsonElement("date")]
    [BsonDateTimeOptions(DateOnly = true)]
    public DateTime Date { get; set; }
}