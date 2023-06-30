using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Healthcare.Models;
using Healthcare.Repository.FeedbackRepo;

namespace Healthcare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackService _context;

        public FeedbacksController(IFeedbackService context)
        {
            _context = context;
        }

    [HttpGet]
    public async Task<ActionResult<List<Feedback>>> GetFeedbacks()
    {
      try
      {
        return await _context.GetFeedbacks();

      }
      catch (Exception ex)
      {
        return new BadRequestObjectResult(ex);
      }
    }

    [HttpPost]
    public async Task<ActionResult<List<Feedback>>> PostFeedbacks(Feedback feedback)
    {
      try
      {
        return await _context.PostFeedbacks(feedback);

      }
      catch (Exception ex)
      {
        return new BadRequestObjectResult(ex);
      }
    }
    /*
            // GET: api/Feedbacks
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedbacks()
            {
              if (_context.Feedbacks == null)
              {
                  return NotFound();
              }
                return await _context.Feedbacks.ToListAsync();
            }

            // GET: api/Feedbacks/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Feedback>> GetFeedback(int id)
            {
              if (_context.Feedbacks == null)
              {
                  return NotFound();
              }
                var feedback = await _context.Feedbacks.FindAsync(id);

                if (feedback == null)
                {
                    return NotFound();
                }

                return feedback;
            }

            // PUT: api/Feedbacks/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPut("{id}")]
            public async Task<IActionResult> PutFeedback(int id, Feedback feedback)
            {
                if (id != feedback.FeedbackId)
                {
                    return BadRequest();
                }

                _context.Entry(feedback).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbackExists(id))
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

            // POST: api/Feedbacks
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
            public async Task<ActionResult<Feedback>> PostFeedback(Feedback feedback)
            {
              if (_context.Feedbacks == null)
              {
                  return Problem("Entity set 'HealthCareContext.Feedbacks'  is null.");
              }
                _context.Feedbacks.Add(feedback);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetFeedback", new { id = feedback.FeedbackId }, feedback);
            }

            // DELETE: api/Feedbacks/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteFeedback(int id)
            {
                if (_context.Feedbacks == null)
                {
                    return NotFound();
                }
                var feedback = await _context.Feedbacks.FindAsync(id);
                if (feedback == null)
                {
                    return NotFound();
                }

                _context.Feedbacks.Remove(feedback);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool FeedbackExists(int id)
            {
                return (_context.Feedbacks?.Any(e => e.FeedbackId == id)).GetValueOrDefault();
            }*/
  }
}