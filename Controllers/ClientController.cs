using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LubricantsServiceBackend.Controllers
{
    /// <summary>
    /// Controller for managing client-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientController"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all clients.
        /// </summary>
        /// <returns>A list of clients.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetAll()
        {
            return await _context.Client
                .Include(c => c.State)
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves a client by their ID.
        /// </summary>
        /// <param name="id">The ID of the client.</param>
        /// <returns>The client with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetById(int id)
        {
            var item = await _context.Client
                .Include(c => c.State)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        /// <summary>
        /// Creates a new client.
        /// </summary>
        /// <param name="item">The client to create.</param>
        /// <returns>The created client.</returns>
        [HttpPost]
        public async Task<ActionResult<Client>> Create(Client item)
        {
            _context.Client.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        /// <summary>
        /// Updates an existing client.
        /// </summary>
        /// <param name="id">The ID of the client to update.</param>
        /// <param name="item">The updated client data.</param>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Client item)
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
                if (!_context.Client.Any(e => e.Id == id))
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
        /// Deletes a client by their ID.
        /// </summary>
        /// <param name="id">The ID of the client to delete.</param>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Client.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Client.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
