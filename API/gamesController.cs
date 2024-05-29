using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SnakeApplication.Data;
using SnakeApplication.Models;

namespace SnakeApplication.API
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class gamesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public gamesController(ApplicationDbContext context)
        {
            _context = context;
        }
       
    
        // GET: api/games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<games>>> GetGames()
        {
          if (_context.Games == null)
          {
              return NotFound();
          }
            return await _context.Games.ToListAsync();
        }

        // GET: api/games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<games>> Getgames(string id)
        {
          if (_context.Games == null)
          {
              return NotFound();
          }
            var games = await _context.Games.FindAsync(id);

            if (games == null)
            {
                return NotFound();
            }

            return games;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<games>>> GetUpcomingGames()
        {
            var upcomingGames = await _context.Games
                .Where(g => g.StartTime >= DateTime.Now) // Filter upcoming games
                .ToListAsync();
            return upcomingGames;
        }

        // PUT: api/games/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgames(string id, games games)
        {
            if (id != games.Title)
            {
                return BadRequest();
            }

            _context.Entry(games).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gamesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/games
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<games>> Postgames(games games)
        {
          if (_context.Games == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Games'  is null.");
          }
            _context.Games.Add(games);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (gamesExists(games.Title))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getgames", new { id = games.Title }, games);
        }

        // DELETE: api/games/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletegames(string id)
        {
            if (_context.Games == null)
            {
                return NotFound();
            }
            var games = await _context.Games.FindAsync(id);
            if (games == null)
            {
                return NotFound();
            }

            _context.Games.Remove(games);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool gamesExists(string id)
        {
            return (_context.Games?.Any(e => e.Title == id)).GetValueOrDefault();
        }
    }
}
