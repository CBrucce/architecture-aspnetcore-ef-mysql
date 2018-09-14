using ArchitectureAspNetCoreEFMySQL.Core.Domain.Entities;
using ArchitectureAspNetCoreEFMySQL.Core.Domain.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ArchitectureAspNetCoreEFMySQL.Core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<Carro> Carros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarroMap());
        }
    }
}
