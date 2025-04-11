using PolizasService.Data;
using PolizasService.Models;

namespace PolizasService.Utils
{
    public static class DataSeeder
    {
        public static async Task SeedDataAsync(IServiceProvider serviceProvider, ILogger logger)
        {
            var context = serviceProvider.GetRequiredService<PolizaDbContext>();

            if (context.TipoPolizas.Any())
            {
                return;
            }

            if (context.Coberturas.Any())
            {
                return;
            }

            if (context.EstadoPolizas.Any())
            {
                return;
            }
           

            var TipoPolizas = new List<TipoPoliza>
            {
                new TipoPoliza { Descripcion = "Póliza de Auto" },
                new TipoPoliza { Descripcion = "Póliza de Vida" },
                new TipoPoliza { Descripcion = "Póliza de Salud" },
                new TipoPoliza { Descripcion = "Póliza de Hogar" },
                new TipoPoliza { Descripcion = "Póliza de Viaje" },
                new TipoPoliza { Descripcion = "Póliza de Incendio" },
            };

            var Coberturas = new List<Cobertura>
            {
                new Cobertura { Descripcion = "Cobertura contra Incendio" },
                new Cobertura { Descripcion = "Cobertura de Robo" },
                new Cobertura { Descripcion = "Cobertura de Daños a Terceros" },
                new Cobertura { Descripcion = "Cobertura de Responsabilidad Civil" },
                new Cobertura { Descripcion = "Cobertura de Accidentes Personales" },
                new Cobertura { Descripcion = "Cobertura de Enfermedades Graves" },
            };

            var Estados = new List<EstadoPoliza>
            {
                new EstadoPoliza { Descripcion = "Vigente" },
                new EstadoPoliza { Descripcion = "Vencida" },
                new EstadoPoliza { Descripcion = "Cancelada" },
                new EstadoPoliza { Descripcion = "Emitida" },
                new EstadoPoliza { Descripcion = "En Revisión" },
                new EstadoPoliza { Descripcion = "Caducada" },
            };

            await context.TipoPolizas.AddRangeAsync(TipoPolizas);
            await context.Coberturas.AddRangeAsync(Coberturas);
            await context.EstadoPolizas.AddRangeAsync(Estados);

            await context.SaveChangesAsync();
        }

    }
}
