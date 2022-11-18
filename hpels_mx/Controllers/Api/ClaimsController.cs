using hpels_mx.Data;
using hpels_mx.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hpels_mx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ClaimsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Claims>> Get()
        {
            return await _context.Claims.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Object> Get(int id)
        {
            var owner = await _context.Claims.FirstOrDefaultAsync(m => m.Id == id);
            if (owner == null)
                return NotFound();
            return Ok(owner);

        }

        [HttpPost]
        public async Task<Object> Post(Claims claim)
        {
            _context.Add(claim);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<Object> Put(Claims claimData)
        {
            if (claimData == null)
                return BadRequest();

            var claim = await _context.Claims.FindAsync(claimData.Id);
            if (claim == null)
                return NotFound();
            claim.Description = claimData.Description;
            claim.Status = claimData.Status;
            claim.Date = claimData.Date;
            claim.Vehicle = claimData.Vehicle;
            claim.VehicleId = claimData.VehicleId;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<Object> Delete(int id)
        {
            var claim = await _context.Claims.FindAsync(id);
            if (claim == null)
                return NotFound();
            _context.Claims.Remove(claim);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
