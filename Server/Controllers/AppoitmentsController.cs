using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using citas.Server.Data;
using citas.Shared.Model;
using System.Numerics;

namespace citas.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppoitmentsController : ControllerBase
    {
        private readonly AppointmentContext _context;

        public AppoitmentsController(AppointmentContext context)
        {
            _context = context;
        }

        // GET: api/Appoitments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appoitment>>> GetAppointments()
        {
          if (_context.Appointments == null)
          {
              return NotFound();
          }
            return await _context.Appointments.Include(a => a.Pacients)
                .Include(a => a.Doctors).ToListAsync();
        }

        // GET: api/Appoitments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appoitment>> GetAppoitment(int id)
        {
          if (_context.Appointments == null)
          {
              return NotFound();
          }
            var appoitment = await _context.Appointments
                .Include(a => a.Pacients)
                .Include(a => a.Doctors)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (appoitment == null)
            {
                return NotFound();
            }

            return appoitment;
        }

        // PUT: api/Appoitments/5
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

        // POST: api/Appoitments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appoitment>> PostAppoitment(Appoitment appoitment)
        {
            // Validar si el paciente existe en la base de datos
            var patient = await _context.Pacients.FindAsync(appoitment.PacientId);
            if (patient == null)
            {
                return BadRequest("Invalid patient ID.");
            }

            // Validar si el doctor existe en la base de datos
            var doctor = await _context.Doctors.FindAsync(appoitment.DoctorId);
            if (doctor == null)
            {
                return BadRequest("Invalid doctor ID.");
            }

            // Resto del código para crear la cita...

            // Asignar los detalles recuperados al objeto de cita
            appoitment.Pacients = new List<Pacient> { patient };
            appoitment.Doctors = new List<Doctors> { doctor };

            // Resto del código para guardar la cita en la base de datos...

            return CreatedAtAction("GetAppoitment", new { id = appoitment.Id }, appoitment);
        }




        // DELETE: api/Appoitments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppoitment(int id)
        {
            if (_context.Appointments == null)
            {
                return NotFound();
            }
            var appoitment = await _context.Appointments.FindAsync(id);
            if (appoitment == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appoitment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppoitmentExists(int id)
        {
            return (_context.Appointments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
