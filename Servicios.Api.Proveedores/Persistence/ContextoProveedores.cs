using Microsoft.EntityFrameworkCore;
using Servicios.Api.Proveedores.Models;

namespace Servicios.Api.Proveedores.Persistence
{
    public class ContextoProveedores : DbContext
    {
        public ContextoProveedores(DbContextOptions<ContextoProveedores> options) : base(options) { }

        public DbSet<ModeloProveedores> ModeloProveedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModeloProveedores>()
                .HasKey(p => p.ProveedorId);
        }
    }
}
