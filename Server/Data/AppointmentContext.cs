using citas.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace citas.Server.Data
{
    public class AppointmentContext : DbContext
    {
        public AppointmentContext(DbContextOptions
            <AppointmentContext> options) : base(options)
        {

        }

        public DbSet<Appoitment>? Appointments { get; set; }
        public DbSet<Doctors>? Doctors { get; set; }
        public DbSet<Pacient>? Pacients { get; set; }
    }

}

