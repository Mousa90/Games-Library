using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GamesLibraryAPI.Models;
using GamesLibraryAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace GamesLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GamesLibraryDbContext _context;
        public GamesController(GamesLibraryDbContext context) => this._context = context;

        [HttpGet]
        public async Task<IEnumerable<Games>> Get()
        => await _context.Games.ToListAsync();

        [HttpGet("Top12")]
        public async Task<IEnumerable<Games>> GetTop12()
        => await _context.Games.Take(12).ToListAsync();

        [HttpGet("id")]
        [ProducesResponseType(typeof(Games), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByID(int id)
        {
            var Games = await _context.Games.FindAsync(id);
            return Games == null ? NotFound() : Ok(Games);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Games Games)
        {
            await _context.Games.AddAsync(Games);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByID), new { id = Games.Id }, Games);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Games Games)
        {
            if (id != Games.Id) return BadRequest();
            _context.Entry(Games).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var GamesToDelete = await _context.Games.FindAsync(id);
            if (GamesToDelete == null) return NotFound();
            _context.Games.Remove(GamesToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
