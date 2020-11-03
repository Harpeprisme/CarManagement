using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarManagement.Models;

namespace CarManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculeTypeController : ControllerBase
    {
        private readonly CarManagementContext _context;

        public VehiculeTypeController(CarManagementContext context)
        {
            _context = context;
        }

        // GET: api/VehiculeType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehiculeType>>> GetVehiculeTypes()
        {
            return await _context.VehiculeTypes.ToListAsync();
        }

        // GET: api/VehiculeType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehiculeType>> GetVehiculeType(int id)
        {
            var vehiculeType = await _context.VehiculeTypes.FindAsync(id);

            if (vehiculeType == null)
            {
                return NotFound();
            }

            return vehiculeType;
        }

        // PUT: api/VehiculeType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehiculeType(int id, VehiculeType vehiculeType)
        {
            if (id != vehiculeType.Id)
            {
                return BadRequest();
            }

            _context.Entry(vehiculeType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculeTypeExists(id))
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

        // POST: api/VehiculeType
        [HttpPost]
        public async Task<ActionResult<VehiculeType>> PostVehiculeType(VehiculeType vehiculeType)
        {
            _context.VehiculeTypes.Add(vehiculeType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehiculeType", new { id = vehiculeType.Id }, vehiculeType);
        }

        // DELETE: api/VehiculeType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VehiculeType>> DeleteVehiculeType(int id)
        {
            var vehiculeType = await _context.VehiculeTypes.FindAsync(id);
            if (vehiculeType == null)
            {
                return NotFound();
            }

            _context.VehiculeTypes.Remove(vehiculeType);
            await _context.SaveChangesAsync();

            return vehiculeType;
        }

        private bool VehiculeTypeExists(int id)
        {
            return _context.VehiculeTypes.Any(e => e.Id == id);
        }
    }
}
