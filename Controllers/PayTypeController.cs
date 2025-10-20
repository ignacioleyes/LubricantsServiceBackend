using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LubricantsServiceBackend.Controllers
{
    /// <summary>
    /// Controller for managing PayType entities.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PayTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PayTypeController"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public PayTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all PayType entities.
        /// </summary>
        /// <returns>A list of PayType entities.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PayType>>> GetAll()
        {
            return await _context.PayType.ToListAsync();
        }

        /// <summary>
        /// Retrieves a PayType entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the PayType entity.</param>
        /// <returns>The PayType entity if found; otherwise, NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PayType>> GetById(int id)
        {
            var item = await _context.PayType.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        /// <summary>
        /// Creates a new PayType entity.
        /// </summary>
        /// <param name="item">The PayType entity to create.</param>
        /// <returns>The created PayType entity.</returns>
        [HttpPost]
        public async Task<ActionResult<PayType>> Create(PayType item)
        {
            _context.PayType.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        /// <summary>
        /// Updates an existing PayType entity.
        /// </summary>
        /// <param name="id">The ID of the PayType entity to update.</param>
        /// <param name="item">The updated PayType entity.</param>
        /// <returns>NoContent if successful; otherwise, BadRequest or NotFound.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PayType item)
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
                if (!_context.PayType.Any(e => e.Id == id))
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
        /// Deletes a PayType entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the PayType entity to delete.</param>
        /// <returns>NoContent if successful; otherwise, NotFound.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.PayType.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.PayType.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}