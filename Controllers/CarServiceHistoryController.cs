using LubricantsServiceBackend.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LubricantsServiceBackend.Controllers
{
    /// <summary>
    /// Controller for managing car service history records.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CarServiceHistoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CarServiceHistoryController"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CarServiceHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all car service history records.
        /// </summary>
        /// <returns>A list of car service history records.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarServiceHistory>>> GetAll()
        {
            return await _context.CarServiceHistory
                .Include(csh => csh.CarInformation)
                .Include(csh => csh.Employee)
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves a specific car service history record by ID.
        /// </summary>
        /// <param name="id">The ID of the car service history record.</param>
        /// <returns>The car service history record, if found.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CarServiceHistory>> GetById(int id)
        {
            var item = await _context.CarServiceHistory
                .Include(csh => csh.CarInformation)
                .Include(csh => csh.Employee)
                .FirstOrDefaultAsync(csh => csh.ServiceId == id);

            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        /// <summary>
        /// Creates a new car service history record.
        /// </summary>
        /// <param name="item">The car service history record to create.</param>
        /// <returns>The created car service history record.</returns>
        [HttpPost]
        public async Task<ActionResult<CarServiceHistory>> Create(CarServiceHistory item)
        {
            _context.CarServiceHistory.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.ServiceId }, item);
        }

        /// <summary>
        /// Updates an existing car service history record.
        /// </summary>
        /// <param name="id">The ID of the car service history record to update.</param>
        /// <param name="item">The updated car service history record.</param>
        /// <returns>No content if the update is successful.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CarServiceHistory item)
        {
            if (id != item.ServiceId)
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
                if (!_context.CarServiceHistory.Any(e => e.ServiceId == id))
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
        /// Deletes a specific car service history record by ID.
        /// </summary>
        /// <param name="id">The ID of the car service history record to delete.</param>
        /// <returns>No content if the deletion is successful.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.CarServiceHistory.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.CarServiceHistory.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
