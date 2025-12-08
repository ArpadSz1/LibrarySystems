using LibrarySystem.App.Data;
using LibrarySystem.App.Dtos;
using LibrarySystem.App.Models;
using LibrarySystem.App.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReaderController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReaderController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var readers = await _context.Readers.ToListAsync();
            return Ok(readers);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reader = await _context.Readers.FindAsync(id);
            if (reader == null)
                return NotFound();

            return Ok(reader);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(ReaderCreateDto dto)
        {
            var reader = new Reader
            {
                Name = dto.Name,
                Address = dto.Address,
                BirthYear = dto.BirthYear
            };

            _context.Readers.Add(reader);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = reader.ReaderId }, reader);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ReaderUpdateDto dto)
        {
            var reader = await _context.Readers.FindAsync(id);
            if (reader == null)
                return NotFound();

            reader.Name = dto.Name;
            reader.Address = dto.Address;
            reader.BirthYear = dto.BirthYear;

            await _context.SaveChangesAsync();
            return Ok(reader);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var reader = await _context.Readers.FindAsync(id);
            if (reader == null)
                return NotFound();

            _context.Readers.Remove(reader);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
