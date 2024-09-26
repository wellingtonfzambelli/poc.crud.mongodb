namespace poc.crud.mongodb.Config;

public sealed class MongoConfig
{
    public string ConnectionString { get; set; } = null;
    public string Database { get; set; } = null;

    public string UsersCollection { get; set; } = "users";
    public string OrdersCollection { get; set; } = "orders";
}