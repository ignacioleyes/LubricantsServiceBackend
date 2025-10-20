using LubricantsServiceBackend.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LubricantsServiceBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StateController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/State
        [HttpGet]
        public async Task<ActionResult<IEnumerable<State>>> GetAll()
        {
            return await _context.State.ToListAsync();
        }

        // GET: api/State/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<State>> GetById(int id)
        {
            var item = await _context.State.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // POST: api/State
        [HttpPost]
        public async Task<ActionResult<State>> Create(State item)
        {
            _context.State.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        // PUT: api/State/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, State item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.State.Any(e => e.Id == id))
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

        // DELETE: api/State/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.State.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.State.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}