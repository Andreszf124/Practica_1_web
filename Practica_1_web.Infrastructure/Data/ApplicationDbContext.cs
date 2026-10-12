using Microsoft.EntityFrameworkCore;
using Practica_1_web.Domain.Entities;

namespace Practica_1_web.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar relación Cliente - Telefono
            modelBuilder.Entity<Telefono>()
                .HasOne(t => t.Cliente)
                .WithMany(c => c.Telefonos)
                .HasForeignKey(t => t.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurar propiedades de Cliente
            modelBuilder.Entity<Cliente>()
                .Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Email)
                .HasMaxLength(150);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Direccion)
                .HasMaxLength(200);

            // Configurar propiedades de Telefono
            modelBuilder.Entity<Telefono>()
                .Property(t => t.Numero)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Telefono>()
                .Property(t => t.Tipo)
                .HasMaxLength(50);
        }
    }
}
