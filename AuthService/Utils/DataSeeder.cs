using AuthService.Data;
using AuthService.Models;
using AuthService.Utils.Helpers;
namespace AuthService.Utils
{
    public static class DataSeeder
    {
        public static async Task SeedDataAsync(IServiceProvider serviceProvider, ILogger logger, AuthHelper authHelper)
        {
            var context = serviceProvider.GetRequiredService<AuthDbContext>();

            if (context.Users.Any())
            {
                return;
            }

            var Usuarios = new List<User>
            {
                new User
                {
                    Email = "allfernandez@bp.fi.cr",
                    Password = authHelper.EncriptarPassword("allFernandez@2025"),
                    Nombre = "Allam",
                    PrimerApellido = "Fernandez",
                    SegundoApellido = "BP",
                    Rol = "Admin"
                },
                new User
                {
                    Email = "alecampos@bp.fi.cr",
                    Password = authHelper.EncriptarPassword("aleCampos@2025"),
                    Nombre = "Alejandro",
                    PrimerApellido = "Campos",
                    SegundoApellido = "BP",
                    Rol = "Admin"
                }
            };

            await context.Users.AddRangeAsync(Usuarios);
            await context.SaveChangesAsync();
        }
    }
}
