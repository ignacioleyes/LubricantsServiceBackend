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
    public class ProductTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductType>>> GetAll()
        {
            return await _context.ProductType.ToListAsync();
        }

        // GET: api/ProductType/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductType>> GetById(int id)
        {
            var item = await _context.ProductType.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // POST: api/ProductType
        [HttpPost]
        public async Task<ActionResult<ProductType>> Create(ProductType item)
        {
            _context.ProductType.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        // PUT: api/ProductType/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductType item)
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
                if (!_context.ProductType.Any(e => e.Id == id))
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

        // DELETE: api/ProductType/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.ProductType.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.ProductType.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
