using citas.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace citas.Server.Data
{
    public class PacientContext : DbContext
    {
        public PacientContext(DbContextOptions<PacientContext> options) : base(options)
        {

        }
        public DbSet<Pacient>? Pacients { get; set; }
    }
}