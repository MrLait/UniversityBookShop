using BackOffice.Application.Common.Interfaces;
using BackOffice.Domain.Entities;
using BackOffice.Domain.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BackOffice.Application.Repository;

public class BookRepository : IBookRepository
{
    private readonly IMongoCollection<Book> _booksCollection;
    public BookRepository(
        IOptions<MongoDbSettings> mongoDbSettings)
    {
        var mongoClient = new MongoClient(
            mongoDbSettings.Value.ConnectionURI);

        var mongoDatabase = mongoClient.GetDatabase(
            mongoDbSettings.Value.DatabaseName);

        _booksCollection = mongoDatabase.GetCollection<Book>(
            mongoDbSettings.Value.CollectionName);
    }

    public async Task<List<Book>> GetAllAsync() =>
        await _booksCollection.Find(_ => true).ToListAsync();
    public async Task<Book?> GetByIdAsync(string id) =>
        await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    public async Task CreateAsync(Book entity) =>
        await _booksCollection.InsertOneAsync(entity);
    public async Task UpdateAsync(string id, Book entity) =>
        await _booksCollection.ReplaceOneAsync(x => x.Id == id, entity);
    public async Task RemoveAsync(string id) =>
        await _booksCollection.DeleteOneAsync(x => x.Id == id);
}
