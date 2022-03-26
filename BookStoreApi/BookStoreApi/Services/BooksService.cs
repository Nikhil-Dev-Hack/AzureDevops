using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.Services
{
    public class BooksService
    {
        private readonly IMongoCollection<Book> _bookCollection;
        public BooksService(IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(bookStoreDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);
            _bookCollection = mongoDatabase.GetCollection<Book>(
                bookStoreDatabaseSettings.Value.CollectionName);
        }
        public async Task<List<Book>> GetAsync() =>
            await _bookCollection.Find(_ => true).ToListAsync();
        public async Task<Book?> GetAsync(string id) =>
        await _bookCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Book newbook) =>
            await _bookCollection.InsertOneAsync(newbook);
        public async Task UpdateAsync(string id, Book updatedBook) =>
            await _bookCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);
        public async Task RemoveAsync(string id) =>
            await _bookCollection.DeleteOneAsync(x => x.Id == id);

    }
}
