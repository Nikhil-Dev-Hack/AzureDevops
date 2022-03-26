using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _booksService;
        public BooksController(BooksService booksService) =>
            _booksService = booksService;
        [HttpGet]
        public async Task<List<Book>> Get() =>
            await _booksService.GetAsync();
        [HttpGet("{id:maxlength(24)}")]
        public async Task<ActionResult<Book>> Get(string id)
        {
            var book = await _booksService.GetAsync(id);
            if (book is null)
                return NotFound();
            return book;
        }
        [HttpPost]
        public async Task<ActionResult> Post(Book newBook)
        {
            await _booksService.CreateAsync(newBook);
            return CreatedAtAction(nameof(Get), new
            {
                id = newBook.Id
            }, newBook);
        }
        [HttpPut("{id:maxlength(24)}")]
        public async Task<ActionResult> Update(string id, Book updatedBook)
        {
            var book = await _booksService.GetAsync(id);
            if (book is null)
            {
                return NotFound();
            }
            updatedBook.Id = book.Id;
            await _booksService.UpdateAsync(id, updatedBook);
            return NoContent();
        }
        [HttpDelete("{id:maxlength(24)}")]
        public async Task<ActionResult> Delete (string id)
        {
            var book = await _booksService.GetAsync(id);
            if (book is null)
            {
                NotFound();
            }
            await _booksService.RemoveAsync(id);
            return NoContent();
        }
    }
}
