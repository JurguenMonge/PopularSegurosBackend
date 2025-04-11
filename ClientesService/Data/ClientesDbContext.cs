using ClientesService.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientesService.Data
{
    public class ClientesDbContext : DbContext
    {
        public ClientesDbContext(DbContextOptions<ClientesDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set;}
    }
}
