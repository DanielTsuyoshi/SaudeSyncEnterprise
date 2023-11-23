using SaudeSync.Entities;
using Microsoft.EntityFrameworkCore;

namespace SaudeSync.Persistence
{
    public class PostgreDbContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Prescricao> Prescricao { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<LeituraSaude> LeituraSaude { get; set; }
        public DbSet<Consultorio> Consultorio { get; set; }
        public DbSet<Medico> Medico { get; set; }

        public PostgreDbContext(DbContextOptions<PostgreDbContext> options) : base(options) { }
    }
}
