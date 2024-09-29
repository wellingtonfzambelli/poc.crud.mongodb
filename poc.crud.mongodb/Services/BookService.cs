using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using poc.crud.mongodb.Arguments.Book;
using poc.crud.mongodb.Config;
using poc.crud.mongodb.Entities;

namespace poc.crud.mongodb.Services;

public sealed class BookService
{
    private readonly IMongoCollection<Book> _booksCollection;

    public BookService(IConfiguration configuration,
        IOptions<MongoDbSettings> bookStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            bookStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bookStoreDatabaseSettings.Value.DatabaseName);

        _booksCollection = mongoDatabase.GetCollection<Book>(
            bookStoreDatabaseSettings.Value.BooksCollectionName);
    }

    public async Task<List<Book>> GetAsync(CancellationToken ct) =>
        await _booksCollection.Find(_ => true).ToListAsync(ct);

    public async Task<Book?> GetAsync(ObjectId id, CancellationToken ct) =>
        await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync(ct);

    public async Task CreateAsync(Book newBook, CancellationToken ct) =>
        await _booksCollection.InsertOneAsync(newBook, new InsertOneOptions { }, ct);

    public async Task UpdateBookAsync
    (
        ObjectId bookId,
        UpdateBookRequestDto updatedBook,
        CancellationToken ct
    )
    {
        var filter = Builders<Book>.Filter.Eq(b => b.Id, bookId);

        var update = Builders<Book>.Update
                        .Set(b => b.Price, updatedBook.Price)
                        .Set(b => b.BookName, updatedBook.BookName)
                        .Set(b => b.Category, updatedBook.Category)
                        .Set(b => b.Author, updatedBook.Author);

        var result = await _booksCollection.UpdateOneAsync(filter, update, cancellationToken: ct);

        Console.WriteLine($"{result.ModifiedCount} document(s) updated.");
    }

    public async Task RemoveAsync(ObjectId id, CancellationToken ct) =>
        await _booksCollection.DeleteOneAsync(x => x.Id == id, cancellationToken: ct);
}