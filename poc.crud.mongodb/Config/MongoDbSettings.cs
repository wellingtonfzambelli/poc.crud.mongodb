namespace poc.crud.mongodb.Config;

public sealed class MongoDbSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;

    public string BooksCollectionName { get; set; } = null;
    public string UsersCollectionName { get; set; } = null;
    public string OrdersCollectionName { get; set; } = null;
}