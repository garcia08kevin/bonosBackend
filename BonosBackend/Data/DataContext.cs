using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BonosBackend.Models;

namespace BonosBackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            if (!options.IsConfigured)

            {

                options.UseSqlServer("A FALLBACK CONNECTION STRING");

            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Bono> Bonos { get; set; }
    }
}
