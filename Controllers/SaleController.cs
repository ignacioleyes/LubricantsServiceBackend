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
    public class SaleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SaleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Sale
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sale>>> GetAll()
        {
            return await _context.Sale
                .Include(s => s.Product)
                .Include(s => s.Client)
                .Include(s => s.PayType)
                .ToListAsync();
        }

        // GET: api/Sale/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetById(int id)
        {
            var item = await _context.Sale
                .Include(s => s.Product)
                .Include(s => s.Client)
                .Include(s => s.PayType)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // POST: api/Sale
        [HttpPost]
        public async Task<ActionResult<Sale>> Create(Sale item)
        {
            _context.Sale.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        // PUT: api/Sale/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Sale item)
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
                if (!_context.Sale.Any(e => e.Id == id))
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

        // DELETE: api/Sale/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Sale.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Sale.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}