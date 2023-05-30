using citas.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace citas.Server.Data
{
    public class ClinicaContexto : DbContext
    {
        public ClinicaContexto(DbContextOptions<ClinicaContexto> options) : base(options)
        {
        }

        public DbSet<Appoitment> Appoitments { get; set; }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Pacient> Pacients { get; set; }

    }
}
