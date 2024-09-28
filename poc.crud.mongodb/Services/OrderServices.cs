using Microsoft.Extensions.Options;
using MongoDB.Driver;
using poc.crud.mongodb.Config;
using poc.crud.mongodb.Entities;

namespace poc.crud.mongodb.Services;

public sealed class OrderServices
{
    private readonly IMongoCollection<Order> _orderCollection;

    public OrderServices(IOptions<MongoDbSettings> mongoConfig)
    {
        var mongoClient = new MongoClient(mongoConfig.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(mongoConfig.Value.DatabaseName);

        _orderCollection = mongoDatabase.GetCollection<Order>(mongoConfig.Value.OrdersCollectionName);
    }

    public async Task<IList<Order>> GetAsync(CancellationToken ct) =>
        await _orderCollection.Find(x => true).ToListAsync(ct);

    public async Task<Order> GetByIdAsync(string id, CancellationToken ct) =>
        await _orderCollection.Find(x => x.Id == id).FirstOrDefaultAsync(ct);

    public async Task CreateAsync(Order order, CancellationToken ct) =>
        await _orderCollection.InsertOneAsync(order, new InsertOneOptions { }, ct);

    public async Task UpdateAsync(int id, Order order, CancellationToken ct) =>
        await _orderCollection.ReplaceOneAsync(
            x => x.Id == order.Id, order, new ReplaceOptions { IsUpsert = false }, ct);

    public async Task RemoveAsync(string id, CancellationToken ct) =>
        await _orderCollection.DeleteOneAsync(x => x.Id == id, ct);
}