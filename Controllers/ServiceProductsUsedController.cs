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
    public class ServiceProductsUsedController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServiceProductsUsedController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ServiceProductsUsed
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceProductsUsed>>> GetAll()
        {
            return await _context.ServiceProductsUsed
                .Include(spu => spu.CarServiceHistory)
                .Include(spu => spu.Product)
                .ToListAsync();
        }

        // GET: api/ServiceProductsUsed/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceProductsUsed>> GetById(int id)
        {
            var item = await _context.ServiceProductsUsed
                .Include(spu => spu.CarServiceHistory)
                .Include(spu => spu.Product)
                .FirstOrDefaultAsync(spu => spu.Id == id);

            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // POST: api/ServiceProductsUsed
        [HttpPost]
        public async Task<ActionResult<ServiceProductsUsed>> Create(ServiceProductsUsed item)
        {
            _context.ServiceProductsUsed.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        // PUT: api/ServiceProductsUsed/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ServiceProductsUsed item)
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
                if (!_context.ServiceProductsUsed.Any(e => e.Id == id))
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

        // DELETE: api/ServiceProductsUsed/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.ServiceProductsUsed.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.ServiceProductsUsed.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
