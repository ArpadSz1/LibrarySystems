using LibrarySystem.App.Data;
using LibrarySystem.App.Models;
using LibrarySystem.App.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return new NotFoundResult();
            }
            return book;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(BookCreateDto dto)
        {
            var book = new Book
            {
                InventoryNumber = dto.InventoryNumber,
                Title = dto.Title,
                Author = dto.Author,
                Publisher = dto.Publisher,
                YearPublished = dto.YearPublished
            };

            _context.Books.Add(book);

            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBook), new { id = book.InventoryNumber }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BookUpdate dto)
        {
            {
                if (id != dto.InventoryNumber)
                    return BadRequest("InventoryNumber cannot be changed.");

                var existingBook = await _context.Books.FindAsync(id);

                if (existingBook == null)
                    return NotFound();

                existingBook.Title = dto.Title;
                existingBook.Author = dto.Author;
                existingBook.Publisher = dto.Publisher;
                existingBook.YearPublished = dto.YearPublished;

                await _context.SaveChangesAsync();

                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
                return NotFound();

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
