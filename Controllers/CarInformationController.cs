using LubricantsServiceBackend.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LubricantsServiceBackend.Controllers
{
    /// <summary>
    /// Controller for managing car information.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CarInformationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CarInformationController"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CarInformationController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all car information records.
        /// </summary>
        /// <returns>A list of car information records.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarInformation>>> GetAll()
        {
            return await _context.CarInformation
                .Include(ci => ci.Client)
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves a specific car information record by ID.
        /// </summary>
        /// <param name="id">The ID of the car information record.</param>
        /// <returns>The car information record if found; otherwise, NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CarInformation>> GetById(int id)
        {
            var item = await _context.CarInformation
                .Include(ci => ci.Client)
                .FirstOrDefaultAsync(ci => ci.CarId == id);

            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        /// <summary>
        /// Creates a new car information record.
        /// </summary>
        /// <param name="item">The car information record to create.</param>
        /// <returns>The created car information record.</returns>
        [HttpPost]
        public async Task<ActionResult<CarInformation>> Create(CarInformation item)
        {
            _context.CarInformation.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.CarId }, item);
        }

        /// <summary>
        /// Updates an existing car information record.
        /// </summary>
        /// <param name="id">The ID of the car information record to update.</param>
        /// <param name="item">The updated car information record.</param>
        /// <returns>NoContent if successful; otherwise, BadRequest or NotFound.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CarInformation item)
        {
            if (id != item.CarId)
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
                if (!_context.CarInformation.Any(e => e.CarId == id))
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
        /// Deletes a specific car information record by ID.
        /// </summary>
        /// <param name="id">The ID of the car information record to delete.</param>
        /// <returns>NoContent if successful; otherwise, NotFound.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.CarInformation.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.CarInformation.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
