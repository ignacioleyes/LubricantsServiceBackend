using LubricantsServiceBackend.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LubricantsServiceBackend.Controllers
{
    /// <summary>
    /// Controller for managing Brand entities.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BrandController"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public BrandController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all Brand entities.
        /// </summary>
        /// <returns>A list of Brand entities.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetAll()
        {
            return await _context.Brand.ToListAsync();
        }

        /// <summary>
        /// Retrieves a Brand entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the Brand entity.</param>
        /// <returns>The Brand entity if found; otherwise, NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetById(int id)
        {
            var item = await _context.Brand.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        /// <summary>
        /// Creates a new Brand entity.
        /// </summary>
        /// <param name="item">The Brand entity to create.</param>
        /// <returns>The created Brand entity.</returns>
        [HttpPost]
        public async Task<ActionResult<Brand>> Create(Brand item)
        {
            _context.Brand.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        /// <summary>
        /// Updates an existing Brand entity.
        /// </summary>
        /// <param name="id">The ID of the Brand entity to update.</param>
        /// <param name="item">The updated Brand entity.</param>
        /// <returns>NoContent if successful; otherwise, BadRequest or NotFound.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Brand item)
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
                if (!_context.Brand.Any(e => e.Id == id))
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

        /// <summary>
        /// Deletes a Brand entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the Brand entity to delete.</param>
        /// <returns>NoContent if successful; otherwise, NotFound.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Brand.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Brand.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
