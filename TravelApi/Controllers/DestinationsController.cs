using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelApi.Models;

namespace TravelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private readonly TravelApiContext _db;

        public DestinationsController(TravelApiContext db)
        {
            _db = db;
        }

        // GET api/destinations
        [HttpGet]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Destination>>> Get(string country, string city)
        {
            IQueryable<Destination> query = _db.Destinations.AsQueryable();

            if (country != null)
            {
                query = query.Where(entry => entry.Country == country);
            }

            if (city != null)
            {
                query = query.Where(entry => entry.City == city);
            }

            return await query.ToListAsync();
        }

        // GET: api/Animals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Destination>> GetDestination(int id)
        {
            Destination destination = await _db.Destinations.FindAsync(id);

            if (destination == null)
            {
                return NotFound();
            }
            return destination;
        }
        // POST api/animals
        [HttpPost]
        public async Task<ActionResult<Destination>> Post(Destination destination)
        {
            _db.Destinations.Add(destination);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDestination), new { id = destination.DestinationId }, destination);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Destination destination)
        {
            if (id != destination.DestinationId)
            {
                return BadRequest();
            }

            _db.Destinations.Update(destination);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DestinationExists(id))
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

        private bool DestinationExists(int id)
        {
            return _db.Destinations.Any(e => e.DestinationId == id);
        }

        // DELETE: api/Animals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestination(int id)
        {
            Destination destination = await _db.Destinations.FindAsync(id);
            if (destination == null)
            {
                return NotFound();
            }

            _db.Destinations.Remove(destination);
            await _db.SaveChangesAsync();

            return NoContent();
        }

    }
}