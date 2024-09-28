using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using poc.crud.mongodb.Config;
using poc.crud.mongodb.Entities;

namespace poc.crud.mongodb.Services;

public sealed class UserServices
{
    private readonly IMongoCollection<User> _usersCollection;
    private readonly IMongoCollection<Order> _ordersCollection;

    public UserServices(IOptions<MongoDbSettings> mongoConfig)
    {
        var mongoClient = new MongoClient(mongoConfig.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(mongoConfig.Value.DatabaseName);

        _usersCollection = mongoDatabase.GetCollection<User>(mongoConfig.Value.UsersCollectionName);
        _ordersCollection = mongoDatabase.GetCollection<Order>(mongoConfig.Value.OrdersCollectionName);
    }

    public async Task<List<User>> GetAsync(CancellationToken ct)
    {
        var pipeline = new List<BsonDocument>
        {
            new BsonDocument("$lookup", new BsonDocument
            {
                { "from", "orders" },
                { "localField", "_id" },
                { "foreignField", "userId" },
                { "as", "Orders" }
            }),
            new BsonDocument("$sort", new BsonDocument("name", 1))
        };

        return await _usersCollection.Aggregate<User>(pipeline).ToListAsync(ct);
    }

    public async Task<List<User>> GetUserByIdAsync(string userId, CancellationToken ct)
    {
        var pipeline = new List<BsonDocument>
        {
            new BsonDocument("$match", new BsonDocument("_id", ObjectId.Parse(userId))),
            new BsonDocument("$lookup", new BsonDocument
            {
                { "from", "orders" },
                { "localField", "_id" },
                { "foreignField", "userId" },
                { "as", "Orders" }
            })
        };

        return await _usersCollection.Aggregate<User>(pipeline).ToListAsync(ct);
    }


    public async Task CreateAsync(User user, CancellationToken ct) =>
        await _usersCollection.InsertOneAsync(user, new InsertOneOptions { }, ct);

    public async Task UpdateAsync(int id, User user, CancellationToken ct) =>
        await _usersCollection.ReplaceOneAsync(
            x => x.Id == user.Id, user, new ReplaceOptions { IsUpsert = false }, ct);

    public async Task RemoveAsync(string id, CancellationToken ct) =>
        await _usersCollection.DeleteOneAsync(x => x.Id == id, ct);
}