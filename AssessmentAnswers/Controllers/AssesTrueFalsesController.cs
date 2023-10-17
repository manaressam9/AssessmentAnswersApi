using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AssessmentAnswers.Models;

namespace AssessmentAnswers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssesTrueFalsesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AssesTrueFalsesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AssesTrueFalses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssesTrueFalse>>> GetAssesTrueFalses()
        {
          if (_context.AssesTrueFalses == null)
          {
              return NotFound();
          }
            return await _context.AssesTrueFalses.ToListAsync();
        }

        // GET: api/AssesTrueFalses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssesTrueFalse>> GetAssesTrueFalse(int id)
        {
          if (_context.AssesTrueFalses == null)
          {
              return NotFound();
          }
            var assesTrueFalse = await _context.AssesTrueFalses.FindAsync(id);

            if (assesTrueFalse == null)
            {
                return NotFound();
            }

            return assesTrueFalse;
        }

        // PUT: api/AssesTrueFalses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssesTrueFalse(int id, AssesTrueFalse assesTrueFalse)
        {
            if (id != assesTrueFalse.Id)
            {
                return BadRequest();
            }

            _context.Entry(assesTrueFalse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssesTrueFalseExists(id))
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

        // POST: api/AssesTrueFalses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AssesTrueFalse>> PostAssesTrueFalse(AssesTrueFalse assesTrueFalse)
        {
          if (_context.AssesTrueFalses == null)
          {
              return Problem("Entity set 'AppDbContext.AssesTrueFalses'  is null.");
          }
            _context.AssesTrueFalses.Add(assesTrueFalse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssesTrueFalse", new { id = assesTrueFalse.Id }, assesTrueFalse);
        }

        // DELETE: api/AssesTrueFalses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssesTrueFalse(int id)
        {
            if (_context.AssesTrueFalses == null)
            {
                return NotFound();
            }
            var assesTrueFalse = await _context.AssesTrueFalses.FindAsync(id);
            if (assesTrueFalse == null)
            {
                return NotFound();
            }

            _context.AssesTrueFalses.Remove(assesTrueFalse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssesTrueFalseExists(int id)
        {
            return (_context.AssesTrueFalses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
