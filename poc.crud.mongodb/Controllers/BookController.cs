using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using poc.crud.mongodb.Arguments.Book;
using poc.crud.mongodb.Entities;
using poc.crud.mongodb.Services;

namespace poc.crud.mongodb.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class BookController : ControllerBase
{
    private readonly BookService _bookService;

    public BookController(BookService bookService) =>
        _bookService = bookService;

    [HttpGet]
    public async Task<IList<Book>> GetAsync(CancellationToken ct) =>
        await _bookService.GetAsync(ct);

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Book>> GetByIdAsync(string id, CancellationToken ct)
    {
        var book = await _bookService.GetAsync(ObjectId.Parse(id), ct);

        if (book is null)
            return NotFound();

        return book;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(Book newBook, CancellationToken ct)
    {
        await _bookService.CreateAsync(newBook, ct);

        return Created();
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> UpdateAsync(string id, UpdateBookRequestDto updatedBook, CancellationToken ct)
    {
        var book = await _bookService.GetAsync(ObjectId.Parse(id), ct);

        if (book is null)
            return NotFound();

        await _bookService.UpdateBookAsync(book.Id, updatedBook, ct);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(ObjectId id, CancellationToken ct)
    {
        var book = await _bookService.GetAsync(id, ct);

        if (book is null)
        {
            return NotFound();
        }

        await _bookService.RemoveAsync(id, ct);

        return NoContent();
    }
}