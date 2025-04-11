using ClientesService.Data;
using ClientesService.Models;

namespace ClientesService.Utils
{
    public static class DataSeeder
    {

        public static async Task SeedDataAsync(IServiceProvider serviceProvider, ILogger logger)
        {
            var context = serviceProvider.GetRequiredService<ClientesDbContext>();

            if (context.Clientes.Any())
            {
                return;
            }

            var Clientes = new List<Cliente>
            {
                new Cliente
                {
                    CedulaAsegurado = "709320442",
                    Nombre = "Juan",
                    PrimerApellido = "Pérez",
                    SegundoApellido = "Rodríguez",
                    TipoPersona = "Natural",
                    FechaNacimiento = new DateOnly(1990, 5, 12),
                    EstaEliminado = false
                },
                 new Cliente
                {
                    CedulaAsegurado = "209830442",
                    Nombre = "María",
                    PrimerApellido = "González",
                    SegundoApellido = "Lopez",
                    TipoPersona = "Natural",
                    FechaNacimiento = new DateOnly(1985, 8, 25),
                    EstaEliminado = false
                },
                 new Cliente
                {
                    CedulaAsegurado = "103320532",
                    Nombre = "Carlos",
                    PrimerApellido = "Sánchez",
                    SegundoApellido = "Mora",
                    TipoPersona = "Natural",
                    FechaNacimiento = new DateOnly(1992, 11, 30),
                    EstaEliminado = false
                }
            };


            await context.Clientes.AddRangeAsync(Clientes);
            await context.SaveChangesAsync();

        }

    }
}
