using BackOffice.Domain.Entities;
using BackOffice.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;

    public BooksController(UnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<List<Book>> GetAll() =>
        await _unitOfWork.Books.GetAllAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Book>> Get(string id)
    {
        var book = await _unitOfWork.Books.GetByIdAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Book newBook)
    {
        await _unitOfWork.Books.CreateAsync(newBook);

        return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Book updatedBook)
    {
        var book = await _unitOfWork.Books.GetByIdAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        updatedBook.Id = book.Id;

        await _unitOfWork.Books.UpdateAsync(id, updatedBook);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _unitOfWork.Books.GetByIdAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _unitOfWork.Books.RemoveAsync(id);

        return NoContent();
    }
}