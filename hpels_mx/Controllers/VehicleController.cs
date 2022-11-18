using hpels_mx.Data;
using hpels_mx.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hpels_mx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public VehicleController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Vehicles>> Get()
        {
            return await _context.Vehicles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Object> Get(int id)
        {
            var vehicle = await _context.Vehicles.FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
                return NotFound();
            vehicle.Owner = _context.Owners.FirstOrDefault(t => t.Id == vehicle.OwnerId);
            return Ok(vehicle);
        }

        [HttpPost]
        public async Task<Object> Post(Vehicles vehicle)
        {
            _context.Add(vehicle);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<Object> Put(Vehicles vehicleData)
        {
            if (vehicleData == null || vehicleData.Id == 0)
                return BadRequest();

            var vehicle = await _context.Vehicles.FindAsync(vehicleData.Id);
            if (vehicle == null)
                return NotFound();
            vehicle.Brand = vehicleData.Brand;
            vehicle.Vin = vehicleData.Vin;
            vehicle.Color = vehicleData.Color;
            vehicle.Year = vehicleData.Year;
            vehicle.Owner = vehicleData.Owner;
            vehicle.OwnerId = vehicleData.OwnerId;
            vehicle.Claims = vehicleData.Claims;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<Object> Delete(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null) return NotFound();
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
