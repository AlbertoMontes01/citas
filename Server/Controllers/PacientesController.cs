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
    public class PacientesController : ControllerBase
    {
        private readonly ClinicaContexto _context;

        public PacientesController(ClinicaContexto context)
        {
            _context = context;
        }

        // GET: api/Pacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pacient>>> GetPacients()
        {
          if (_context.Pacients == null)
          {
              return NotFound();
          }
            return await _context.Pacients.ToListAsync();
        }

        // GET: api/Pacientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pacient>> GetPacient(int id)
        {
          if (_context.Pacients == null)
          {
              return NotFound();
          }
            var pacient = await _context.Pacients.FindAsync(id);

            if (pacient == null)
            {
                return NotFound();
            }

            return pacient;
        }

        // PUT: api/Pacientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPacient(int id, Pacient pacient)
        {
            if (id != pacient.Id)
            {
                return BadRequest();
            }

            _context.Entry(pacient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacientExists(id))
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

        // POST: api/Pacientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pacient>> PostPacient(Pacient pacient)
        {
          if (_context.Pacients == null)
          {
              return Problem("Entity set 'ClinicaContexto.Pacients'  is null.");
          }
            _context.Pacients.Add(pacient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPacient", new { id = pacient.Id }, pacient);
        }

        // DELETE: api/Pacientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePacient(int id)
        {
            if (_context.Pacients == null)
            {
                return NotFound();
            }
            var pacient = await _context.Pacients.FindAsync(id);
            if (pacient == null)
            {
                return NotFound();
            }

            _context.Pacients.Remove(pacient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PacientExists(int id)
        {
            return (_context.Pacients?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
