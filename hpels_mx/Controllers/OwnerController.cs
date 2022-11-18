using hpels_mx.Data;
using hpels_mx.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hpels_mx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public OwnerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Owners>> Get()
        {
            return await _context.Owners.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Object> Get(int id)
        {
            var owner = await _context.Owners.FirstOrDefaultAsync(m => m.Id == id);
            if (owner == null)
                return NotFound();
            return Ok(owner);

        }

        [HttpPost]
        public async Task<Object> Post(Owners owners)
        {
            _context.Add(owners);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
