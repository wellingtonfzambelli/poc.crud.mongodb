using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace poc.crud.mongodb.Entities;

public sealed class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("age")]
    public int Age { get; set; }

    [BsonElement("email")]
    public string Email { get; set; }

    [BsonElement("location")]
    public string Location { get; set; }

    //[BsonIgnoreIfNull]
    //public List<Order> Orders { get; set; }
}