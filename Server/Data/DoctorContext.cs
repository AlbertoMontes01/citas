using citas.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace citas.Server.Data
{
    public class DoctorContext: DbContext
    {
        public DoctorContext(DbContextOptions<DoctorContext> options) : base(options)
        {

        }
        public DbSet<Doctors>? Doctors { get; set; }
    }
}
