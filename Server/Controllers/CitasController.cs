using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using citas.Server.Data;
using citas.Shared.Model;

namespace citas.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly ClinicaContexto _context;

        public CitasController(ClinicaContexto context)
        {
            _context = context;
        }

        // GET: api/Citas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appoitment>>> GetAppoitments()
        {
          if (_context.Appoitments == null)
          {
              return NotFound();
          }
            return await _context.Appoitments.ToListAsync();
        }

        // GET: api/Citas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appoitment>> GetAppoitment(int id)
        {
          if (_context.Appoitments == null)
          {
              return NotFound();
          }
            var appoitment = await _context.Appoitments.FindAsync(id);

            if (appoitment == null)
            {
                return NotFound();
            }

            return appoitment;
        }

        // PUT: api/Citas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppoitment(int id, Appoitment appoitment)
        {
            if (id != appoitment.Id)
            {
                return BadRequest();
            }

            _context.Entry(appoitment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppoitmentExists(id))
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

        // POST: api/Citas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appoitment>> PostAppoitment(Appoitment appoitment)
        {
          if (_context.Appoitments == null)
          {
              return Problem("Entity set 'ClinicaContexto.Appoitments'  is null.");
          }
            _context.Appoitments.Add(appoitment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppoitment", new { id = appoitment.Id }, appoitment);
        }

        // DELETE: api/Citas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppoitment(int id)
        {
            if (_context.Appoitments == null)
            {
                return NotFound();
            }
            var appoitment = await _context.Appoitments.FindAsync(id);
            if (appoitment == null)
            {
                return NotFound();
            }

            _context.Appoitments.Remove(appoitment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppoitmentExists(int id)
        {
            return (_context.Appoitments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
