using LibrarySystem.App.Data;
using LibrarySystem.App.Dtos;
using LibrarySystem.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoanController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var loans = await _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Reader)
                .ToListAsync();

            return Ok(loans);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var loan = await _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Reader)
                .FirstOrDefaultAsync(l => l.LoanId == id);

            if (loan == null) return NotFound();
            return Ok(loan);
        }


        [HttpPost]
        public async Task<IActionResult> Create(LoanCreateDto dto)
        {
            var reader = await _context.Readers.FindAsync(dto.ReaderId);
            if (reader == null)
                return BadRequest("Reader does not exist.");

            var book = await _context.Books.FindAsync(dto.InventoryNumber);
            if (book == null)
                return BadRequest("Book does not exist.");

            // check if book already loaned
            var existingLoan = await _context.Loans
                .FirstOrDefaultAsync(l => l.InventoryNumber == dto.InventoryNumber);

            if (existingLoan != null)
                return BadRequest("This book is already loaned out.");

            var loan = new Loan
            {
                ReaderId = dto.ReaderId,
                InventoryNumber = dto.InventoryNumber,
                LoanDate = dto.LoanDate,
                ReturnDeadline = dto.ReturnDeadline
            };

            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = loan.LoanId }, loan);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var loan = await _context.Loans.FindAsync(id);
            if (loan == null) return NotFound();

            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPatch("return/{id}")]
        public async Task<IActionResult> ReturnBook(int id)
        {
            var loan = await _context.Loans
                .Include(l => l.Book)
                .FirstOrDefaultAsync(l => l.LoanId == id);

            if (loan == null) return NotFound("A kölcsönzés nem található.");

            loan.Book.Loan = null;

            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();

            return Ok("Könyv visszahozva.");
        }
    }
}