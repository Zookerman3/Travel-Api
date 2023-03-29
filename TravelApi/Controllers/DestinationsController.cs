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
        public async Task<ActionResult<IEnumerable<Destination>>> Get()
        {
            return await _db.Destinations.ToListAsync();
        }
    }
}