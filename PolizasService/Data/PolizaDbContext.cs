using Microsoft.EntityFrameworkCore;
using PolizasService.Models;

namespace PolizasService.Data
{
    public class PolizaDbContext : DbContext
    {
        public PolizaDbContext(DbContextOptions<PolizaDbContext> options) : base(options) { }

        public DbSet<TipoPoliza> TipoPolizas { get; set; }
        public DbSet<Cobertura> Coberturas { get; set; }
        public DbSet<EstadoPoliza> EstadoPolizas { get; set; }
        public DbSet<Poliza> Polizas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Precision de los decimales
            modelBuilder.Entity<Poliza>()
               .Property(p => p.MontoAsegurado)
               .HasColumnType("decimal(18,2)");  

            
            modelBuilder.Entity<Poliza>()
                .Property(p => p.Prima)
                .HasColumnType("decimal(18,2)");

            //Relaciones 1:N con Polizas
            modelBuilder.Entity<TipoPoliza>()
               .HasMany(t => t.Polizas)
               .WithOne(p => p.TipoPoliza)
               .HasForeignKey(p => p.TipoPolizaId);

            modelBuilder.Entity<Cobertura>()
               .HasMany(c => c.Polizas)
               .WithOne(p => p.Cobertura)
               .HasForeignKey(p => p.CoberturaId);

            modelBuilder.Entity<EstadoPoliza>()
              .HasMany(e => e.Polizas)
              .WithOne(p => p.EstadoPoliza)
              .HasForeignKey(p => p.EstadoPolizaId);
        }
    }
}
