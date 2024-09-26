using Microsoft.Extensions.Options;
using MongoDB.Driver;
using poc.crud.mongodb.Config;
using poc.crud.mongodb.Entities;

namespace poc.crud.mongodb.Services;

public sealed class UserServices
{
    private readonly IMongoCollection<User> _usersCollection;

    public UserServices(IOptions<MongoConfig> mongoConfig)
    {
        var mongoClient = new MongoClient(mongoConfig.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(mongoConfig.Value.Database);

        _usersCollection = mongoDatabase.GetCollection<User>(mongoConfig.Value.UsersCollection);
    }

    public async Task<IList<User>> GetAsync(CancellationToken ct) =>
        await _usersCollection.Find(x => true).ToListAsync(ct);

    public async Task<User> GetByIdAsync(string id, CancellationToken ct) =>
        await _usersCollection.Find(x => x.Id == id).FirstOrDefaultAsync(ct);

    public async Task CreateAsync(User user, CancellationToken ct) =>
        await _usersCollection.InsertOneAsync(user, new InsertOneOptions { }, ct);

    public async Task UpdateAsync(int id, User user, CancellationToken ct) =>
        await _usersCollection.ReplaceOneAsync(
            x => x.Id == user.Id, user, new ReplaceOptions { IsUpsert = false }, ct);

    public async Task RemoveAsync(string id, CancellationToken ct) =>
        await _usersCollection.DeleteOneAsync(x => x.Id == id, ct);
}