using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace poc.crud.mongodb.Entities;

public sealed class Order
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("userId")]
    [BsonRepresentation(BsonType.Int32)]
    public int UserId { get; set; }

    [BsonElement("total")]
    [BsonRepresentation(BsonType.Double)]
    public double Total { get; set; }

    [BsonElement("items")]
    public List<string> Items { get; set; }

    [BsonElement("date")]
    [BsonDateTimeOptions(DateOnly = true)]
    public string Date { get; set; }
}