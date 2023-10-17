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
    public class AssesAnswersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AssesAnswersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AssesAnswers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssesAnswer>>> GetAssesAnswer()
        {
          if (_context.AssesAnswer == null)
          {
              return NotFound();
          }
            return await _context.AssesAnswer.ToListAsync();
        }

        // GET: api/AssesAnswers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssesAnswer>> GetAssesAnswer(int id)
        {
          if (_context.AssesAnswer == null)
          {
              return NotFound();
          }
            var assesAnswer = await _context.AssesAnswer.FindAsync(id);

            if (assesAnswer == null)
            {
                return NotFound();
            }

            return assesAnswer;
        }

        // PUT: api/AssesAnswers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssesAnswer(int id, AssesAnswer assesAnswer)
        {
            if (id != assesAnswer.Id)
            {
                return BadRequest();
            }

            _context.Entry(assesAnswer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssesAnswerExists(id))
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

        // POST: api/AssesAnswers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AssesAnswer>> PostAssesAnswer(AssesAnswer assesAnswer)
        {
          if (_context.AssesAnswer == null)
          {
              return Problem("Entity set 'AppDbContext.AssesAnswer'  is null.");
          }
            _context.AssesAnswer.Add(assesAnswer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssesAnswer", new { id = assesAnswer.Id }, assesAnswer);
        }

        // DELETE: api/AssesAnswers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssesAnswer(int id)
        {
            if (_context.AssesAnswer == null)
            {
                return NotFound();
            }
            var assesAnswer = await _context.AssesAnswer.FindAsync(id);
            if (assesAnswer == null)
            {
                return NotFound();
            }

            _context.AssesAnswer.Remove(assesAnswer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssesAnswerExists(int id)
        {
            return (_context.AssesAnswer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
